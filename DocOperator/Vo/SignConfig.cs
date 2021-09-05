using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DocOperator.Vo
{
    class SignConfig
    {
        public int category { get; set; }
        public string srcPath { get; set; }
        public string destPath { get; set; }
        public string version { get; set; }
        public string CEO { get; set; }
        public Reviewer issueAt { get; set; }

        public ReviewInfo homepage { get; set; }
        public ReviewInfo multiReviewers { get; set; }

        public SignConfig()
        {
            issueAt = new Reviewer();
            homepage = new ReviewInfo();
            multiReviewers = new ReviewInfo();
        }
    }
}
