

namespace EgnValidator.Services.Infrastructure
{
    public interface IWriter
    {
        void WriteLine(string contents);

        void Write(string contents);
    }
}
