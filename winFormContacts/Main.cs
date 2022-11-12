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
    public partial class Main : Form
    {
        private BussinessLogicLayer bussinessLogicLayer;
        public Main()
        {
            InitializeComponent();
            bussinessLogicLayer = new BussinessLogicLayer();
        }


        #region Eventos
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetail();
        }
        #endregion

        #region Private Methods
        private void OpenContactDetail()
        {
            ContactDetails contacto = new ContactDetails();
            contacto.ShowDialog(this);
        }

        private void dtgContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = (DataGridViewCell)dtgContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString() == "Edit")
            {
                ContactDetails contactDetails = new ContactDetails();
                contactDetails.loadContact(new MContact
                {
                    Id = int.Parse(dtgContacts.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    Name = dtgContacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    LastName = dtgContacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Phone = dtgContacts.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Address = dtgContacts.Rows[e.RowIndex].Cells[4].Value.ToString()
                });
                contactDetails.ShowDialog(this);
            }
            else if (cell.Value.ToString() == "Delete")
            {
                DeleteContact(int.Parse(dtgContacts.Rows[e.RowIndex].Cells[0].Value.ToString()));
                PopulateContacts();
            }
        }

        private void DeleteContact(int id)
        {
            bussinessLogicLayer.DeleteContac(id);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateContacts(txtSearch.Text);
            txtSearch.Text = string.Empty;
        }
        #endregion
        #region Public Methods
        public void PopulateContacts(string searchText = null)
        {
            List<MContact> contacts = bussinessLogicLayer.GetContacts(searchText);
            dtgContacts.DataSource = contacts;
        }
        #endregion
  
    }
}
