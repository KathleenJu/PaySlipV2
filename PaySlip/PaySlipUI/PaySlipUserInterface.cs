using System.Collections.Generic;
using System.Linq;

namespace PaySlip
{
    interface PaySlipUserInterface
    {
        Dictionary<string, string> GetPersonDetails(Dictionary<string, string> formFilePath);

        void PrintPaySlip(PaySlip paySlip, Dictionary<string, string> formFilePath);
    }
}