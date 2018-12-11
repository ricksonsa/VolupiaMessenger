using Newtonsoft.Json;

namespace VolupiaChat
{
    public class Client
    {
        public int Id { get; }
        public string Password { get;}
        public string Email { get; }
        public string Name { get; }
        public string Username { get; }

        [JsonConstructor]
        public Client(int id, string username, string password, string name, string mail)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Email = mail;
        }
        public Client(string username, string password, string name, string mail)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = mail;
        }
    }
}
