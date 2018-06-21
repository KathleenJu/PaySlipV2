using System.Linq;

namespace PaySlip
{
    interface PaySlipUserInterface
    {
        void GeneratePaySlipForm(string formFile);

        void PrintPaySlip();
    }
}