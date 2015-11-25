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

        public enum UserRoles { None, Admin, Teacher, Pupil, Parent };
    }
}
