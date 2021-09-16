using MonthlyAmortizationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyAmortizationCalculator.Services
{
    public class Database
    {
        public static Dictionary<int, ClientLoan> ClientLoans = new Dictionary<int, ClientLoan>();
    }
}
