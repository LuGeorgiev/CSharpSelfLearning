using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EstateManagment.Web.Common.Extensions
{
    public static class TempDataDictionaryExtension
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
