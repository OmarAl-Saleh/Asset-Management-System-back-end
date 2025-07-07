
using Microsoft.AspNetCore.Mvc;


namespace AssetSystem.Common.Responses
{
    public static class WrappedOkObjectResultCls
    {
        public static OkObjectResult Success(object objResult)
        {
            return new OkObjectResult(new JsonModel
            {
                obj = objResult,
                code = 1,
                strMessage = ""
            });
        }

        public static OkObjectResult Error(string strErrMessage)
        {
            return new OkObjectResult(new JsonModel
            {
                obj = null,
                code = 0,
                strMessage = strErrMessage
            });
        }
    }
}

