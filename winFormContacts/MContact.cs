using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winFormContacts
{
    public class MContact
    {
       /* public MContact(int id, string name, string lastName, string phone, string address)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Address = address;
        }*/

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
