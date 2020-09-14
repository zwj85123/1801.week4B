using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class Fdal
    {
        DBHelper db = new DBHelper();

        /// <summary>
        /// 显示商品库存
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public Page ShowKucun(int pageindex,int pagesize)
        {
            string sql = "select * from KuCun";
            var list = db.GetToList<KuCun>(sql);
            if (pageindex<1)
            {
                pageindex = 1;
            }
            var counts = list.Count;
            var pagecout = 0;
            if (counts%pagesize==0)
            {
                pagecout = counts % pagesize;
            }
            else
            {
                pagecout = counts % pagesize + 1;
            }
            list = list.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            Page p = new Page();
            p.PageIndex = pageindex;
            p.PageSize = pagesize;
            p.PageCount = pagecout;
            p.AllCount = counts;
            p.GetKuCuns = list;
            return p;
        }

        public List<KuCun>Sele(int ids)
        {
            string sql = $"select * from KuCun where Kid = '{ids}'";
            return db.GetToList<KuCun>(sql);
        }

        public int Add(MingXi m)
        {
            string sql = $"insert into MingXi values ('{m.Mname}','{m.Mgg}','{m.Mtime}','{m.Gid}','{m.Sctime}','{m.Yxtime}','{m.Mcount}','{m.Mprice}')";
            return db.ExecuteNonQuery(sql);
        }

        public List<GongYinShang>Sel()
        {
            string sql = "select * from GongYinShang";
            return db.GetToList<GongYinShang>(sql);
        }
        public List<MingXi>  mingXis()
        {
            string sql = "select * from MingXi m join GongYinShang g on m.Gid=g.Gid";
            return db.GetToList<MingXi>(sql);
        }
    }
}
