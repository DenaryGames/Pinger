using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    class PingTool
    {
        public PingResult DoPing(string host, int echoNum, Pings pings)
        {
            long totalTime = 0;
            int timeout = 120;
            int success = 0;
            int fail = 0;
            Ping pingSender = new Ping();
            PingResult result = new PingResult();

            for (int i = 0; i < echoNum; i++)
            {
                PingReply reply = pingSender.Send(host, timeout);
                if (reply.Status == IPStatus.Success)
                {
                    success++;
                    totalTime += reply.RoundtripTime;
                } else
                {
                    fail++;
                }
            }

            // Calculate statistics, create new PingResult
            result.SuccessRate = success / echoNum * 100;

            if(result.SuccessRate > 0)
            {
                result.AverageMs = totalTime / echoNum;
            } else
            {
                result.AverageMs = 0;
            }
                        
            result.Host = host;
            result.Attempts = echoNum;
            result.UpdateTimestamp();

            pings.AddPing(result);

            return result;
        }
    }
}
