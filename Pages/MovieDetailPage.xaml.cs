using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace pr14V2.Pages
{

    
    public class SessionDisplay
    {
        public int SessionId { get; set; }
        public DateTime SessionTime { get; set; }
        public string HallName { get; set; }
    }

    public partial class MovieDetailPage : Page
    {
        private Movie movie;
       

        public MovieDetailPage(Movie selectedMovie)
        {
            InitializeComponent();
            movie = selectedMovie;
            ShowMovieInfo();
            ShowSessions();
        }

        
        private void ShowMovieInfo()
        {
            MovieTitle.Text = movie.MovieName;
            MovieRating.Text = $"★ {movie.Rating}";
            MovieAge.Text = $"{movie.AgeRating}+";
            MovieDescription.Text = movie.Description;

            
            if (!string.IsNullOrEmpty(movie.Image))
            {
                MoviePoster.Source = new BitmapImage(new Uri(movie.Image, UriKind.RelativeOrAbsolute));
            }
        }

       
        private void ShowSessions()
        {   
            
            var sessions = Core.Context.Sessions
                .Where(s => s.MovieId == movie.Id)
                .Where(s => s.StartDateTime >= DateTime.Now)
                .OrderBy(s => s.StartDateTime)
                .ToList();

           
            List<SessionDisplay> displayList = new List<SessionDisplay>();

            foreach (var s in sessions)
            {
                displayList.Add(new SessionDisplay
                {
                    SessionId = s.Id,
                    SessionTime = s.StartDateTime ?? DateTime.Now,
                    HallName = "Зал " + s.HallId
                });
            }

            SessionsList.ItemsSource = displayList;
        }

       
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SelectSession_Click(object sender, RoutedEventArgs e)
        {
            if (Core.CurrentUser != null)
            {
                MessageBox.Show("Дальше мне лень");
            }
            else
            {
                MessageBox.Show("Для выбора сеанса необходимо авторизоваться");
            }

        }
    }
}