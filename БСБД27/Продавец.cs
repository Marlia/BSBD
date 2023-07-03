using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace БСБД27
{
    public partial class Продавец : Form
    {
        public Продавец()
        {
            InitializeComponent();
        }

        private void продавецBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.продавецBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.бСБДDataSet);

        }

        private void Продавец_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Properties". При необходимости она может быть перемещена или удалена.
            this.propertiesTableAdapter.Fill(this.бСБДDataSet1.Properties);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Sellers". При необходимости она может быть перемещена или удалена.
            this.sellersTableAdapter.Fill(this.бСБДDataSet1.Sellers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Buyers". При необходимости она может быть перемещена или удалена.
            this.buyersTableAdapter.Fill(this.бСБДDataSet1.Buyers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet.Продавец". При необходимости она может быть перемещена или удалена.
            this.продавецTableAdapter.Fill(this.бСБДDataSet.Продавец);

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

        private void покупателиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sellersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.бСБДDataSet1);
        }
    }
}
