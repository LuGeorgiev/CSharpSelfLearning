namespace Dogstagram.Server.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetName();

        string GetId();
    }
}
