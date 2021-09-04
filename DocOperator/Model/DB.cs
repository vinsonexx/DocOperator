using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocOperator.Common;

namespace DocOperator.Model
{
    public class DB
    {
        public DB()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        static private IFreeSql fsql = null;

        static public IFreeSql getIFreeSql()
        {
            if (fsql != null)
                return fsql;

            CfgInfo cfgInfo = new CfgInfo(Utility.getExePath() + "config.ini");

            string connStr = cfgInfo.GetConnString();//连接符字串
            fsql = new FreeSql.FreeSqlBuilder()
                .UseAutoSyncStructure(false)
                .UseConnectionString(FreeSql.DataType.SqlServer, connStr)
                .Build(); //请务必定义成 Singleton 单例模式

            return fsql;
        }

    }
}
