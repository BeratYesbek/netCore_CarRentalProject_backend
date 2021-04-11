using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public static class Messages
    {

        public static string ADD_MESSAGE = "Added successfully.";

        public static string DELETE_MESSAGE = "Deleted successfully.";

        public static string UPDATE_MESSAGE = "updated successfully.";

        public static string SUCCESS_MESSAGE = "This operation completed successfully";

        public static string ERROR_MESSAGE = "An error has occurred during the process";

        public static string AUTH_MESSAGE = "You have no any auth for this process.";

        public static string REGISTER_MESSAGE = "Registered successfully";

        public static string USER_NOT_FOUND_MESSAGE = "User not found";

        public static string USER_WRONG_PASSWORD_MESSAGE = "Wrong password";

        public static string USER_EXISTS_MESSAGE = "User already exists";

        public static string TOKEN_MESSAGE = "Access token created";



        /*---------------------------Custom business rule messages-------------------------------------------*/

        public static string CATEGORY_NOT_EXISTS = "this category has not exist";

        public static string RENTAL_FINDEKS_SCORE_NOT_ENOUGH = "Findeks score not enough";

        public static string CAR_IMAGE_COUNT_ERROR= "You can't add more picture";
    }
}
