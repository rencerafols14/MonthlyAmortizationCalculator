using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyAmortizationCalculator.Model
{
    class LoanPaymentSchedule
    {
        public DateTime PaymentDate;
        public double MonthlyAmortization;
        public double RemainingBalance;

        public LoanPaymentSchedule(DateTime paymentDate, double monthlyAmortization, double remainingBalance)
        {
            PaymentDate = paymentDate;
            MonthlyAmortization = monthlyAmortization; 
            RemainingBalance = remainingBalance;
        }
    }
}
