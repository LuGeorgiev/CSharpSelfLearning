
namespace LearningSystem.Web.Infrastructure.Extensions
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
