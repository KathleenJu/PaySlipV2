using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    interface PaySlipUserInterface
    {
        Dictionary<string, string> GetPersonDetails(string formFilePath);

        void PrintPaySlip(PaySlip paySlip, string paySlipFilePath);
    }
}