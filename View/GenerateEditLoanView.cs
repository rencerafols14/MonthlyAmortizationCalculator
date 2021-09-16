using MonthlyAmortizationCalculator.Model;
using MonthlyAmortizationCalculator.Presenters;
using MonthlyAmortizationCalculator.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonthlyAmortizationCalculator
{
    public partial class GenerateEditLoanView : Form
    {
        ClientSummaryPresenter clientSummaryPresenter = new ClientSummaryPresenter();
        public GenerateEditLoanView(string mode,int clientID)
        {
            InitializeComponent();
            if(mode != "New")
            {
                initializeComponent(clientSummaryPresenter.DatabaseRepository.GetClient(clientID));
                dateTimePickerStartDate.Enabled = false;
                TextBoxLoanAmount.Enabled = false;
                TextBoxLoanTerm.Enabled = false;
                btnEditGenerate.Enabled = false;
            }
        }
        private void GenerateEditLoanView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void initializeComponent(ClientLoan clientLoan)
        {
            TextBoxLoanAmount.Text = clientLoan.LoanAmount.ToString();
            TextBoxLoanTerm.Text = clientLoan.LoanTerm.ToString();
            TextBoxClientName.Text = clientLoan.Name.ToString();
            TextBoxFixedRate.Text = clientLoan.FixedRate.ToString();
            dateTimePickerStartDate.Value = clientLoan.StartDate;
        }
        private void btnEditGenerate_Click(object sender, EventArgs e)
        {
            bool validation;
            ClientLoan clientLoan = new ClientLoan();
            clientLoan.Name = TextBoxClientName.Text;
            clientLoan.LoanAmount = double.Parse(TextBoxLoanAmount.Text);
            clientLoan.LoanTerm = int.Parse(TextBoxLoanTerm.Text);
            clientLoan.StartDate = dateTimePickerStartDate.Value;
            clientLoan.FixedRate = int.Parse(TextBoxFixedRate.Text);

            validation=clientSummaryPresenter.AddClient(clientLoan);
            if(validation == false)
            {
                MessageBox.Show("Client Loan Existed!");
            }
            else
            {
                MessageBox.Show("Added Successfully!");
                Close();
            }            
        }

        private void TextBoxFixedRate_TextChanged(object sender, EventArgs e)
        {
            btnEditGenerate.Enabled = true;
        }
    }
}
