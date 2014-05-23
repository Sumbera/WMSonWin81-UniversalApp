using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Bing.Maps;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WMSOnWin81
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page{
        Bing.Maps.Map _bingMap;
        string _wmsUrl = @"http://services.cuzk.cz/wms/wms.asp?&LAYERS=KN&REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&FORMAT=image/png&TRANSPARENT=TRUE&STYLES=&CRS=EPSG:900913&WIDTH=256&HEIGHT=256&BBOX={0},{1},{2},{3}";

      
    
        public MainPage() {
            this.InitializeComponent();
            this.Loaded += delegate {
                _bingMap = new Bing.Maps.Map();
                _bingMap.Center = new Location(50.07574, 14.416);
                _bingMap.ZoomLevel = 17;

                MapTileLayer mapTileLayer = new MapTileLayer();
                mapTileLayer.GetTileUri += delegate(object sender, GetTileUriEventArgs e) {
                    int z = e.LevelOfDetail;
                    int x = e.X;
                    int y = e.Y;

                    Rect mercBounds = GlobalMercator.TileBounds(new Tile(x, y), z);
                    e.Uri = new Uri(string.Format(_wmsUrl, mercBounds.Left, Math.Abs(mercBounds.Bottom), mercBounds.Right, Math.Abs(mercBounds.Top)));
                };

                _bingMap.TileLayers.Add(mapTileLayer);
                this.Content = _bingMap;


            };
        }
    }
}
