namespace EstateManagment.Services
{
    public interface IHtmlToPdfConverter
    {
        byte[] Convert(string htmlCode);
    }
}
