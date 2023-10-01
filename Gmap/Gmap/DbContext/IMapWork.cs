using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmap.DbContext
{
    internal interface IMapWork
    {
        void drawМape(GMapControl gMapControler);
        
        void mouseDown(MouseEventArgs e,  GMapMarker selectedMarker, GMapControl gMapControler, List<Marker> markers);

        void addMarker( GMapMarker selectedMarker);


    }
}
