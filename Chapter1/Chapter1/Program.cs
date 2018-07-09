using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Chapter1
{

  
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void M1()
        {
          
        }
    }

    public static class ConnectionHelper
    {
        public static R Connect<R>(string connectionString, Func<IDbConnection, R> f)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return f(conn);
            }
        }

        public static R Connect2<R>(string conStr, Func<IDbConnection, R> f)
            => F.Using(new SqlConnection(), conn => { conn.Open(); return f(conn); });
    }

    public static class F
    {
        public static R Using<TDisp,R>(TDisp dis, Func<TDisp, R> f) where TDisp: IDisposable
        {
            using (dis) return f(dis);
        }
    }
}
