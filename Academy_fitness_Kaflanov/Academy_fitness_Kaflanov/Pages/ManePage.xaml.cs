using Academy_fitness_Kaflanov.Class;
using Academy_fitness_Kaflanov.Model;
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

namespace Academy_fitness_Kaflanov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManePage.xaml
    /// </summary>
    public partial class ManePage : Page
    {
        public ManePage()
        {
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            dbContext.db.SaveChanges();
            MessageBox.Show("Данные отредактированы");
            //Редактирование
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var del = (CourseRegistration)DataView.SelectedItem;
            dbContext.db.CourseRegistration.Remove(del);
            dbContext.db.SaveChanges();
            DataView.ItemsSource = dbContext.db.CourseRegistration.ToList();
            MessageBox.Show("Данные удалены");
            //Удаление
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = dbContext.db.CourseRegistration.ToList();
            //Вывод
        }

        private void FiltrBtn_Checked(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = dbContext.db.CourseRegistration.Where(item => item.IsDone.Contains("Да")).ToList();
            //Фильтрация по завершенным курсам
        }

        private void FiltrBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = dbContext.db.CourseRegistration.ToList();
        }
    }
}
