using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DocOperator.Model;
using DocOperator.Common;
using DocOperator.OfficeOper;
using DocOperator.Vo;
using Newtonsoft.Json;
using Serilog;



namespace DocOperator.Logic
{
    class SignWorker : Worker
    {
        public void StartUp()
        {
            for (;;)
            {
                var docList = dbOper.GetSignTask();
                foreach (var doc in docList)
                {
                    Log.Information("Doc id: " + doc.id.ToString());
                    // 取出审批信息
                    SignConfig cfg = initSignConfig(doc.sign);
                    if (!setSignConfig(cfg, doc))
                        continue;

                    if (WordSigner.Sign(doc.id, cfg))
                        dbOper.SetDocumentStep(doc.id, Document.STEP_SIGNED);
                }

                Thread.Sleep(waitTime);     // 避免失败文件循环 
            }
        }

        private SignConfig initSignConfig(string signStr)
        {
            SignConfig cfg = JsonConvert.DeserializeObject<SignConfig>(signStr);

            return cfg;
        }

        private bool setSignConfig(SignConfig cfg, dynamic doc)
        {
            cfg.srcPath = (projectDir + doc.path).Replace('/', '\\');
            cfg.destPath = cfg.srcPath;
            cfg.version = doc.version;

            cfg.issueAt.date = doc.issued_at;

            return setHomepage(cfg, doc) && setMultiReviewers(cfg, doc);

        }

        private bool setHomepage(SignConfig cfg, dynamic doc)
        {
            // 编写者要取出来
            List<Reviewer> reviewers =
                dbOper.GetDocReviewers(doc.current_instance_id, FlowNode.SINGLE);

            reviewers.Insert(0, new Reviewer
            {
                keyword = "",
                date = doc.applied_at,
                signature = doc.signature
            });

            if (reviewers.Count != cfg.homepage.reviewers.Count)
            {
                return false;
            }

            for (int i=0; i<reviewers.Count; i++)
            {
                cfg.homepage.reviewers[i].signature = 
                    (projectDir + reviewers[i].signature).Replace('/', '\\');
                cfg.homepage.reviewers[i].date = reviewers[i].date;
            }

            return true;
        }

        private bool setMultiReviewers(SignConfig cfg, dynamic doc)
        {
            List<Reviewer> reviewers =
                dbOper.GetDocReviewers(doc.current_instance_id, FlowNode.MULTI);

            foreach (Reviewer r in reviewers)
            {
                r.signature = (projectDir + r.signature).Replace('/', '\\');
            }

            cfg.multiReviewers.reviewers = reviewers;
            return true;
        }



    }
}
