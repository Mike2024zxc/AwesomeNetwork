using AwesomeNetwork.Models.Users;
using AwesomeNetwork.ViewModels.Account;

namespace AwesomeNetwork.Extentions
{
    public static class UserFromModel
    {
        public static User Convert(this User user, EditViewModel usereditvm) 
        {
            user.Image = usereditvm.Image;
            user.LastName = usereditvm.LastName;
            user.MidleName = usereditvm.MidleName;
            user.FirstName = usereditvm.FirstName;
            user.Email = usereditvm.Email;
            user.DateBirth = usereditvm.DateBirth;
            user.UserName = usereditvm.UserName;
            user.Status = usereditvm.Status;
            user.About = usereditvm.About;

            return user;
        }
    }
}
