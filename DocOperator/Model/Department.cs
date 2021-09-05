using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{
    [Table(Name = "d_departments")]
    public class Department
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public int ordering { get; set; }
        public int manager_user_id { get; set; }


        public override bool Equals(Object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (!(obj is Department))
                return false;
            var d = (Department)obj;

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (id == d.id) && (name == d.name);
        }

        public override int GetHashCode()
        {
            return (Convert.ToString(id) + name).GetHashCode();
        }

    }
}
