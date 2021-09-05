using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{


    [Table(Name = "d_user_infos")]
    public class UserInfo
    {
        public int user_id { get; set; }
        public string signature { get; set; }

    }
}
