using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfOsztalyzas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fajlNev = "naplo.txt";
        List<Osztalyzat> jegyek = new List<Osztalyzat>();
        public MainWindow()
        {
            InitializeComponent();
            sliJegy.Value = 5;

        }

        private void OsztalyzatokBetoltese(string fajlNev)
        {
            StreamReader sr = new StreamReader(fajlNev);
            while (!sr.EndOfStream)
            {
                string[] mezok = sr.ReadLine().Split(";");
                Osztalyzat ujJegy = new Osztalyzat(mezok[0], mezok[1], mezok[2], int.Parse(mezok[3]));
                jegyek.Add(ujJegy);
            }
            sr.Close();
            dgJegyek.ItemsSource = jegyek;
            MessageBox.Show("Az állomány beolvasása befejeződött!");

        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string csvSor = $"{txtNev.Text};{datDatum.Text};{cboTantargy.Text};{sliJegy.Value}";
            StreamWriter sw = new StreamWriter(fajlNev, true);
            sw.WriteLine(csvSor);
            sw.Close();
            MessageBox.Show("Az osztályzat mentésre került.");
        }

        private void sliJegy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblJegy.Content = Math.Round(sliJegy.Value);
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            OsztalyzatokBetoltese(fajlNev);
        }
    }
}
