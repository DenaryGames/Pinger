using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    class Pings
    {
        private List<PingResult> pings;

        public Pings()
        {
            pings = new List<PingResult>();
        }

        public void AddPing(PingResult ping)
        {
            pings.Add(ping);
        }

        public List<PingResult> Records
        {
            get
            {
                return pings;
            }
        }

        // Write to file
        public void SaveToFile(string filename)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename))
            {
                foreach (PingResult ping in pings)
                {
                    file.WriteLine(ping);     
                }
            }
        }
    }
}
