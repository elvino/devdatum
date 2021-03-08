namespace DevDatum.Domain.Entities
{
    public class Git
    {
        public Git(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public string ShowGit()
        {
            return Url;
        }
    }
}
