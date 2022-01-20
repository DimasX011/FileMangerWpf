using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Project1;
using System.IO;

namespace Project1
{

    public partial class MainWindow : Window
    {
        List<string> fileFolder = new List<string>();
        bool secondEnter = false;
        Realize realize = new Realize();

        public MainWindow()
        {
            try
            {
                var appDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                InitializeComponent();
                pathfolderOne1.Text = appDir;
                GetAllComponent();
                foreach (var c in fileFolder)
                {
                    listfilesOne1.Items.Add(c);
                }
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }
        }

        private void GetAllComponent()
        {
            try
            {
                string[] files = Directory.GetFiles(pathfolderOne1.Text);
                string[] folders = Directory.GetDirectories(pathfolderOne1.Text);
                foreach (var c in folders)
                {
                    listfilesOne1.Items.Add("Папка:" + c);
                    listfilesTwo1.Items.Add("Папка:" + c);
                }
                foreach (var c in files)
                {
                    listfilesOne1.Items.Add("Файл:" + c);
                    listfilesTwo1.Items.Add("Файл:" + c);
                }
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (createFolderCheck.IsChecked == true)
                {
                    realize.CreateDirectory($"{oldnamefile1.Text}", pathfolderOne1.Text);
                    ListData();
                }
                if (createFileCheck.IsChecked == true)
                {
                    realize.Create($"{oldnamefile1.Text}", pathfolderOne1.Text);
                    ListData();
                }
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }
        }

        private void Data_Show(object sender, RoutedEventArgs e)
        {
            if (secondEnter == true)
            {
                ListData();
            }
            secondEnter = true;
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DeleteFolderCheck.IsChecked == true)
                {
                    realize.Deletefld(pathfolderOne1.Text, oldnamefile1.Text);
                    ListData();
                }
                if (DeleteFileCheck.IsChecked == true)
                {
                    realize.Delete(pathfolderOne1.Text, oldnamefile1.Text);
                    ListData();
                }
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Button_Click_Rename(object sender, RoutedEventArgs e)
        {
            try
            {
                if (renamefilecheck1.IsChecked == true)
                {
                    realize.ReName(pathfolderOne1.Text, oldnamefile1.Text, newfilename1.Text);
                }
                if (renamefoldercheck1.IsChecked == true)
                {
                    realize.RanameFolder(pathfolderOne1.Text, oldnamefile1.Text, newfilename1.Text);
                }
                ListData();
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Button_Click_Copy(object sender, RoutedEventArgs e)
        {
            try
            {
                if (filecheck1.IsChecked == true)
                {
                    realize.Copy(pathfolderOne1.Text, pathfolderMTwoTvink1.Text, oldnamefile1.Text);
                }
                if (foldercheck1.IsChecked == true)
                {
                    realize.folderCopy(pathfolderOne1.Text, pathfolderMTwoTvink1.Text, oldnamefile1.Text);
                }
                ListData();
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (calculatefile1.IsChecked == true)
                {
                    long value = realize.CalculateFile(pathfolderOne1.Text + "\\" + oldnamefile1.Text + ".txt");
                    MessageBox.Show($"Размер файла: {value} байт!");
                }
                if (calculatefolder1.IsChecked == true)
                {
                    long value = realize.FolderCalculateFile(pathfolderOne1.Text + "\\" + oldnamefile1.Text);
                    MessageBox.Show($"Размер папки: {value} байт!");
                }
                ListData();
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchfolder.IsChecked == true)
                {
                    string file = realize.FolderSearch(pathfolderOne1.Text, oldnamefile1.Text);
                    MessageBox.Show($"Путь файла: {file}");
                }
                if (searchfile.IsChecked == true)
                {
                    string file = realize.Search(pathfolderOne1.Text, oldnamefile1.Text);
                    MessageBox.Show($"Путь папки: {file}");
                }
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void Statistic_Data(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = realize.Strings(pathfolderOne1.Text, oldnamefile1.Text);
                int count1 = realize.Symbol(pathfolderOne1.Text, oldnamefile1.Text);
                int count2 = realize.Words(pathfolderOne1.Text, oldnamefile1.Text);
                int count3 = realize.SymbolProb(pathfolderOne1.Text, oldnamefile1.Text);
                MessageBox.Show($"Количество строк {count}, количество символов с пробелами {count3},количество символов {count1}, количество слов {count2}");
            }
            catch (DriveNotFoundException)
            {
                MessageBox.Show("Отказано в доступе!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл отсутствует в данном каталоге!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Проверьте правильность пути каталога!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("Длина пути файла превышает макисмальную длину! Выберете другой файл!");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Произошла ошибка доступа к файлу, пожалуйста перезапустите программу!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Файл защищен! Ограничние доступа данных");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Один из параметров доступа к файлу является недопустимым!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Используемые методы доступа к файлам устарели. Пожалуйста обновите программу!");
            }

        }

        private void ListData()
        {
            listfilesOne1.Items.Clear();
            listfilesTwo1.Items.Clear();
            GetAllComponent();
            foreach (var c in fileFolder)
            {
                listfilesOne1.Items.Add(c);
                listfilesTwo1.Items.Add(c);
            }
        }
    }
}
