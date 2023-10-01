using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.NetworkInformation;

namespace Gmap.DbContext
{
    class CreatMap : IMapWork
    {
        DbWork db = new DbWork();   
        
        public void drawМape(GMapControl gMapControler)
        {
            
           GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControler.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            gMapControler.MinZoom = 2; //минимальный зум
            gMapControler.MaxZoom = 16; //максимальный зум
            gMapControler.Zoom = 4; // какой используется зум при открытии
            gMapControler.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);// точка в центре карты при открытии (центр России)
            gMapControler.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMapControler.CanDragMap = true; // перетаскивание карты мышью
            gMapControler.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMapControler.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMapControler.ShowTileGridLines = false;
            List<Marker> markers = new List<Marker>();
            gMapControler.Overlays.Add(GetOverlayMarkers(markers));
            gMapControler.Overlays.Add(GetOverlayMarkers(markers, GMarkerGoogleType.red));
            gMapControler.Overlays[0].IsVisibile = false;

        }

        

        private GMarkerGoogle getMarker(Marker marker, GMarkerGoogleType gMarkerGoogleType)
        {
            GMapOverlay markersOverlay = new GMapOverlay("Markers");
            GMarkerGoogle mapMarker = new GMarkerGoogle(new GMap.NET.PointLatLng( marker.latitude, marker.longitude), gMarkerGoogleType);
            mapMarker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(mapMarker);//всплывающее окно с инфой к маркеру
            mapMarker.ToolTipText = Convert.ToString(marker.id);
            mapMarker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            return mapMarker;
        }
        private GMapOverlay GetOverlayMarkers(List<Marker> markers, GMarkerGoogleType gMarkerGoogleType = GMarkerGoogleType.red)
        {
            string name = "Markers";
            markers = db.getValue();
            GMapOverlay gMapMarkers = new GMapOverlay(name);// создание именованного слоя 
            foreach (Marker marker in markers)
            {
                gMapMarkers.Markers.Add(getMarker(marker, gMarkerGoogleType));// добавление маркеров на слой
                
            }
            return gMapMarkers;
        }
        public void mouseDown(MouseEventArgs e, GMapMarker selectedMarker , GMapControl gMapControler, List<Marker> markers)
        {

            
            if (e.Button == MouseButtons.Left)
            {

                GMapOverlay markersOverlay = GetOverlayMarkers(markers);
               var point = gMapControler.FromLocalToLatLng(e.X, e.Y);
                foreach (var marker_1 in markersOverlay.Markers)
                {
                    if (marker_1.IsMouseOver)
                    {
                        selectedMarker = marker_1;
                        break;
                    }
                }
                selectedMarker = null;    

            }
            
        }

        public void mouseMove(MouseEventArgs e, GMapMarker selectedMarker, GMapControl gMapControler)
        {
            if (e.Button == MouseButtons.Left && selectedMarker != null)
            {
                // Получение новых координат маркера
                var point = gMapControler.FromLocalToLatLng(e.X, e.Y);

                // Обновление позиции маркера
                selectedMarker.Position = point;
            }
        }

        public void addMarker( GMapMarker selectedMarker)
        {
            if (selectedMarker != null)
            {
               
                var point = selectedMarker.Position;
                
                Marker marker = new Marker();
                marker.latitude = point.Lat;
                marker.longitude = point.Lng;
                marker.id = Convert.ToInt32( selectedMarker.ToolTip.Marker.ToolTipText);
                db.addTableValue(marker);
            }
        }
    }
}
