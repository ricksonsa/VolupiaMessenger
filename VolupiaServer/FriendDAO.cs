using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace VolupiaServer
{
    public class FriendDAO
    {
        public static bool Invite(int userId, string friendName)
        {
            using (VolupiaContext con = new VolupiaContext())
            {
                var friend = con.Clients.Where(x => x.Username.Equals(friendName)).FirstOrDefault();

                var invite = con.Friends.Where(x => x.UserId.Equals(userId) & x.FriendId.Equals(friend.Id)).FirstOrDefault();
                var invited = con.Friends.Where(x => x.UserId.Equals(friend.Id) & x.FriendId.Equals(userId)).FirstOrDefault();

                if (invite == null && invited == null)
                {
                    con.Friends.Add(new Friend
                    {
                        UserId = userId,
                        FriendId = friend.Id,
                        Accepted = false
                    });
                    bool func(int x) => x > 0;
                    return func(con.SaveChanges());
                }
                else
                    return false;

            }
        }

        public static void Accept(int id)
        {
            using (var con = new VolupiaContext())
            {
                var invite = con.Friends.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (invite != null)
                {
                    invite.Accepted = true;
                    con.SaveChanges();
                }
            }
        }

        public static void Reject(int id)
        {
            using (var con = new VolupiaContext())
            {
                var invite = con.Friends.Where(x => x.Id.Equals(id)).FirstOrDefault();

                if (invite != null)
                {
                    con.Friends.Remove(invite);
                    con.SaveChanges();
                }
            }
        }

        public static List<string> GetContacts(int userId)
        {
            using (var con = new VolupiaContext())
            {
                var madeList = con.Friends.Where(x=>x.UserId.Equals(userId) && x.Accepted).ToList();
                var receivedList = con.Friends.Where(x => x.FriendId.Equals(userId) && x.Accepted).ToList();
                var contactList = new List<string>();

                foreach (var contact in madeList)
                {
                    var friend = con.Clients.Where(c => c.Id.Equals(contact.FriendId)).FirstOrDefault();
                    contactList.Add(JsonConvert.SerializeObject(friend));
                }

                foreach (var contact in receivedList)
                {
                    var friend = con.Clients.Where(c => c.Id.Equals(contact.UserId)).FirstOrDefault();
                    contactList.Add(JsonConvert.SerializeObject(friend));
                }

                contactList = contactList.Distinct().ToList();

                if (contactList.Count > 0)
                {
                    return contactList;
                }
                return null;
            }
        }

        public static List<string> GetInvites(int userId)
        {
            using (var con = new VolupiaContext())
            {
                var list = con.Friends.Where(invite => invite.UserId.Equals(userId) & !invite.Accepted).ToList();
                var invites = new List<string>();

                foreach (var item in list)
                {
                    invites.Add(JsonConvert.SerializeObject(item));
                }

                if (invites.Count > 0)
                {
                    return invites;
                }
                return null;
            }
        }

        public static bool IsFriendOrInvited(int userId, int friendId)
        {
            using (var con = new VolupiaContext())
            {
                var invite = con.Friends.Where(x => x.UserId.Equals(userId) & x.FriendId.Equals(friendId)).FirstOrDefault();
                var invited = con.Friends.Where(x => x.UserId.Equals(friendId) & x.FriendId.Equals(userId)).FirstOrDefault();
                if (invited != null || invite!=null)
                    return true;
            }
            return false;
        }

        public static List<string> GetInvited(int userId)
        {
            using (var con = new VolupiaContext())
            {
                var list = con.Friends.Where(invite => invite.FriendId.Equals(userId) & invite.Accepted.Equals(false)).ToList();
                var invites = new List<string>();

                foreach (var item in list)
                {
                    invites.Add(JsonConvert.SerializeObject(item));
                }

                if (invites.Count > 0)
                {
                    return invites;
                }
                return null;
            }
        }

        public static List<string> Find(string name)
        {
            using (var con = new VolupiaContext())
            {
                var people = con.Clients.Where(x => x.Name.Contains(name) | x.Username.Contains(name)).OrderBy(c => c.Name).Take(15).ToList();
                var list = new List<string>();

                foreach (var person in people)
                {
                    list.Add(JsonConvert.SerializeObject(person));
                }

                if (list.Count > 0)
                {
                    return list;
                }
                return null;
            }
        }

        public static string FindById(int id)
        {
            using (var con = new VolupiaContext())
            {
                var person = con.Clients.Where(x => x.Id.Equals(id)).FirstOrDefault();

                return JsonConvert.SerializeObject(person);
            }
        }
    }
}
