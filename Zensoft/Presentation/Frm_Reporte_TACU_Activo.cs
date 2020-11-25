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
    public partial class Frm_Reporte_TACU_Activo : Form
    {
        public Frm_Reporte_TACU_Activo()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_TACU_Activo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetTACUActivo.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DataSetTACUActivo.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
