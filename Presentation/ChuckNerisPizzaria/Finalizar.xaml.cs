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
    /// Interação lógica para Finalizar.xam
    /// </summary>
    public partial class Finalizar : UserControl
    {
        public Finalizar(string tipo, string valor, ImageSource img)
        {
            InitializeComponent();

            Preco.Text = valor;
            Tipo.Text = tipo;
            IT.Source = img;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new Cardapio());
        }

        private void FinalizarClick(object sender, RoutedEventArgs e)
        {
            IncludeAuthorization();
        }

        private async void IncludeAuthorization()
        {
            var card = new AuthorizationVO
            {
                Number = Convert.ToInt64(Numero.Text),
                ExpirationDate = DateTime.Now.AddDays(480),
                SecureCode = Convert.ToInt32(CodSeguranca.Text),
                CardholderName = Nome.Text
            };

            decimal AmountValue = Convert.ToDecimal(Preco.Text.Replace("R$", String.Empty).Trim());

            var trans = new TransactionVO
            {
                Amount = AmountValue,
                QuantityPlots = Convert.ToInt32(Parcelas.Text),
                PlotValue = AmountValue / Convert.ToInt32(Parcelas.Text),
                Type = Convert.ToInt32(Parcelas.Text) > 1 ? "Parcelado" : "Vista",
                Token = Convert.ToString(Guid.NewGuid())
            };

            card.Transcao = trans;

            using (var client = new HttpClient())
            {
                var serializedAuth = JsonConvert.SerializeObject(card);
                var content = new StringContent(serializedAuth, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:51356/api/Card/GetAuthorization", content);

                if (result.IsSuccessStatusCode)
                {
                    var Cards = await result.Content.ReadAsStringAsync();
                    var retorno = JsonConvert.DeserializeObject<ResultAuthorization[]>(Cards).ToList();

                    MessageBox.Show(retorno[0].MessageReturn);

                    ClearFields();

                }
            }
        }
        void ClearFields()
        {
            Bandeira.Text = string.Empty;
            Numero.Text = string.Empty;
            Tipo.Text = string.Empty;
            CodSeguranca.Text = string.Empty;
            Nome.Text = string.Empty;
            Parcelas.Text = string.Empty;

            Nome.Focus();
        }
    }
}
