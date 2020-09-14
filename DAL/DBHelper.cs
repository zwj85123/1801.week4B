using System;
using System.Collections.Generic;
using System.Data.SqlClient;//引用数据库客户端
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
//namespace DAL//改为和项目的名称一样
namespace DAL
{
    public class DBHelper
    {
        /// <summary>
        /// 查询聚合函数 用这个
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalor(string sql)
        {
            try
            {
                //连接数据库
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Unit20200903;Integrated Security=True");
                //打开
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                object obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// 获取数据流  查询、显示、绑定下拉
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql)
        {
            try
            {
                //连接数据库
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Unit20200903;Integrated Security=True");
                //打开
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// 返回受影响行数  
        /// 添加、删除、修改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                //连接数据库
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Unit20200903;Integrated Security=True");
                //打开
                //判断状态
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                int h = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                return h;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 数据流转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sdr"></param>
        /// <returns></returns>
        private List<T> DataReaderToList<T>(SqlDataReader sdr) {
            Type t = typeof(T);//获取类型
            //获取所有属性
            PropertyInfo[] p = t.GetProperties();
            //定义集合
            List<T> list = new List<T>();
            //遍历数据流
            while (sdr.Read()) {
                //创建对象
                T obj = (T)Activator.CreateInstance(t);
                foreach (PropertyInfo item in p)
                {
                    item.SetValue(obj, sdr[item.Name]);//对象属性赋值
                }
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// 获取list集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetToList<T>(string sql) {
            //获取流数据
            SqlDataReader sdr = GetDataReader(sql);
            List<T> list = DataReaderToList<T>(sdr);
            return list;
        }
       
    }
}
