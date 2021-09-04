using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Model;

namespace DocOperator.Logic
{
    class DbOper
    {
        private IFreeSql fsql;

        public DbOper()
        {
            fsql = DB.getIFreeSql();
        }


        public List<File> GetPendingTask()
        {
            return fsql.Select<Document, File>()
                .LeftJoin((a, b) => a.id == b.documentId && a.version == b.version)
                .Where((a, b) => a.is_converted == 0)
                .ToList((a, b) => new File { documentId=b.documentId, path=b.path });
        }

        public bool SetDocumentConverted(int docId)
        {
            int rows = fsql.Update<Document>(docId)
                .Set(a => a.is_converted, 1)
                .ExecuteAffrows();

            return rows > 0;
        }




    }
}
