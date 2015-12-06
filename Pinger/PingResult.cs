using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    class PingResult
    {
        private float successRate;
        private float averageMs;
        private string host;
        private int attempts;
        private DateTime timestamp = new DateTime();

        public float SuccessRate
        {
            get { return successRate; }
            set { successRate = value; }
        }

        public float AverageMs
        {
            get { return averageMs; }
            set { averageMs = value; }
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public int Attempts
        {
            get { return attempts; }
            set { attempts = value; }
        }

        public override string ToString()
        {
            return timestamp.ToString("s") + "," + host + "," + successRate + "%," + averageMs + "ms";
        }

        public void UpdateTimestamp()
        {
            timestamp = DateTime.Now;
        }
    }
}
