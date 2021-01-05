using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowServiceSqlLogger
{
    class LogDbClient
    {
        private static LogDbClient instance;
        public static LogDbClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogDbClient();
                }
                return instance;
            }
        }
        public LogDbClient()
        {
            Init();
        }
        public SqlConnection Connection { get; set; }

        private void Init()
        {
            Connection = new SqlConnection("{your_connection_here}");
        }

        public void WriteToLog(string text)
        {
            var query = $"insert into LogTable values('{text}', '{DateTime.Now.ToString("yyyy-MM-dd H:mm:ss")}')";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
