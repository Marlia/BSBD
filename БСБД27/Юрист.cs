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
    public partial class Юрист : Form
    {
        public Юрист()
        {
            InitializeComponent();
        }

        private void юристBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.buyersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.бСБДDataSet);

        }

        private void Юрист_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Sellers". При необходимости она может быть перемещена или удалена.
            this.sellersTableAdapter.Fill(this.бСБДDataSet1.Sellers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бСБДDataSet1.Buyers". При необходимости она может быть перемещена или удалена.
            this.buyersTableAdapter.Fill(this.бСБДDataSet1.Buyers);
        }

        private void продавцыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sellersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.бСБДDataSet);
        }
    }
}
