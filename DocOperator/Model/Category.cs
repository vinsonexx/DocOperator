using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeSql.DataAnnotations;


namespace DocOperator.Model
{
    [Table(Name = "d_categories")]
    public class Category
    {
        public const int GongSiJiDaGang = 1;    // 公司级大纲
        public const int DaGangChengXu = 2;     // 大纲程序
        public const int ZuoYeZhiDao = 3;       // 作业指导
        public const int HeDianBiaoDan = 4;     // 核电表单


        [Column(IsPrimary = true)]
        public int id { get; set; }
        public string name { get; set; }
        public string flow { get; set; }
        public string prefix { get; set; }
        public string sign { get; set; }

        public int serial { get; set; }
        public int length { get; set; }
    }

}
