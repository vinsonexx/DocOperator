using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{
    [Table(Name = "d_files")]
    public class File
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int id { get; set; }

        [Column(Name = "document_id")]
        public int documentId { get; set; }

        public string version { get; set; }

        public string path { get; set; }

        public string description { get; set; }
        public string require_date { get; set; }

        public DateTime applied_at { get; set; }

        public DateTime? issued_at { get; set; }

    }
}
