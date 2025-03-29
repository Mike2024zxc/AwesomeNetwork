using AwesomeNetwork.Models;

namespace AwesomeNetwork.ViewModels.Account
{
    public class SearchViewModel
    {
        public List<UserWithFriendExt> UserList { get; set; }
        public SearchViewModel()
        {
            UserList = new List<UserWithFriendExt>();
        }
    }
}
