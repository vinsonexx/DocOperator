using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{
    [Table(Name = "s_Users")]
    public class User
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int UserId { get; set; }
        public string UserName { get; set; }

    }
}
