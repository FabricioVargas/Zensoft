using System;
using System.Windows.Forms;
using LogicaNegocio;

namespace Presentation
{
    public partial class Frm_U_Consultar2 : Form
    {
        LNUsuario lnUsuario;

        public Frm_U_Consultar2()
        {
            InitializeComponent();
            FillCbGrupo();
        }

        private void FillCbGrupo()
        {
            lnUsuario = new LNUsuario();

            CbGrupo.DataSource = lnUsuario.GetGrupo();
            CbGrupo.DisplayMember = "nombre";
            CbGrupo.ValueMember = "idGrupo";
        }

        private void CbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnUsuario = new LNUsuario();
            this.DGGrupo.AllowUserToAddRows = false;//Permitir al usuario agregar propiedad de filas
            this.DGGrupo.DataSource = lnUsuario.GetGrupoUsuario(CbGrupo.SelectedValue.ToString());
            this.DGGrupo.AutoResizeColumns();
            this.DGGrupo.ReadOnly = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
