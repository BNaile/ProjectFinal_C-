using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BaseMessage
{
    public static class UIMessages
    {
        public const string ADDED_MESSAGE = "Məlumat Uğurla Əlavə edildi";
        public const string UPDATE_MESSAGE = "Məlumat Uğurla Yeniləndi";
        public  const string Deleted_MESSAGE = "Məlumat Uğurla Silindi";

        public const string DEFAULT_SUCCESS_UPDATE_MESSAGE = "Succes Update";
        public const string DEFAULT_SUCCESS_NEW_MESSAGE = "Succes Added";
        public const string DEFAULT_SUCCESS_DELETE_MESSAGE = "Succes Deleted";
        public const string DEFAULT_WARNING_BACK_MESSAGE = "You will not be able to return!";
        public const string DEFAULT_WARNING_CONFIRM_MESSAGE = "Are You Sure?";

        public static readonly string DEFAULT_MINIMUM_SYMBOL_COUNT_3_MESSAGE = "*Can't enter less than 3 characters!";
        public static readonly string DEFAULT_MINIMUM_SYMBOL_COUNT_6_MESSAGE = "*Can't enter less than 6 characters!";
        public static readonly string DEFAULT_MINIMUM_SYMBOL_COUNT_10_MESSAGE = "*Can't enter less than 10 characters!";


        public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_2000_MESSAGE = "*Can't enter more than 2000 characters!";
        public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_500_MESSAGE = "*Can't enter more than 500 characters!";
        public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_100_MESSAGE = "*Can't enter more than 100 characters!";
        public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_150_MESSAGE = "*Can't enter more than 150 characters!";
       public static readonly string DEFAULT_MAXIMUM_SYMBOL_COUNT_200_MESSAGE = "*Can't enter more than 200 characters!";

        public static readonly string DEFAULT_INVALID_EMAIL_ADRESS = "*Invalid Email!";
        public static readonly string DEFAULT_NOT_EMPTY_MESSAGE = "*Can't be left blank!";
        public static readonly string DEFAULT_ERROR_DUBLICATE_DATA = "*This information is already in the database!";
    }
}
