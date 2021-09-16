
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonthlyAmortizationCalculator.Model;
using MonthlyAmortizationCalculator.Presenters;

namespace MonthlyAmortizationCalculator.View
{
    public partial class LoanView : Form
    {
        ClientSummaryPresenter clientSummaryPresenter = new ClientSummaryPresenter();
        public LoanView(ClientLoan clientLoan)
        {
            InitializeComponent();
            LoadLoanToDataGrid(clientLoan);
        }
        public void ClearGrid()
        {

            this.PaymentScheduleDataGridView.Columns.Clear();
            this.PaymentScheduleDataGridView.ColumnCount = 3;
            this.PaymentScheduleDataGridView.Columns[0].Name = "Payment Date";
            this.PaymentScheduleDataGridView.Columns[1].Name = "Monthly Amortization";
            this.PaymentScheduleDataGridView.Columns[2].Name = "Remaining Balance";

            this.PaymentScheduleDataGridView.Rows.Clear();
        }
        private void LoanView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public void LoadLoanToDataGrid(ClientLoan clientLoan)
        {
            ClearGrid();
            int TermsInMonths = clientLoan.LoanTerm * 12;
            double FixedRate = ((double) clientLoan.FixedRate / (double)100) / (double)12;
            double d = (Math.Pow(1 + FixedRate, TermsInMonths) - 1) / (FixedRate * Math.Pow((1 + FixedRate), TermsInMonths));
            Math.Round(d, 2);
            double MonthlyAmortization = clientLoan.LoanAmount / d;
            Math.Round(MonthlyAmortization, 2); ;
            double TotalAmount = MonthlyAmortization * TermsInMonths;
            Math.Round(TotalAmount, 2);
            //MessageBox.Show(FixedRate.ToString("0.00000000"));
            for (int x = 0; x < TermsInMonths; x++)
            {
                TotalAmount = TotalAmount - MonthlyAmortization;
                PaymentScheduleDataGridView.Rows.Add(clientLoan.StartDate.AddMonths(x).ToString("MM/dd/yyyy"), MonthlyAmortization.ToString("0.00"), TotalAmount < 0 ? "0.00" : TotalAmount.ToString("0.00"));
            }
        }
        

    }
}
