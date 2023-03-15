using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1;
namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// 

    public partial class Window1 : Window
    {
        public ObservableCollection<Teacher> IData = new ObservableCollection<Teacher>();

        public int ID = 1;

        public Window1()
        {
            InitializeComponent();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Name = name.Text,
                phonenumber = phone.Text,
                Age = years.Text,
                ID = ID,
            };
            ID += 1;
            IData.Add(teacher);
        }


        private void save_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonSerializer.Serialize<ObservableCollection<Teacher>>(IData);
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Filter = "Json files (*.json)|*.json";

            saveFileDialog.ShowDialog();
            if (string.IsNullOrEmpty(saveFileDialog.FileName))
                return;
            File.WriteAllText(saveFileDialog.FileName, json);
            this.Close();

        }

    }
}
