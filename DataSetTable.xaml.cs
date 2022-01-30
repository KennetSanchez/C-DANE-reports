using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class DataSetTable: Window
    {
        private List<int> count;

        public DataSetTable(ObservableCollection<MainWindow.Info> c, List<int> count)
        {
            InitializeComponent();
            listViewDane.ItemsSource = c;
            this.count = count;
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnShowChart_Click(object sender, RoutedEventArgs e)
        {
            Chart c = new Chart(count);
            c.Show();
        }
    }

}
