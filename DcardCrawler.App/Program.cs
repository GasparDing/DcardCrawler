using DcardCrawler.App.Data.Service;

namespace DcardCrawler.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadService readService = new ReadService();
            var models = readService.ReadFromForums();
        }
    }
}