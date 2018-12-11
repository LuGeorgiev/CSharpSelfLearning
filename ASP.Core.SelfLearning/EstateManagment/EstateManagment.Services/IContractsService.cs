using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IContractsService
    {
        Task<byte[]> DownloadAsync(int id);

        Task<bool> DeleteAsync(int id);
    }
}
