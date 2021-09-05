using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;

namespace DocOperator.Model
{
    [Table(Name = "d_flow_records")]
    public class FlowRecord
    {
        public const int PENDING = 0;   // 通过
        public const int APPROVED = 1;   // 通过
        public const int REJECTED = 2;   // 失败

        [Column(IsIdentity = true, IsPrimary = true)]
        public int id { get; set; }
        public int instance_id { get; set; }
        public int flow_id { get; set; }
        public int node_id { get; set; }
        public string node_title { get; set; }
        public int ordering { get; set; }
        public int reviewer_id { get; set; }
        public int department_id { get; set; }
        public int type { get; set; }
        public int result { get; set; }
        public string remark { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }

}
