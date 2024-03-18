namespace TechnicalInstance.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int VoteCount { get; set; }
        public string OriginalTitle { get; set; }
        public string OverView { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
