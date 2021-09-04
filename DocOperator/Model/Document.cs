using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{
    [Table(Name = "d_documents")]
    public class Document
    {
        public const int ST_PENDING = 0;        // 待发起
                                                //  public const int ST_CODE = 1;           // 文档分配代码
        public const int ST_WK_REVIEWING = 2;   // 待文控检查格式，发起审核
        public const int ST_WK_REJECTED = 3;    // 文控审核格式不通过
        public const int ST_REVIEWING = 4;      // 审批中
        public const int ST_REJECTED = 5;       // 审批失败
        public const int ST_ISSUED = 6;         // 已发布
        public const int ST_OTHER = 6;          // 除了发布以外的状态

        [Column(IsIdentity = true, IsPrimary = true)]
        public int id { get; set; }

        public int project_id { get; set; }
        public string name { get; set; }

        public int author_user_id { get; set; }

        public int category_id { get; set; }

        public int flow_id { get; set; }
        public int current_instance_id { get; set; }

        public string code { get; set; }

        public string version { get; set; }

        public string description { get; set; }
        public DateTime require_date { get; set; }

        public int status { get; set; }

        public int is_distributed { get; set; }
        public int is_converted { get; set; }

        public DateTime created_at { get; set; }

        public DateTime applied_at { get; set; }

        public DateTime? issued_at { get; set; }

    }
}
