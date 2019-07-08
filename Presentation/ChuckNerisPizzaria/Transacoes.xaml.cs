using Newtonsoft.Json;
using Stone.Integration.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChuckNerisPizzaria
{
    /// <summary>
    /// Interação lógica para Cardapio.xam
    /// </summary>
    public partial class Transacoes : UserControl
    {
        public Transacoes()
        {
            InitializeComponent();
            GetAllTransactions();
        }

        private async void GetAllTransactions()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:51356/api/Transactions/GetAllTransactions"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var Transactions = await response.Content.ReadAsStringAsync();
                        var retorno = JsonConvert.DeserializeObject<TransactionVO[]>(Transactions).ToList();

                        grdTransactions.ItemsSource = retorno;
                    }
                }
            }
        }
    }
}
