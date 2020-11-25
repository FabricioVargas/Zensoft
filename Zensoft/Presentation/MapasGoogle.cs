using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Presentation
{
    public partial class MapasGoogle : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        Frm_UO_Agregar frmUnidad;


        double LatInicial;
        double LngInicial;
        bool seleccionado = false;


        public MapasGoogle(Frm_UO_Agregar frmUnidad)
        {
            InitializeComponent();
            this.frmUnidad = frmUnidad;
            this.LatInicial = 9.97765300778612;
            this.LngInicial = -84.7474760189652;
        }

        public MapasGoogle(Frm_UO_Agregar frmUnidad, double lat, double lng)
        {
            InitializeComponent();
            this.frmUnidad = frmUnidad;
            this.LatInicial = lat;
            this.LngInicial = lng;
        }


        private void MapasGoogle_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            this.txtLatitud.Text = this.LatInicial.ToString();
            this.txtLongitud.Text = this.LngInicial.ToString();


            //Marcador

            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker);//agregar al mapa

            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Ubicación: \n Latitud:{0} \n Longitud:{1}", LatInicial, LngInicial);

            //agregar el mapa y el marcador al map control
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Obtener datos de acuerdo al click
            double lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;

            txtLatitud.Text = lat.ToString();
            txtLongitud.Text = lng.ToString();
            //mover el marker en el click
            marker.Position = new PointLatLng(lat, lng);

            marker.ToolTipText = string.Format("Ubicación: \n Latitud: {0}  \n Longitud: {1}", lat, lng);
        }

        private void btnSatelite_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
        }

        private void btnRelieve_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackZoom.Value = Convert.ToInt32(gMapControl1.Zoom);
        }

        private void trackZoom_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackZoom.Value;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                seleccionado = true;
                this.frmUnidad.cargarUbicacion(Convert.ToDouble(this.txtLatitud.Text), Convert.ToDouble(this.txtLongitud.Text), seleccionado);
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
