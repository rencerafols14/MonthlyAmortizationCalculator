using MonthlyAmortizationCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyAmortizationCalculator.Services
{
    public class Repository
    {
        public Repository()
        {
            //InitializeDatabase();
        }

        /// <summary>
        /// Get all clients in the database
        /// </summary>
        /// <returns>List of clients</returns>
        public Dictionary<int, ClientLoan> GetAllClients()
        {
            return Database.ClientLoans;
        }

        public void DeleteClientLoan(int clientId)
        {
            Database.ClientLoans.Remove(clientId);
        }
        public void AddClientLoan(ClientLoan clientLoan)
        {
            int newKey = Database.ClientLoans.Keys.Max() + 1;
            Database.ClientLoans.Add(newKey, clientLoan);
        }
        public void UpdateClientLoan(int clientId)
        {
            Database.ClientLoans[clientId] = GetClient(clientId);
        }
        public ClientLoan GetClient(int clientId)
        {
            return Database.ClientLoans[clientId] ?? null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeDatabase()
        {
            Database.ClientLoans.Add(1, new ClientLoan("Juan Dela Cuz", 30000, 4, Convert.ToDateTime(DateTime.Now), 5));
            Database.ClientLoans.Add(2, new ClientLoan("Maria Dela Cuz", 30000, 3, Convert.ToDateTime(DateTime.Now), 4));
            Database.ClientLoans.Add(3, new ClientLoan("John Doe", 30000, 2, Convert.ToDateTime(DateTime.Now), 3));
            Database.ClientLoans.Add(4, new ClientLoan("Jane Doe", 30000, 1, Convert.ToDateTime(DateTime.Now), 2));
        }
    }
}
