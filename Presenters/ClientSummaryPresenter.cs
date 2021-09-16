using MonthlyAmortizationCalculator.Model;
using MonthlyAmortizationCalculator.Services;
using MonthlyAmortizationCalculator.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyAmortizationCalculator.Presenters
{
    public class ClientSummaryPresenter
    {
        public ClientLoan ClientLoan;
        public Repository DatabaseRepository;

        public ClientSummaryPresenter()
        {
            DatabaseRepository = new Repository();
            ClientLoan = new ClientLoan();
        }

        //public List<LoanPaymentSchedule> GeneratePaymentSchedule(int clientId)
        //{
        //    List<LoanPaymentSchedule> retval = new List<LoanPaymentSchedule> ();
        //    ClientLoan = DatabaseRepository.GetClient(clientId);
            
        //}
        public Dictionary<int, ClientLoan> TranslateClientSumarries()
        {
            return DatabaseRepository.GetAllClients();
        }
        public bool updateClient(int clientId)
        {
            var isUpdated = false;
            ClientLoan = DatabaseRepository.GetClient(clientId);
            if(ClientLoan != null)
            {
                DatabaseRepository.UpdateClientLoan(clientId);
                isUpdated = true;
            }
            return isUpdated;
        }
        public bool AddClient(ClientLoan clientLoan)
        {
            var isAdded = false;
            bool validation;
            Dictionary<int, ClientLoan> clientLoanRecord;
            clientLoanRecord = TranslateClientSumarries();
            validation=checkDuplicateRecord(clientLoan, clientLoanRecord);
            if (validation == true)
            {
                isAdded = false;
            }
            else
            {
                isAdded = true;
                DatabaseRepository.AddClientLoan(clientLoan);
            }
            return isAdded;
        }
        private bool checkDuplicateRecord(ClientLoan clientLoan, Dictionary<int, ClientLoan> clientLoanRecord)
        {
            var haveDuplicate = false;
            foreach(var client in clientLoanRecord)
            {
                CultureInfo enUS = new CultureInfo("en-US");
                if (client.Value.Name == clientLoan.Name && client.Value.LoanAmount == clientLoan.LoanAmount &&
                    client.Value.LoanTerm == clientLoan.LoanTerm && client.Value.FixedRate == clientLoan.FixedRate &&
                    client.Value.StartDate.ToString("MM/dd/yyyy") == clientLoan.StartDate.ToString("MM/dd/yyyy"))
                {
                    haveDuplicate = true;
                }
            }

            return haveDuplicate;
        }
        public bool DeleteClient(int clientId)
        {
            var isDeleted = false;

            ClientLoan = DatabaseRepository.GetClient(clientId);

            if (ClientLoan != null)
            {
                DatabaseRepository.DeleteClientLoan(clientId);
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}
