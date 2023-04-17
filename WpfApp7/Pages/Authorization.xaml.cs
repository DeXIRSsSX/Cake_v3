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

namespace WpfApp7.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // здесь вы можете использовать свой собственный метод проверки данных пользователя
            bool isValid = CheckLoginCredentials(username, password);

            if (isValid)
            {
                // при успешной авторизации перенаправляем пользователя на другую страницу               
                NavigationService.Navigate(new katalog());
            }
            else
            {
                MessageBox.Show("Неверный Email или пароль.");
            }
        }

        public bool CheckLoginCredentials(string username, string password)
        {
            // создаем массив пользователей и паролей
            string[] users = { "123", "nigger", "user3" };
            string[] passwords = { "123", "adolif_gitler", "password3" };

            // ищем введенное имя пользователя и пароль в массивах
            for (int i = 0; i < users.Length; i++)
            {
                if (username == users[i] && password == passwords[i])
                {
                    return true; // данные верны
                }
            }

            return false; // данные неверны
        }
    }
}
