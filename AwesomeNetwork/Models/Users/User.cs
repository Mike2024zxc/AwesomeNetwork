using Microsoft.AspNetCore.Identity;

namespace AwesomeNetwork.Models.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string? MidleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }

        public string Image { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public User()
        {
            Image = "https://thispersondoesnotexist.com";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}
