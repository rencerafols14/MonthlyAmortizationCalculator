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
using System.Collections;
using MonthlyAmortizationCalculator.Presenters;

namespace MonthlyAmortizationCalculator.View
{
    public partial class ClientSummaryView : Form
    {

        ClientSummaryPresenter clientSummaryPresenter = new ClientSummaryPresenter();
        GenerateEditLoanView generateEditLoanView;
        LoanView loanView;
        public ClientSummaryView()
        {
            InitializeComponent();
            clientSummaryPresenter.DatabaseRepository.InitializeDatabase();
            ResetGridView();
        }
        private void ClientSummaryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void DisplayClientSumarries(Dictionary<int, ClientLoan> clientLoans)
        {
            foreach (var client in clientLoans)
            {
                ClientLoanDataGridView.Rows.Add(client.Key,client.Value.Name, client.Value.LoanAmount, client.Value.LoanTerm);
            }
        }

        public void ResetGridView()
        {
            ClientLoanDataGridView.Columns.Clear();
            ClientLoanDataGridView.ColumnCount = 4;
            ClientLoanDataGridView.Columns[0].Name = "No.";
            ClientLoanDataGridView.Columns[0].Visible = false;
            ClientLoanDataGridView.Columns[1].Name = "Client Name";
            ClientLoanDataGridView.Columns[2].Name = "Loan Amount";
            ClientLoanDataGridView.Columns[3].Name = "Loan Term";
            ClientLoanDataGridView.Rows.Clear();

            DisplayClientSumarries(clientSummaryPresenter.TranslateClientSumarries());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ClientLoanDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = ClientLoanDataGridView.Rows[selectedRowIndex];
            string cellValue = selectedRow.Cells[0].Value.ToString();

            if (ClientLoanDataGridView.SelectedCells.Count > 0)
            {
                bool validation;
                validation = clientSummaryPresenter.DeleteClient(int.Parse(cellValue));
                if(validation == false)
                {
                    MessageBox.Show("Deletion Failed! Select data does not exists in the Database!");
                }
                else
                {
                    MessageBox.Show("Successfully Deleted!");
                }
                ResetGridView();
            }
            else
            {
                MessageBox.Show("No selected row to be delete!");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateEditLoanView = new GenerateEditLoanView("New", 0);  
            generateEditLoanView.FormClosed += generateEditLoanView_FormClosed;              
            generateEditLoanView.ShowDialog(this);
            
        }
        void generateEditLoanView_FormClosed(object sender, FormClosedEventArgs e)
        {
            generateEditLoanView = null; 
            Show();
            ResetGridView();
        }
        void loanView_FormClosed(object sender, FormClosedEventArgs e)
        {
            generateEditLoanView = null;  
            Show();
            ResetGridView();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ClientLoanDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = ClientLoanDataGridView.Rows[selectedRowIndex];
            string cellValue = selectedRow.Cells[0].Value.ToString();

            if (ClientLoanDataGridView.SelectedCells.Count > 0)
            {
                ClientLoan clientLoan = clientSummaryPresenter.DatabaseRepository.GetClient(int.Parse(cellValue));
                loanView = new LoanView(clientLoan);
                loanView.FormClosed += generateEditLoanView_FormClosed;

                loanView.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No selected row to view!");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ClientLoanDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = ClientLoanDataGridView.Rows[selectedRowIndex];
            string cellValue = selectedRow.Cells[0].Value.ToString();

            if (ClientLoanDataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select desired data to edit!");
            }
            else
            {
                generateEditLoanView = new GenerateEditLoanView("Edit", int.Parse(cellValue));   
                generateEditLoanView.FormClosed += generateEditLoanView_FormClosed;  
                generateEditLoanView.ShowDialog(this);
            }
            

            
        }
    }
}
