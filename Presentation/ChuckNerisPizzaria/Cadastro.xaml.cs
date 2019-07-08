using Newtonsoft.Json;
using Stone.Integration.BusinessEntities;
using Stone.Integration.Others;
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
    public partial class Cadastro : UserControl
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void CadastrarCartao(object sender, RoutedEventArgs e)
        {
            IncludeAuthorization();
        }
        private async void IncludeAuthorization()
        {
            string pwd = Secure.Instance.Encrypt(Senha.Text);

            var card = new AuthorizationVO
            {
                ActiveCard = StatusCartao.Text,
                CardBrand = Bandeira.Text,
                Number = Convert.ToInt64(Numero.Text),
                ExpirationDate = DateTime.Now.AddDays(480),
                Limit = Convert.ToDecimal(Limite.Text),
                TypeCard = Tipo.Text,
                SecureCode = Convert.ToInt32(CodSeguranca.Text),
                CardholderName = Nome.Text,
                Password = pwd
            };

            using (var client = new HttpClient())
            {
                var serializedAuth = JsonConvert.SerializeObject(card);
                var content = new StringContent(serializedAuth, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:51356/api/Card/IncludeCard", content);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cartão cadastrado com sucesso!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Ocorreu uma falha no cadastro do cartão!");
                }
            }
        }

        void ClearFields()
        {
            StatusCartao.Text = string.Empty;
            Bandeira.Text = string.Empty;
            Numero.Text = string.Empty;
            Limite.Text = string.Empty;
            Tipo.Text = string.Empty;
            CodSeguranca.Text = string.Empty;
            Nome.Text = string.Empty;
            Senha.Text = string.Empty;

            Nome.Focus();
        }

    }
}
