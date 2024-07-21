using Domain.Models;
using MySql.Data.MySqlClient;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private string _ctor;
        public UserRepository(string ctor)
        {
            _ctor=ctor;
        }

        public List<User> GetUserByEmail(string Email)
        {
          List<User> users = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(_ctor))
            {
                using (MySqlCommand command = new MySqlCommand("GetUserByEmail", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_Email", Email);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader()) 
                        {
                        while (reader.Read())
                        {
                            User user = new User();
                            user.Id = (long)reader["Id"];
                            user.Name = reader["Name"].ToString();
                            user.Email = reader["Email"].ToString();
                            users.Add(user);
                        }
                        
                    }
                    connection.Close();
                }
            }
        
       
            return users;
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection connction = new MySqlConnection(_ctor))
            {
                using (MySqlCommand command = new MySqlCommand("GetAllUsers", connction))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connction.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                Id= (long)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Email= reader["Email"].ToString(),
                            };
                            users.Add(user);
                        }
                    }
                    connction.Close();
                }
            }
            return users;
        }

        public void AddNewUser(User user)
        {

            using(MySqlConnection connction = new MySqlConnection(_ctor))
            {
                using(MySqlCommand command = new MySqlCommand("AddUser", connction))
                {
                    connction.Open();
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("P_Name", user.Name);
                    command.Parameters.AddWithValue("P_Email", user.Email);
                    command.ExecuteReader();
                    connction.Close();
                }
            }
        }
        public void RemoveUser(long userid) {
            using (MySqlConnection connction = new MySqlConnection(_ctor))
            {
                using (MySqlCommand command = new MySqlCommand("RemoveUser", connction))
                {
                    connction.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("P_Id", userid);
                    command.ExecuteReader();
                    connction.Close();
                }
            }
        }
    }
}
