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
    /// Логика взаимодействия для MainLoginPage.xaml
    /// </summary>
    public partial class MainLoginPage : Page
    {
        public List<Movie> movies = Core.Context.Movies.ToList();
        public MainLoginPage()
        {
            InitializeComponent();
            prod.ItemsSource = movies;
        }
        
        

        private void SortFilm(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedIndex == 0)
            {
                List<Movie> moviesRate = movies.OrderByDescending(u => u.Rating).ToList();
                prod.ItemsSource = moviesRate;
            }
            else
            {
                List<Movie> moviesName = movies.OrderByDescending(u => u.MovieName).ToList();
                prod.ItemsSource = moviesName;
            }
        }

        private void SearchFilm(object sender, TextChangedEventArgs e)
        {
            List<Movie> moviesSearch = movies.Where(p => p.MovieName.ToLower().Contains(Search.Text.ToLower())).ToList();
            prod.ItemsSource = moviesSearch;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
