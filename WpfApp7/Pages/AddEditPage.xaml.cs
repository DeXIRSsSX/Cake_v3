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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Tovar _currentTovar = new Tovar();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentTovar;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(string.IsNullOrWhiteSpace(_currentTovar.name))
            
                errors.AppendLine("Напишите название для товара");
            
            if (_currentTovar.quantity < 1 || _currentTovar.quantity > 20000 )
            
                errors.AppendLine("Значение либо меньше 1, либо больше 20000");
            
            if (string.IsNullOrWhiteSpace(_currentTovar.description)) 
            
                errors.AppendLine("Напишите описание");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTovar.id_tovar == 0)
            
                caaakeEntities.GetContext().Tovars.Add(_currentTovar); 
            try
            {
                caaakeEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
