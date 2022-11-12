using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace winFormContacts
{
    public class DataAccessLayer
    {
        private SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=winFormsCntacts;Data Source=SELIN-LGONZALEZ");
        public void InsertContact(MContact contact)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO Contact (FirstName, LastName,Phone, Address)
                                VALUES  (@Name, @LastName,@Phone, @Address)";
                SqlParameter firstname = new SqlParameter();
                firstname.ParameterName = "@Name";
                firstname.Value = contact.Name;
                firstname.DbType = System.Data.DbType.String;
                //otra forma de hacer esto
                SqlParameter lastName = new SqlParameter("@LastName", contact.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(firstname);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }
        public void UpdateContact(MContact contact)
        {
            try
            {
                conn.Open();
                string query = @"UPDATE Contact
                                 SET FirstName = @Name,
                                 LastName = @LastName,
                                 Phone = @Phone,
                                 Address = @Address WHERE
                                 Id = @Id";
                SqlParameter Id = new SqlParameter("@Id", contact.Id);
                SqlParameter firstname = new SqlParameter("@Name", contact.Name);
                SqlParameter lastName = new SqlParameter("@LastName", contact.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(Id);
                command.Parameters.Add(firstname);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();
                //conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
        }
        
        public void DeleteContact(int id)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM Contact WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }   
        }
        public List<MContact> GetContacts(string search = null)
        {
            List<MContact> contacts = new List<MContact>();
            try
            {
                conn.Open();
                string query = @"SELECT id, FirstName, LastName, Phone, Address FROM Contact";
                
                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(search))
                {
                    query += @" WHERE FirstName LIKE @Search OR 
                             LastName LIKE @Search OR
                             Phone LIKE @Search OR
                             Address LIKE @Search ";

                    command.Parameters.Add(new SqlParameter("@Search", $"%{search}%"));
                }

                command.CommandText = query;
                command.Connection= conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    contacts.Add(new MContact 
                    { 
                        Id = int.Parse(reader["Id"].ToString()),
                        Name = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return contacts;
        }
    }
}
