using LogicaNegocio;
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
    public partial class Frm_GEC_Lista : Form
    {
        public Frm_GEC_Lista()
        {
            InitializeComponent();
            cargarFechas();

            if (timeHasta.Value.Date.Equals(DateTime.Now))
            {
                CargarGrid(timeDesde.Value.Date, Convert.ToDateTime(String.Format("{0:G}", DateTime.Now)));
            }
            else
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.Date);
            }

        }

        private void cargarFechas()
        {
            timeHasta.Value = DateTime.Now.Date;
            timeDesde.Value = Convert.ToDateTime(String.Format("{0:G}", DateTime.Now));
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            Frm_GEC_Realizar frm_GEC_Realizar = new Frm_GEC_Realizar();
            frm_GEC_Realizar.ShowDialog();
            frm_GEC_Realizar.Dispose();
        }


        private void timeDeste_ValueChanged(object sender, EventArgs e) //**
        {
            TimeSpan tiempoDiferencia = timeDesde.Value.Date - timeHasta.Value.Date;
            if (tiempoDiferencia.ToString().Substring(0, 1).Equals("0")) //00:00:00  ✔️
            {
                if (timeHasta.Value.Date.Equals(DateTime.Now))
                {
                    CargarGrid(timeDesde.Value.Date, Convert.ToDateTime(String.Format("{0:G}", DateTime.Now)));
                }
                else
                {
                    CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
                }
            }
            else if (tiempoDiferencia.ToString().Substring(0, 1).Equals("-"))//-02:00:00 ✔️
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }
            else//10:00:00 ❌
            {
                timeDesde.Value = timeHasta.Value;
            }

            if (timeHasta.Value == timeDesde.Value)
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }

            if (timeHasta.Value == DateTime.Now.Date)
            {
               CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }
        }

        private void timeHasta_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan tiempoDiferencia = timeDesde.Value.Date - timeHasta.Value.Date;

            if (timeHasta.Value > DateTime.Now.Date)
            {
                timeHasta.Value = DateTime.Now.Date;
            }

            if (tiempoDiferencia.ToString().Substring(0, 1).Equals("0")) //00:00:00
            {
                if (timeHasta.Value.Date.Equals(DateTime.Now))
                {
                    CargarGrid(timeDesde.Value.Date, Convert.ToDateTime(String.Format("{0:G}", DateTime.Now)));
                }
                else
                {
                    CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
                }
            }
            else if (tiempoDiferencia.ToString().Substring(0, 1).Equals("-"))//-02:00:00
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }
            else//10:00:00
            {
                timeDesde.Value = timeHasta.Value;
            }

            if (timeHasta.Value == timeDesde.Value)
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }

            if (timeHasta.Value == DateTime.Now.Date)
            {
                CargarGrid(timeDesde.Value.Date, timeHasta.Value.AddDays(1));
            }
        }

        private void CargarGrid(DateTime desde, DateTime hasta)
        {
            LNMovimientos lnMovimiento = new LNMovimientos();

            dgvConsumible.AllowUserToAddRows = false;
            dgvConsumible.DataSource = lnMovimiento.generarGVconFechas(desde,hasta);

            dgvConsumible.AutoResizeColumns();
            dgvConsumible.ReadOnly = true;
        }

    }
}
