using Gmap.DbContext;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gmap
{
    public partial class MapForm : Form 
    {
        
        public MapForm()
        {
            InitializeComponent();
        }
        GMapMarker selectedMarker;
        DbWork db = new DbWork();
        CreatMap map = new CreatMap();
        List<Marker> markers;


        private void MapForm_Load(object sender, EventArgs e)
        {
            
            db.TableCreat();
          
        }


        private void gMapControler_MouseUp(object sender, MouseEventArgs e)
        {
            map.mouseDown(e, selectedMarker, gMapControler, markers);
            map.addMarker(selectedMarker);

        }

        private void gMapControler_Load(object sender, EventArgs e)
        {
           
            map.drawМape(gMapControler);
            gMapControler.MouseUp += new MouseEventHandler(gMapControler_MouseUp);
            gMapControler.MouseDown += new MouseEventHandler(gMapControler_MouseDown);
            gMapControler.MouseMove += new MouseEventHandler(gMapControler_MouseMove);
        }

       

        private void gMapControler_MouseDown(object sender, MouseEventArgs e) {

            selectedMarker = gMapControler.Overlays.SelectMany(o => o.Markers).FirstOrDefault(m => m.IsMouseOver == true);
            

        }

        private void gMapControler_MouseMove(object sender, MouseEventArgs e)
        {
            map.mouseMove(e, selectedMarker, gMapControler);
            
        }
    }
}
