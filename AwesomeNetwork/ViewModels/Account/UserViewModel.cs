﻿using AwesomeNetwork.Models.Users;

namespace AwesomeNetwork.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<User>? Friends { get; set; }
        public UserViewModel(User user)
        {
            User = user;

        }

    }
}
