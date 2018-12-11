using Newtonsoft.Json;
using System.Linq;
using System.ServiceModel;

namespace VolupiaServer
{
    public class VolupiaDAO
    {
        public static bool InsertUser(string user)
        {
            var User = JsonConvert.DeserializeObject<Client>(user);

            using (VolupiaContext con = new VolupiaContext())
            {
                if (con.Clients.Where(c => c.Name.Equals(User.Username)).FirstOrDefault() == null)
                {
                    con.Clients.Add(User);
                    bool Func(int x) => x > 0;
                    return Func(con.SaveChanges());
                }
                else
                {
                    throw new FaultException("Nome de usuário já utilizado.");
                }
            }
        }

        //Metodo para validar acesso para o cliente
        public static bool ValidateUser(string loginEntry, string password)
        {
            using(VolupiaContext context = new VolupiaContext())
            {
                var user = context.Clients.Where(x => x.Username.Equals(loginEntry) 
                | x.Email.Equals(loginEntry) 
                && x.Password.Equals(password)).FirstOrDefault();

                bool Check(Client x) => x != null;

                return Check(user);
            }
        }

        public static bool HasUser(string entry)
        {
            using (VolupiaContext context = new VolupiaContext())
            {
                var user = context.Clients.Where(x => x.Username.Equals(entry)).FirstOrDefault();

                bool Check(Client x) => x != null;

                return Check(user);
            }
        }

        public static bool HasMail(string entry)
        {
            using (VolupiaContext context = new VolupiaContext())
            {
                var user = context.Clients.Where(x => x.Email.Equals(entry)).FirstOrDefault();

                bool Check(Client x) => x != null;

                return Check(user);
            }
        }

        public static string GetUser(string loginEntry, string password)
        {
            using (VolupiaContext context = new VolupiaContext())
            {
                var user = context.Clients.Where(x => x.Username.Equals(loginEntry)
                | x.Email.Equals(loginEntry)
                && x.Password.Equals(password)).FirstOrDefault();

                var json = JsonConvert.SerializeObject(user);
                return json;
            }
        }
    }
}
