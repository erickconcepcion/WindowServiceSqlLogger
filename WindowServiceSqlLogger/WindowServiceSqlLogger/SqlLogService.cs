using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowServiceSqlLogger
{
    public partial class SqlLogService : ServiceBase
    {
        public SqlLogService()
        {
            InitializeComponent();
            client = LogDbClient.Instance;
            Seconds = 0;
        }
        private LogDbClient client;
        private int Seconds;
        protected override void OnStart(string[] args)
        {
            client.WriteToLog("Starting Service...");
        }

        protected override void OnStop()
        {
            client.WriteToLog("Stopping Service...");
            client.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Seconds>=10)
            {
                client.WriteToLog("Write new entry");
                Seconds = 0;
            }
            Seconds++;
        }
    }
}
