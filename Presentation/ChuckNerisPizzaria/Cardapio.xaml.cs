using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class Cardapio : UserControl
    {
        public Cardapio()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonType = (sender as Button).Name;

            GridMain.Children.Clear();
            GridPrincipal.Children.Clear();

            switch (buttonType)
            {
                case "T1":
                    GridPrincipal.Children.Add(new Finalizar(TipoPizzaT1.Text, PrecoT1.Text, IT1.Source));
                    break;
                case "T2":
                    GridPrincipal.Children.Add(new Finalizar(TipoPizzaT2.Text, PrecoT2.Text, IT2.Source));
                    break;
                case "T3":
                    GridPrincipal.Children.Add(new Finalizar(TipoPizzaT3.Text, PrecoT3.Text, IT3.Source));
                    break;
                default:
                    break;
            }
        }
    }
}
