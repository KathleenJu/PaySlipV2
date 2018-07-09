using System.Collections.Generic;

namespace PaySlip.PaySlipUI
{
    interface IPaySlipUserInterface
    {
        Dictionary<string, string> GetPersonDetails(Dictionary<string, string> formFilePath);

        void PrintPaySlip(PaySlip paySlip, Dictionary<string, string> formFilePath);
    }
}