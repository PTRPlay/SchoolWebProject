using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Infrastructure
{
    public class Constants
    {
        public static readonly string LoginError = "Невірні логін або пароль";

        public static readonly string EmailSubject = "Ваш логін та пароль для аккаунта на сайті SchoolWebProject!";

        public static readonly string EmailMessage = "Ваш логін і пароль для входу на сайт SchoolWebProject такі : ";

        public static readonly int MinutesToCookiesExpirate = 20;

        public static readonly Dictionary<string, string> AdminPermissions = new Dictionary<string, string>() {
            {"Вчителі", "teachers"},
            {"Предмети", "subjects"},
            {"Учні", "pupils"},
            {"Батьки", "parents"},
            {"Класи", "groups"},
            {"Розклад", "schedule"},
            {"Журнал", "journal"},
            {"Навчальний рік", "holidays"},
            {"Новини", "newsAdminService"},
            {"Контакти", "schoolService"}
        };

        public static readonly Dictionary<string, string> TeacherPermissions = new Dictionary<string, string>() {
            {"Учні", "pupils"},
            {"Батьки", "parents"},
            {"Класи", "groups"},
            {"Розклад", "schedule"},
            {"Журнал", "journal"},
            {"Новини", "newsService"},
            {"Контакти", "schoolService"}
        };

        public static readonly Dictionary<string, string> PupilPermissions = new Dictionary<string, string>() {
            {"Щоденник", "diaryService"},
            {"Розклад", "schedule"},
            {"Журнал", "journal"},
            {"Новини", "newsService"},
            {"Контакти", "schoolService"}
        };

        public static readonly Dictionary<string, string> ParentPermissions = new Dictionary<string, string>() {
            {"Вчителі","teachers"},
            {"Розклад", "schedule"},
            {"Журнал", "journal"},
            {"Новини", "newsService"},
            {"Контакти", "schoolService"}
        };

        public enum UserRoles 
        { 
            None, 
            Admin, 
            Teacher, 
            Pupil, 
            Parent 
        };

        public static byte[] StringToByteArray(string input)
        {
            byte[] output = new byte[input.Length * sizeof(char)];
            System.Buffer.BlockCopy(input.ToCharArray(), 0, output, 0, output.Length);
            return output;
        }

        public static string ByteArrayToString(byte[] input)
        {
            char[] output = new char[input.Length / sizeof(char)];
            System.Buffer.BlockCopy(input, 0, output, 0, input.Length);
            return new string(output);
        }
    }
}
