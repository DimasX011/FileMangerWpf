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
using System.IO;

namespace Project1
{
    /// <summary>
    /// Логика взаимодействия для Datafiles.xaml
    /// </summary>
    public partial class Datafiles : Window
    {
        List<string> fileFolder = new List<string>();
        public Datafiles(string path)
        {
            InitializeComponent();
            Path.Text = path;
        }

        private void ChangedPath(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DataChange(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Data_Show(object sender, RoutedEventArgs e)
        {
           GetAllComponent();
           foreach(var c in fileFolder)
            {
                Data.Items.Add(c);
            }
        }

        private void GetAllComponent()
        {
            string[] files = Directory.GetFiles(Path.Text);
            string[] folders = Directory.GetDirectories(Path.Text);

            foreach (var c in folders)
            {
                Data.Items.Add("Папка:" + c);
            }
            foreach (var c in files)
            {
                Data.Items.Add("Файл:" + c);
            }
            
        }

        private void Data_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Clear_List(object sender, RoutedEventArgs e)
        {
            Data.Items.Clear();
        }
    }
}
