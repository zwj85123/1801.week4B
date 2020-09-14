using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Page
    {
        public int PageIndex { get; set; }//第几页
        public int PageSize { get; set; }//每页几条
        public int PageCount { get; set; }//总页数
        public int AllCount { get; set; }//总条数
        public List<KuCun>  GetKuCuns { get; set; }
    }
    public class KuCun
    {
        public int Kid		 { get; set; }
        public string Kname { get; set; }
        public string GuiGe { get; set; }
        public int Kcount { get; set; }
        public int Pici { get; set; }
    }
}
