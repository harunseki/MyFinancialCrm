using MyFinancialCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MyFinancialCrm
{
    public partial class FrmBanks : Form
    {
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri
            var ziraatBalance = db.Banks.Where(x=>x.BankTitle== "Ziraat Bankası").Select(y=>y.BankBalance).FirstOrDefault();
            var vakifBalance = db.Banks.Where(x=>x.BankTitle=="Vakıfbank").Select(y=>y.BankBalance).FirstOrDefault();
            var isBalance = db.Banks.Where(x=>x.BankTitle== "İş Bankası").Select(y=>y.BankBalance).FirstOrDefault();

            lblZiraatBalance.Text = ziraatBalance.ToString() +" ₺";
            lblVakifBalance.Text = vakifBalance.ToString() + " ₺";
            lblIsBalance.Text = isBalance.ToString() + " ₺";

            //Banka Hareketleri
            var bankProsess1 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).FirstOrDefault();
            lblBanProcess1.Text = bankProsess1.Description + " " + bankProsess1.Amount + " " + bankProsess1.ProcessDate;

            var bankProsess2 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(2).Skip(1).FirstOrDefault();
            lblBanProcess2.Text = bankProsess2.Description + " " + bankProsess2.Amount + " " + bankProsess2.ProcessDate;

            var bankProsess3 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(3).Skip(2).FirstOrDefault();
            lblBanProcess3.Text = bankProsess3.Description + " " + bankProsess3.Amount + " " + bankProsess3.ProcessDate;

            var bankProsess4 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(4).Skip(3).FirstOrDefault();
            lblBanProcess4.Text = bankProsess4.Description + " " + bankProsess4.Amount + " " + bankProsess4.ProcessDate;

            var bankProsess5 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(5).Skip(4).FirstOrDefault();
            lblBanProcess5.Text = bankProsess5.Description + " " + bankProsess5.Amount + " " + bankProsess5.ProcessDate;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmBillings frmBillings = new FrmBillings();
            frmBillings.Show();
            this.Hide();
        }
    }
}