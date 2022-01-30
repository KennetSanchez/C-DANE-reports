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
        private ObservableCollection<MainWindow.Info> oCollection;
        private List<MainWindow.Info> sortedList;
        private int[] ranges;

        public DataSetTable(ObservableCollection<MainWindow.Info> oCollection, List<int> count)
        {
            InitializeComponent();
            ranges = new int[28];
            Array.Fill(ranges, -2, 0, 28);
            ranges[0] = -1;
            this.oCollection = oCollection;
            listViewDane.ItemsSource = oCollection;
            this.count = count;
            sortedList = oCollection.ToList();
            sortedList.Sort(Compare);
            searchRanges();
        }

        public void searchRanges()
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                char ch = sortedList[i].getMunicipio().ToLower().First();
                switch (ch)
                {
                    case 'a':
                        ranges[1] = i;
                        break;
                    case 'b':
                        ranges[2] = i;
                        break;
                    case 'c':
                        ranges[3] = i;
                        break;
                    case 'd':
                        ranges[4] = i;
                        break;
                    case 'e':
                        ranges[5] = i;
                        break;
                    case 'f':
                        ranges[6] = i;
                        break;
                    case 'g':
                        ranges[7] = i;
                        break;
                    case 'h':
                        ranges[8] = i;
                        break;
                    case 'i':
                        ranges[9] = i;
                        break;
                    case 'j':
                        ranges[10] = i;
                        break;
                    case 'k':
                        ranges[11] = i;
                        break;
                    case 'l':
                        ranges[12] = i;
                        break;
                    case 'm':
                        ranges[13] = i;
                        break;
                    case 'n':
                        ranges[14] = i;
                        break;
                    case 'ñ':
                        ranges[15] = i;
                        break;
                    case 'o':
                        ranges[16] = i;
                        break;
                    case 'p':
                        ranges[17] = i;
                        break;
                    case 'q':
                        ranges[18] = i;
                        break;
                    case 'r':
                        ranges[19] = i;
                        break;
                    case 's':
                        ranges[20] = i;
                        break;
                    case 't':
                        ranges[21] = i;
                        break;
                    case 'u':
                        ranges[22] = i;
                        break;
                    case 'v':
                        ranges[23] = i;
                        break;
                    case 'w':
                        ranges[24] = i;
                        break;
                    case 'x':
                        ranges[25] = i;
                        break;
                    case 'y':
                        ranges[26] = i;
                        break;
                    case 'z':
                        ranges[27] = i;
                        break;
                }
            }
        }

        public int Compare(MainWindow.Info a, MainWindow.Info b)
        {
            String aS = a.getMunicipio();
            String bS = b.getMunicipio();
            return aS.CompareTo(bS);
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
           char selectedChar = cmbLetter.SelectedIndex.ToString().ToUpper().FirstOrDefault();
            int selectedIndex = cmbLetter.SelectedIndex;
            if (selectedIndex != null)
            {
                int aux = ranges[selectedIndex]+1;
                int lCount = ranges[selectedIndex+1] - ranges[selectedIndex];
                if(ranges[selectedIndex+1] + 1 >= 0) 
                {
                    int auxSelectedIndex = selectedIndex;
                    while(aux < 0)
                    {
                        auxSelectedIndex--;
                        aux= ranges[auxSelectedIndex] + 1;
                        lCount = ranges[selectedIndex + 1] - aux-1;
                    }
                    List<MainWindow.Info> letterList = sortedList.GetRange(aux, lCount);
                    listViewDane.ItemsSource = new ObservableCollection<MainWindow.Info>(letterList);
                }
                else
                {
                    listViewDane.ItemsSource=new ObservableCollection<MainWindow.Info>(sortedList);
                    MessageBox.Show("No hay resultados");
                }
            }
        }

        private void BtnShowChart_Click(object sender, RoutedEventArgs e)
        {
            Chart ch = new Chart(count);
            ch.Show();
        }
    }

}
