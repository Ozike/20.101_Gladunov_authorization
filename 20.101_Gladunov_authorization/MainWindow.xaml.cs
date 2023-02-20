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
using _20._101_Gladunov_authorization.Entites;

namespace _20._101_Gladunov_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Login { get; private set; }
        public object Password { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            string password = pb_password.Password.ToString();
            string login = tb_login.Text.ToString();
            Users users = new Users();

            try
            {
                users = Entities.GetContext().Users.Where(x => x.Login == Login && x.Password == Password).FirstOrDefault();
                if (users != null)
                {
                    if (users.GetNameRole == "Администратор")
                    {
                        Result("Администратор");
                    }
                    else if (users.GetNameRole == "Менеджер")
                    {
                        Result("Менеджер");
                    }
                    else if (users.GetNameRole == "Клиент")
                    {
                        Result("Клиент");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");

                }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

        }

        public string Result(string str)
        {
            MessageBox.Show($"Добро пожаловать! Ваша роль: {str}");
            return str;
        }


    }
    }
}
