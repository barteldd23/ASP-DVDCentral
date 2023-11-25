namespace DDB.DVDCentral.UI.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Director> Directors { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Format> Formats { get; set; }
    }
}
