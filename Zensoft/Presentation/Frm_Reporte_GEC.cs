using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Frm_Reporte_GEC : Form
    {
        public Frm_Reporte_GEC()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_GEC_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetGEC.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DataSetGEC.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
