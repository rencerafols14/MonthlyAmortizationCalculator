using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyAmortizationCalculator.Model
{
    public class ClientLoan : Client
    {
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public DateTime StartDate { get; set; }
        public int FixedRate { get; set; }

        public ClientLoan()
        {

        }

        public ClientLoan(string clientName, double loanAmount, int loanTerm, DateTime startDate, int fixedRate)
        {
            Name = clientName;
            LoanAmount = loanAmount;
            LoanTerm = loanTerm;
            StartDate = startDate;
            FixedRate = fixedRate;
        }
    }
}
