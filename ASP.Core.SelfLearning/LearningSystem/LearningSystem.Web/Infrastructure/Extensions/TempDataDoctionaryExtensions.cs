using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace LearningSystem.Web.Infrastructure.Extensions
{
    public static class TempDataDoctionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMsgKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataErrorMsgKey] = message;
        }
    }
}
