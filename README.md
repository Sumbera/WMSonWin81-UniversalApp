WMSonWin81
==========

WMSonWin81using universal app for Windows Store and Windows Phone Store apps


WMSOnWin.Windows
====================

Sample code of using WMS source  on Windows Store Apps using Bing Maps
Adding WMS is using MapTileLayer contained in custom 'wrapper' class WMSTileLayer as MapTileLayer is sealed
Then adding wmsLayer to the map is trivial:

                WMSTileLayer wmsLayer = new WMSTileLayer(@"http://services.cuzk.cz/wms/wms.asp?&LAYERS=KN&REQUEST=GetMap&SERVICE=WMS&VERSION=1.3.0&FORMAT=image/png&TRANSPARENT=TRUE&STYLES=&CRS=EPSG:900913&WIDTH=256&HEIGHT=256&BBOX={0},{1},{2},{3}");
                _bingMap.TileLayers.Add(wmsLayer.mapTileLayer);


 IMPORTANT: You must set the Active solution platform in Visual Studio to one of the following supported platforms for your app to work correctly. Select BUILD from the main menu, then Configuration Manager.

    Choose one of the following supported solution platforms for the current project: ARM, x86 or x64

        
- Tested on Visual Studio 2013 Update 2, Windows 8.1 64bit

- Same way of displaying WMS has been used for example in this Windows Store app: http://apps.microsoft.com/windows/en-us/app/ikatastr/76a1b39a-d013-4859-a128-7085c9a4fede
- you will need to provide your Bing key 


WMSOnWin.WindowsPhone
====================

Sample code of using WMS on Windows Phone Store App using  Windows.UI.Xaml.Controls.Maps;

                HttpMapTileDataSource dataSource = new HttpMapTileDataSource();
                         dataSource.UriRequested += new TypedEventHandler<HttpMapTileDataSource, MapTileUriRequestedEventArgs>(
                                (source, args) => {
                                                //calc mercator coordinates and return args.Request.Uri
                                });
                 _map.TileSources.Add(new MapTileSource(dataSource));
                
