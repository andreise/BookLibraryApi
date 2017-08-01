using System;

namespace BookLibraryApi.Controllers
{
    public static class ControllerExceptionExtensions
    {
        public static string GetExtendedMessage(this Exception ex)
        {
            if (ex.InnerException is null)
                return ex.Message;

            return $"{ex.Message} ({ex.InnerException.Message})";
        }
    }
}
