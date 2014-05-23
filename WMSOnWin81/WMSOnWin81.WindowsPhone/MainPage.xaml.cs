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


using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WMSOnWin81{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        MapControl _map;
        string _wmsUrl = @"http://services.cuzk.cz/wms/wms.asp?&LAYERS=KN&REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&FORMAT=image/png&TRANSPARENT=TRUE&STYLES=&CRS=EPSG:900913&WIDTH=256&HEIGHT=256&BBOX={0},{1},{2},{3}";

        public MainPage()  {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;


            _map = new MapControl();
            _map.MapServiceToken = "yourtoken";
            BasicGeoposition center = new BasicGeoposition();
            center.Latitude = 50.07574;
            center.Longitude = 14.416;
            _map.Center = new Geopoint(center);
            _map.ZoomLevel = 17;

            HttpMapTileDataSource dataSource = new HttpMapTileDataSource();
            dataSource.UriRequested += new TypedEventHandler<HttpMapTileDataSource, MapTileUriRequestedEventArgs>(
                (source, args) => {
                    Rect mercBounds = GlobalMercator.TileBounds(new Tile(args.X, args.Y), args.ZoomLevel);
                    args.Request.Uri = new Uri(string.Format(_wmsUrl, mercBounds.Left, Math.Abs(mercBounds.Bottom), mercBounds.Right, Math.Abs(mercBounds.Top))); ;
                });

            _map.TileSources.Add(new MapTileSource(dataSource));
            this.Content = _map;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
