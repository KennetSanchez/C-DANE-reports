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
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace C_DANE_reports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                fileChooserPane.Visibility = Visibility.Collapsed;
                tablePane.Visibility = Visibility.Visible;
                readData(openFileDialog.FileName);
            }
        }

        public class Info
        {
            public string Region { get; set; }
            public string CDRegion { get; set; }
            public string Departamento { get; set; }
            public string CDDepartamento { get; set; }
            public string Municipio { get; set; }

        }

        private void readData(String path)
        {
            String[] lines = File.ReadAllLines(path);
            ObservableCollection<Info> c = new ObservableCollection<Info>();
            c.Add(new Info() { Region = "ejemplo", CDRegion = "ejemplo2", Departamento = "ejemplo3", CDDepartamento = "awfnoawf", Municipio = "awfaf" });
            listViewDane.ItemsSource = c;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
