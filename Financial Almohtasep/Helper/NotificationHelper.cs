using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Financial_Almohtasep.Helper
{
    public static class NotificationHelper
    {
        /// <summary>
        /// Sets a success or error message in TempData for displaying alerts.
        /// </summary>
        /// <param name="tempData">The TempData dictionary to store the message.</param>
        /// <param name="success">Determines if the message is a success or error message.</param>
        /// <param name="message">The message content to display.</param>
        public static void Alert(ITempDataDictionary tempData, bool success, string message)
        {
            if (success)
                tempData["SuccessMessage"] = message;
            else
                tempData["ErrorMessage"] = message;
        }
    }
}

