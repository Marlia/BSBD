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
    public partial class Покупатель : Form
    {
        public Покупатель()
        {
            InitializeComponent();
        }

        private void Покупатель_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Properties". При необходимости она может быть перемещена или удалена.
            this.propertiesTableAdapter.Fill(this.бСБДDataSet1.Properties);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Buyers". При необходимости она может быть перемещена или удалена.
            this.buyersTableAdapter.Fill(this.бСБДDataSet1.Buyers);
        }

        private void покупателиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.buyersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.бСБДDataSet1);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.propertiesBindingSource.EndEdit();
            this.propertiesTableAdapter.Update(this.бСБДDataSet1.Properties);
        }
    }
}
