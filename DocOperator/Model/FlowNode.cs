using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{

    [Table(Name = "d_flow_nodes")]
    public class FlowNode
    {
        public const int SINGLE = 1;    // 单人审批
        public const int MULTI = 2;     // 多人会签

        [Column(IsIdentity = true, IsPrimary = true)]
        public int id { get; set; }
        public int flow_id { get; set; }
        public string title { get; set; }
        public int type { get; set; }
        public string reviewer_id { get; set; }
        public int ordering { get; set; }
    }
}
