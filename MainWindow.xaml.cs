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

    public partial class MainWindow : Window
    {
        private String separator;
        public MainWindow()
        {
            separator = ",";
            InitializeComponent();

        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|XML files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                fileChooserPane.Visibility = Visibility.Collapsed;
                try
                {
                    readData(openFileDialog.FileName);
                }

                catch (FileNotFoundException exc)
                {
                    Console.WriteLine(exc.ToString());
                }
            }
        }

        public class Info
        {
            public string Tipo { get; set; }
            public string CDDepartamento { get; set; }
            public string Departamento { get; set; }
            public string CDMunicipio { get; set; }
            public string Municipio { get; set; }

        }

        String[] line = new String[5];
        int islands = 0, towns = 0, nonMunicipalizedAreas = 0;


        private void readData(String path)
        {
            String[] lines = File.ReadAllLines(path);
            ObservableCollection<Info> c = new ObservableCollection<Info>();
            for (int i = 1; i < 1121; i++)
            {
                line = lines[i].Split(separator);
                c.Add(new Info() { Tipo = line[4], CDDepartamento = line[0], Departamento = line[2], CDMunicipio = line[1], Municipio = line[3] });

                if (line[4].Equals("Municipio"))
                {
                    towns++;
                }
                else if (line[4].Equals("Isla"))
                {
                    islands++;
                }
                else
                {
                    nonMunicipalizedAreas++;
                }
            }

            var count = getTypesCount();

            DataSetTable dst = new DataSetTable(c, count);
            this.Close();
            dst.Show();
        }

        

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

        }

        public List<String> types { get; set; } 
        private List<String> getTypes()
        {
            return new List<String>() { "Islas", "Municipios", "Áreas no municipalizadas" };
        }

        public List<int> typesCount { get; set; }
        public List<int> getTypesCount()
        {         
            var count = new List<int> { islands, towns, nonMunicipalizedAreas};
            return count;
        }
    }
}

