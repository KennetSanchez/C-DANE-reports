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
using System.Windows.Shapes;

namespace C_DANE_reports
{
    public partial class Chart : Window
    {
        public Chart(List<int> count)
        {
            InitializeComponent();

            islandsBar.Width = count[0];
            townsBar.Width = count[1];
            nonMunicipalizedAreaBar.Width = count[2];

            islandsAmount.Content = count[0];
            townsAmount.Content = count[1];
            nonMunicipalizedAmount.Content = count[2];
        }
    }
}
