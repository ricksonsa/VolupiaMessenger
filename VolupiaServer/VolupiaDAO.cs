using System.Collections.Generic;
using System.Data.OleDb;
using MongoDB.Driver;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace VolupiaServer
{
    public class VolupiaDAO
    {
        //[BsonId]
        private int ID { get; set; }
        private string Name { get; set; }
        private string Password { get; set; }
        private string Mail { get; set; } 
        private string UserName { get; set; }

        /*//MongoDB
        private static readonly MongoClient Mongo = new MongoClient("mongodb://localhost:27017");

        //Users section
        private static readonly IMongoDatabase UsersDataBase = Mongo.GetDatabase("UsersDB");
        private static readonly IMongoCollection<BsonDocument> UsersCollection = UsersDataBase.GetCollection<BsonDocument>("Users");
        //End section     */ 

        //SQL
        private static readonly OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\Users\rick\Documents\Volupia\VolupiaMessenger2.2\VolupiaServer\bin\Debug\VolupiaDB.mdb");

        //Construtor
        public VolupiaDAO()
        {

        }

        public VolupiaDAO(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

       /* public VolupiaDAO(int id, string userName, string mail, string name)
        {
            ID = id;
            UserName = userName;
            Mail = mail;
            Name = name;
        }*/

        public VolupiaDAO(string userName, string password, string mail, string name)
        {
            UserName = userName;
            Mail = mail;
            Name = name;
        }

       /* public static bool InsertUser(string userName, string password, string mail, string name)
        {
            //Inserir usuário apenas se não houver outro com esses atributos
            if (!ValidateUserToInsert(userName, mail))
            {
                var builder = Builders<BsonDocument>.Filter;
                var list = UsersCollection.Find(_ => true).ToList();
                var totalCount = list.Count;

                var obj = new VolupiaDAO
                {
                    ID = new ObjectId(totalCount.ToString()),
                    UserName = userName,
                    Password = password,
                    Mail = mail,
                    Name = name
                };

                var bson = obj.ToBsonDocument();
                UsersCollection.InsertOne(bson);
                return true;
            }
            return false;
        }

        private static bool ValidateUserToInsert(string loginEntry, string mail)
        {
            //Filtro -> nome = loginEntry ou Email = mail
            var builder = Builders<BsonDocument>.Filter;
            var filt = builder.Eq("UserName", loginEntry) | builder.Eq("Mail", loginEntry);
            var list = UsersCollection.Find(filt).ToList();

            var totalCount = list.Count;

            if (totalCount > 0)
                return true;

            return false;
        }

        public static bool ValidateUser(string loginEntry, string password)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filt = builder.Eq("UserName", loginEntry) | builder.Eq("Mail", loginEntry) & builder.Eq(password, password);
            var list = UsersCollection.Find(filt).ToList();

            var totalCount = list.Count;

            if (totalCount > 0)
                return true;

            return false;
        }

        public static string[] GetUser(string loginEntry, string password)
        {
            string[] VolupiaUser = new string[4];

            var builder = Builders<BsonDocument>.Filter;
            var filt = builder.Eq("UserName", loginEntry) | builder.Eq("Mail", loginEntry) & builder.Eq(password, password);
            var person = UsersCollection.Find(filt).FirstOrDefault();
            var obj = BsonSerializer.Deserialize<VolupiaDAO>(person);

            //var myClass = new Mytype();
            //myClass.Name = bsonDoc["name"].AsString;

            VolupiaUser[0] = obj.ID.ToString();
            VolupiaUser[1] = obj.Name;
            VolupiaUser[2] = obj.UserName;
            VolupiaUser[3] = obj.Mail;

            return VolupiaUser;
        }*/

        //Metodo para validar acesso para o cliente
        public static bool CheckAccount(string loginEntry, string password)
        {
            object userObj = null, passObj = null, mailObj = null, name = null;
            int id = 0;
            string sql = "Select * from tbl_VolupiaUser Where Username = @Name or Email = @Name and Password = @Pass";
            OleDbParameter pararm = new OleDbParameter("@Name", loginEntry);
            OleDbParameter pararp = new OleDbParameter("@Pass", password);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add(pararm);
            cmd.Parameters.Add(pararp);
            try
            {
                conn.Open();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar abrir a conexao com o banco: " + ex);
            }

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["Código"];
                name = reader["nm_Name"].ToString();
                userObj = reader["Username"].ToString();
                passObj = reader["Password"];
                mailObj = reader["Email"].ToString();
            }

            try
            {
                conn.Close();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar fechar a conexao com o banco: " + ex);
            }

            if (id != 0)
            {
                if (loginEntry == userObj.ToString() || loginEntry == mailObj.ToString())
                    if (password == passObj.ToString())
                        return true;
            }
            return false;
        }

        //Retorna dados da conta de usuario com excessão da senha
        public static string[] Login(string loginEntry, string password)
        {
            object userObj = null, passObj = null, mailObj = null, name = null;
            int id = 0;
            string sql = "Select * from tbl_VolupiaUser Where Username = @Name or Email = @Name and Password = @Pass";
            OleDbParameter pararm = new OleDbParameter("@Name", loginEntry);
            OleDbParameter pararp = new OleDbParameter("@Pass", password);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add(pararm);
            cmd.Parameters.Add(pararp);
            try
            {
                conn.Open();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar abrir a conexao com o banco: " + ex);
            }

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["Código"];
                name = reader["nm_Name"].ToString();
                userObj = reader["Username"].ToString();
                passObj = reader["Password"];
                mailObj = reader["Email"].ToString();
            }

            try
            {
                conn.Close();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar fechar a conexao com o banco: " + ex);
            }

            string[] VolupiaUser = new string[4];
            VolupiaUser[0] = id.ToString();
            VolupiaUser[1] = name.ToString();
            VolupiaUser[2] = userObj.ToString();
            VolupiaUser[3] = mailObj.ToString();
            return VolupiaUser;
        }

        public static List<string> GetFriendsById(int id)
        {
            string friend;
            List<string> Connections = new List<string>();

            string sql = "SELECT (u.Código , c.Connection)" +
                " FROM tbl_VolupiaUser u,tbl_Connections c" +
                " INNER JOIN tbl_Connections" +
                " ON (u.Código = c.FK_User)" +
                " WHERE u.Código = @Id";

            // string sql = "SELECT Connection FROM tbl_Connections WHERE FK_User = @Id";
            OleDbParameter pararm = new OleDbParameter("@Id", id);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.Parameters.Add(pararm);
            try
            {
                conn.Open();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar abrir a conexao com o banco GetFriendsById(" + id + ") " + ex.ToString());
            }

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                friend = reader["Connection"].ToString();
                Connections.Add(friend);
            }

            try
            {
                conn.Close();
            }
            catch (OleDbException ex)
            {
                Logger.ServerLog("Erro ao tentar fechar a conexao com o banco: " + ex);
            }
            return Connections;
        }

    }
}
