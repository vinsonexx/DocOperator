using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocOperator.Vo
{
    class ReviewInfo
    {
        public string tableName { get; set; }
        public List<Reviewer> reviewers { get; set; }

        public ReviewInfo()
        {
            reviewers = new List<Reviewer>();
        }
    }
}
