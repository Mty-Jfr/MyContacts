using System;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();

        }

        private void BindGrid()
        {
            dgcontacts.AutoGenerateColumns = false;
            dgcontacts.DataSource = repository.SelectAll();
        }

        private void dgcontacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btbRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnnewcontact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            if( dgcontacts.CurrentRow != null )
            {
                string name = dgcontacts.CurrentRow.Cells[1].Value.ToString();
                string family = dgcontacts.CurrentRow.Cells[2].Value.ToString();
                string fullname = name + " " + family;


                if (MessageBox.Show($"آیا از حذف { fullname } مطمئن هستید؟","توجه",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    int contactId = int.Parse(dgcontacts.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactId);
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را از لیست انتخاب کنید");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgcontacts.CurrentRow != null)
            {
                int contactId = int.Parse(dgcontacts.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
                


            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dgcontacts.DataSource = repository.search(txtsearch.Text);
        }
    }
}
