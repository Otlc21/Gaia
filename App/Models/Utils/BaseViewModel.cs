namespace App.Models.Utils
{
    public class BaseViewModel
    {
        public int Page { get; set; }
        public int TotalPages { get { return Total % Take == 0 ? Total / Take
                : (Total / Take) + 1; } }
        public int Total { get; set; }
        public int Take { get; set; } = 10;
        public int Skip { get { return Page <= 1 ? 0 : (Page - 1) * Take; } }
    }
}
