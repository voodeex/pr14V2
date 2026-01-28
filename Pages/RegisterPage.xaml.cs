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

namespace pr14V2.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public List<User> users = Core.Context.Users.ToList();
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstRegPassTextBox.Text == SecondRegPassTextBox.Text && !string.IsNullOrWhiteSpace(RegLoginTextBox.Text))
            {
                var newUser = new User
                {
                    Login = RegLoginTextBox.Text,
                    Password = FirstRegPassTextBox.Text,
                    CreatedAt = DateTime.Now
                };

                Core.Context.Users.Add(newUser);
                Core.Context.SaveChanges();

                NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Пароли не совпадают или не введен логин");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
