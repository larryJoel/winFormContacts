using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winFormContacts
{
    public class BussinessLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;

        public BussinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }
        public MContact SaveContact(MContact contact)
        {
            if(contact.Id == 0)
            {
                _dataAccessLayer.InsertContact(contact);
            }
            else
            {
                _dataAccessLayer.UpdateContact(contact);
            }
            return contact;
        }

        public List<MContact> GetContacts(string searchText = null)
        {
           return _dataAccessLayer.GetContacts(searchText);
        }

        public void DeleteContac(int id)
        {
            _dataAccessLayer.DeleteContact(id);
        }

    }
}
