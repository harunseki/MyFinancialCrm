using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFinancialCrm.Models;

namespace MyFinancialCrm
{
    public partial class FrmDasboard : Form
    {
        public FrmDasboard()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        int count = 0;

        private void FrmDasboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x=>x.BankBalance);
            lblBalanceTotal.Text = totalBalance.ToString()+ " ₺";

            var lastProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y=>y.Description).FirstOrDefault();
            var lastProcessAmount = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y=>y.Amount).FirstOrDefault();
            lblLastBankProcessTitle.Text = lastProcess.ToString();
            lblIsBalance.Text = lastProcessAmount.ToString();

            //Chart1 Kodları
            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance,
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series 1");
            foreach(var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            //chart2 Kodları
            var billData = db.Bills.Select(x => new
            {
                x.BillTitle,
                x.BillAmount,
            }).ToList();
            chart2.Series.Clear();
            var series1 = chart2.Series.Add("Faturalar");
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach( var item in billData)
            {
                series1.Points.AddXY(item.BillTitle, item.BillAmount);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            //lblBillAmount.Text = count.ToString();
            if (count % 8 == 1)
            {
                var billTitle = db.Bills.Where(x => x.BillTitle=="Elektrik Faturası").Sum(y=>y.BillAmount);
                lblBillAmount.Text = billTitle.ToString();
                lblBillTitle.Text = "Elektrik Faturası";
            }
            if (count % 8 == 3)
            {
                var billTitle = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").Sum(y => y.BillAmount);
                lblBillAmount.Text = billTitle.ToString();
                lblBillTitle.Text = "Doğalgaz Faturası";
            }
            if (count % 8 == 5)
            {
                var billTitle = db.Bills.Where(x => x.BillTitle == "Su Faturası").Sum(y => y.BillAmount);
                lblBillAmount.Text = billTitle.ToString();
                lblBillTitle.Text = "Su Faturası";
            }
            if (count % 8 == 7)
            {
                var billTitle = db.Bills.Where(x => x.BillTitle == "Telefon Faturası").Sum(y => y.BillAmount);
                lblBillAmount.Text = billTitle.ToString();
                lblBillTitle.Text = "Telefon Faturası";
            }
        }
    }
}
