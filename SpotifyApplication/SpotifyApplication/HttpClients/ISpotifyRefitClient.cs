using Refit;

namespace SpotifyApplication.HttpClients
{
    [Headers("Content-Type : application/json")]
    public interface ISpotifyRefitClient
    {
        //[Get("/artists")]
        //Task<ApiResponse<IEnumerable<SaleReportResponseResult>>> GetSaleReports(int startDate, string finishDate);
    }
}
