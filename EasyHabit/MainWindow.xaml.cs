using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using OxyPlot;
using OxyPlot.Wpf;

namespace EasyHabit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FMT = "MM/dd/yyyy";
        public DateTime latestAccomp;
        public List<HabitModel> listOfHabitModels;
        public DateTime today;
        public WeekDays day0;
        public WeekDays day1;
        public WeekDays day2;
        public WeekDays day3;
        public WeekDays day4;
        public int selectedItemIndex;

        public MainWindow()
        {
            InitializeComponent();
            //this.Closed += new EventHandler(MainWindow_Closed);
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;

            void MainWindow_Closed(object sender, EventArgs e)
            {
                foreach (HabitModel habit in listOfHabitModels)
                {
                    habit.IntoDB();
                    SqliteDataAccess.UpdateAll(habit);
                }
            }
            void MainWindow_Loaded(object sender, EventArgs e)
            {
                UpdateSource();
                today = DateTime.Now;
                try
                {
                    DateTime latestAccomp = LatestAccomp();
                }
                catch
                {
                    DateTime latestAccomp = today;
                }

                int difference = Convert.ToInt32(Math.Floor((today - latestAccomp).TotalDays));

                progresPlot.Model = ProgressPlotDefine1.ZeroCrossing();

                DataContext = this;

                ListofHabits.ItemsSource = listOfHabitModels;

                if (difference > 5)
                    difference = 5;
                foreach (HabitModel habit in listOfHabitModels)
                {
                    habit.ShiftForxDays(difference);
                }
                
                UpdateSource();

                day0 = new WeekDays(today);
                day1 = new WeekDays(today.AddDays(-1));
                day2 = new WeekDays(today.AddDays(-2));
                day3 = new WeekDays(today.AddDays(-3));
                day4 = new WeekDays(today.AddDays(-4));

                labelWeek0.Content = day0;
                labelWeek1.Content = day1;
                labelWeek2.Content = day2;
                labelWeek3.Content = day3;
                labelWeek4.Content = day4;

                labelDay0.Content = day0;
                labelDay1.Content = day1;
                labelDay2.Content = day2;
                labelDay3.Content = day3;
                labelDay4.Content = day4;

                labelCurrentDate.Content = day0;
            }
        }
        
        private void UpdateSource()
        {
            listOfHabitModels = SqliteDataAccess.LoadHabits();

            foreach (HabitModel habit in listOfHabitModels)
            {
                habit.FromDB();
            }
            ListofHabits.ItemsSource = listOfHabitModels;
        }
        private void BtnSort_Clk(object sender, RoutedEventArgs e)
        {
            var habits = SqliteDataAccess.LoadHabits();
            Console.WriteLine(habits[0].habitName);
            Console.WriteLine(habits.Count);
        }
        private void ResetTxtBox(TextBox txtBox)
        {
            txtBox.Text = "TextBox";
            txtBox.Foreground = Brushes.LightGray;
        }

        private void nameTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            nameTxtBox.Text = String.Empty;
            nameTxtBox.Foreground = App.Current.Resources["DarkGray"] as SolidColorBrush;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxtBox.Text;
            if ((name == "TextBox") || (name == "") || (name == " "))
                return;
            try
            {
                HabitModel habit = new HabitModel(name);
                SqliteDataAccess.SaveHabit(habit);
                UpdateSource();
                ListofHabits.ItemsSource = listOfHabitModels;
            }
            catch
            {
                ResetTxtBox(nameTxtBox);
            }
            finally
            {
                ResetTxtBox(nameTxtBox);
            }
        }
        private void RenameBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedItemIndex = ListofHabits.SelectedIndex;
                string oldName = listOfHabitModels[selectedItemIndex].habitName;
                string newName = nameTxtBox.Text;
                if (newName == "" | newName == " ")
                    return;
                SqliteDataAccess.UpdateName(oldName, newName);
                UpdateSource();
                
            }
            catch
            {
                ResetTxtBox(nameTxtBox);
            }
            finally
            {
                ResetTxtBox(nameTxtBox);
            }
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedItemIndex = ListofHabits.SelectedIndex;
            string name = listOfHabitModels[selectedItemIndex].habitName;
            SqliteDataAccess.DeleteHabit(name);
            UpdateSource();
        }
        private DateTime LatestAccomp()
        {
            var  datesList = new List<DateTime>();
            foreach (HabitModel habit in listOfHabitModels)
            {
                var innDatesList = new List<DateTime>();
                innDatesList.Add(habit.minus0Date);
                innDatesList.Add(habit.minus1Date);
                innDatesList.Add(habit.minus2Date);
                innDatesList.Add(habit.minus3Date);
                innDatesList.Add(habit.minus4Date);

                DateTime innLatestDate = innDatesList.Max(p => p);
                datesList.Add(innLatestDate);
            }
            DateTime latestDate = datesList.Max(p => p);
            return latestDate;
        }
    }
}
