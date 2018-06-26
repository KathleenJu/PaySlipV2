using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    interface PaySlipUserInterface
    {
        Dictionary<string, string> GetUserDetails(string formFilePath);

        void PrintPaySlip(PaySlip paySlip, string paySlipFilePath);
    }
}