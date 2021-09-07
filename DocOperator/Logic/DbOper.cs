using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Model;
using DocOperator.Vo;

namespace DocOperator.Logic
{
    class DbOper
    {
        private IFreeSql fsql;

        public DbOper()
        {
            fsql = DB.getIFreeSql();
        }


        public dynamic GetConvertTask()
        {
            return fsql.Select<Document, File>()
                .LeftJoin((a, b) => a.id == b.documentId && a.version == b.version)
                .Where((a, b) => a.step == Document.STEP_PENDING || a.step == Document.STEP_SIGNED)
                .Where((a, b) => a.category_id != 4)
                .ToList((a, b) => new { 
                    a.id,
                    a.step,
                    b.path 
                });
        }

        public bool SetDocumentStep(int docId, int step)
        {
            int rows = fsql.Update<Document>(docId)
                .Set(a => a.step, step)
                .ExecuteAffrows();

            return rows > 0;
        }

        public dynamic GetSignTask()
        {
            return fsql.Select<Document, File, Category, UserInfo>()
                .LeftJoin((a, b, c, d) => a.id == b.documentId && a.version == b.version)
                .LeftJoin((a, b, c, d) => a.category_id == c.id)
                .LeftJoin((a, b, c, d) => a.author_user_id == d.user_id)
                .Where((a, b, c, d) => a.status == Document.ST_ISSUED)
                .Where((a, b, c, d) => a.step == Document.STEP_INITPDF)
                .ToList((a, b, c, d) => new { 
                    id = a.id,
                    current_instance_id = a.current_instance_id,
                    version = a.version,
                    applied_at = ((DateTime)a.applied_at).ToString("yyyy-MM-dd"),
                    issued_at = ((DateTime)a.issued_at).ToString("yyyy-MM-dd"),
                    path = b.path,
                    sign = c.sign,
                    signature = d.signature,
                    step = a.step
                });
        }

        public List<Reviewer> GetDocReviewers(int instanceId, int nodeType)
        {
            var reviewers = fsql.Select<FlowRecord, User, UserInfo, Department>()
                .LeftJoin((a, b, c, d) => a.reviewer_id == b.UserId)
                .LeftJoin((a, b, c, d) => a.reviewer_id == c.user_id)
                .LeftJoin((a, b, c, d) => a.department_id == d.id)
                .Where((a, b, c, d) => a.instance_id == instanceId)
                .Where((a, b, c, d) => a.type == nodeType)
                .OrderBy((a, b, c, d) => a.ordering)
                .ToList((a, b, c, d) => new Reviewer
                {
                    keyword = (a.type == FlowNode.SINGLE) ? "" : d.name,
                    signature = c.signature,
                    date = ((DateTime)a.updated_at).ToString("yyyy-MM-dd")
                });

            return reviewers;
        }


    }
}
