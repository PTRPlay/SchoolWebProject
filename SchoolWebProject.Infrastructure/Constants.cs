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

        public static readonly int minutesToCookiesExpirate = 20;

        public static readonly Dictionary<string, string> AdminPermissions = new Dictionary<string, string>() {
            {"Вчителі","teachers"},
            {"Предмети", "subjects"},
            {"Учні", "pupils"},
            {"Класи", "groups"},
            {"Розклад", "schedule"},
            {"Журнал", "journal"},
            {"Навчальний рік", "holidays"},
            {"Новини", "newsAdminService"},
            {"Контакти", "schoolService"}
        };

        public static readonly Dictionary<string, string> TeacherPermissions = new Dictionary<string, string>() {
            {"Учні", "pupils"},
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
    }
}
