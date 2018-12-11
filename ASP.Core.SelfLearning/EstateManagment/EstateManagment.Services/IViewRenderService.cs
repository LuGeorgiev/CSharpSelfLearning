using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
