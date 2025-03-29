using AwesomeNetwork.Models.Users;
using AwesomeNetwork.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AwesomeNetwork.Data.Repository
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db) : base(db)
        {

        }
        public void AddFriend(User target, User friend)
        {
            if (target.Id == friend.Id)
            {
                return;
            }


            var existingFriendship = Set.AsEnumerable().FirstOrDefault(x =>
                (x.UserId == target.Id && x.CurrentFriendId == friend.Id) ||
                (x.UserId == friend.Id && x.CurrentFriendId == target.Id));

            if (existingFriendship == null)
            {
                var item1 = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = friend,
                    CurrentFriendId = friend.Id,
                };

                Create(item1);

                var item2 = new Friend()
                {
                    UserId = friend.Id,
                    User = friend,
                    CurrentFriend = target,
                    CurrentFriendId = target.Id,
                };

                Create(item2);
            }
        }

        public List<User> GetFriendsByUser(User target)
        {
            var friends = Set.Include(x => x.CurrentFriend).Include(x => x.User).AsEnumerable().Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend);

            return friends.ToList();
        }

        public void DeleteFriend(User target, User friend)
        {
            if (target.Id == friend.Id)
            {
                return;
            }

            var friendship1 = Set.FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == friend.Id);
            var friendship2 = Set.FirstOrDefault(x => x.UserId == friend.Id && x.CurrentFriendId == target.Id);

            if (friendship1 != null)
            {
                Delete(friendship1);
            }
            if (friendship2 != null)
            {
                Delete(friendship2);
            }
        }
    }
}
