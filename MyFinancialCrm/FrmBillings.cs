using System;
using System.Linq;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmBillings : Form
    {
        public FrmBillings()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        void GetAllList()
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmBillings_Load(object sender, EventArgs e)
        {
            GetAllList();
        }

        private void btnListBill_Click(object sender, EventArgs e)
        {
            GetAllList();
        }

        private void BtnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bills bills = new Bills();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;
            var message = db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show(message.ToString());
            GetAllList();
        }

        private void btnDeleteBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var deletedId = db.Bills.Find(id);
            db.Bills.Remove(deletedId);
            db.SaveChanges();
            MessageBox.Show("Silme başarılı", "Liste güncellendi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            GetAllList();
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            int id = int.Parse(txtBillId.Text);
            var values = db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = period;
            db.SaveChanges();
            MessageBox.Show("Güncelleme başarılı", "Liste güncellendi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            GetAllList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }
    }
}
