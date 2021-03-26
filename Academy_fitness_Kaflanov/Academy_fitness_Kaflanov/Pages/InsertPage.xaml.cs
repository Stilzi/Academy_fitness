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
    /// Логика взаимодействия для InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Page
    {
        public InsertPage()
        {
            InitializeComponent();

            trainercmb.ItemsSource = dbContext.db.Trainer.Select(item => item.Name).ToList();
            coursecmb.ItemsSource = dbContext.db.Course.Select(item => item.Title).ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            var trainerins = dbContext.db.Trainer.FirstOrDefault(item => item.Name == trainercmb.Text);
            var courseins = dbContext.db.Course.FirstOrDefault(item => item.Title == coursecmb.Text);

            CourseRegistration insert = new CourseRegistration()
            {
                TrainerId = trainerins.Id,
                CourseId = courseins.Id,
                CreatedDate = Convert.ToDateTime(datetxb.SelectedDate),
                IsDone = isdonetxb.Text,
                TotalPoint = Convert.ToInt32(pointxb.Text),
                Comment = Commenttxb.Text
            };
            dbContext.db.CourseRegistration.Add(insert);
            dbContext.db.SaveChanges();
            MessageBox.Show("Данные добавлены");
        }
    }
}
