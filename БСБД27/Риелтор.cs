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
    public partial class Риелтор : Form
    {
        public Риелтор()
        {
            InitializeComponent();
        }

        private void Риелтор_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Properties". При необходимости она может быть перемещена или удалена.
            this.propertiesTableAdapter.Fill(this.бСБДDataSet1.Properties);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Lawyers". При необходимости она может быть перемещена или удалена.
            this.lawyersTableAdapter.Fill(this.бСБДDataSet1.Lawyers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Realtors". При необходимости она может быть перемещена или удалена.
            this.realtorsTableAdapter.Fill(this.бСБДDataSet1.Realtors);
        }

        private void покупателиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.realtorsBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.бСБДDataSet1);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.lawyersBindingSource.EndEdit();
            this.lawyersTableAdapter.Update(this.бСБДDataSet1.Lawyers);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.propertiesBindingSource.EndEdit();
            this.propertiesTableAdapter.Update(this.бСБДDataSet1.Properties);
        }
    }
}
