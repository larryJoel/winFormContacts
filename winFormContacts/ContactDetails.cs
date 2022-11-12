using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winFormContacts
{
    public partial class ContactDetails : Form
    {
        private BussinessLogicLayer _bussinessLogicLayer;
        private MContact _contact;
        public ContactDetails()
        {
            InitializeComponent();
            _bussinessLogicLayer= new BussinessLogicLayer();
        }

        #region public methods
        public void loadContact(MContact contact)
        {
            _contact = contact;
            if (contact != null)
            {
                ClearForm();
                txtName.Text = contact.Name;
                txtLastName.Text = contact.LastName;
                txtPhone.Text = contact.Phone;
                txtAddress.Text = contact.Address;
            }
            else
            {
                MessageBox.Show("No hay datos para editar..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region private methods
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
            this.Close();
            ((Main)this.Owner).PopulateContacts();
        }

        private void SaveContact()
        {
            MContact contacto = new MContact();
            contacto.Name = txtName.Text;
            contacto.LastName = txtLastName.Text;
            contacto.Phone = txtPhone.Text;
            contacto.Address = txtAddress.Text;

            contacto.Id = _contact != null ? _contact.Id : 0;

            _bussinessLogicLayer.SaveContact(contacto);

        }
        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        #endregion
    }


}
