
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonthlyAmortizationCalculator.Model;
using MonthlyAmortizationCalculator.View;
using MonthlyAmortizationCalculator.Presenters;

namespace MonthlyAmortizationCalculator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClientSummaryView ClientSummaryView = new ClientSummaryView();
            Application.Run(ClientSummaryView);
        }
    }
}
