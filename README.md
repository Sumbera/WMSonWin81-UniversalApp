WMSonWin81
==========

WMSonWin81using universal app for Windows Store and Windows Phone Store apps
Both apps do not share same namespace for map nor component. Windows Store is using Bing Map while Windows Phone is using map control as part of the WP8.1 framework located  in Windows.UI.Xaml.Controls.Maps 

there are 3 projects:
WMSOnWin.Windows
====================

Sample code of using WMS source  on Windows Store Apps using Bing Maps:

                MapTileLayer mapTileLayer = new MapTileLayer();
                mapTileLayer.GetTileUri += delegate(object sender, GetTileUriEventArgs e) {
                  // calc mercator coordinates and return   e.Uri
                };
                
                _bingMap.TileLayers.Add(mapTileLayer);



WMSOnWin.WindowsPhone
====================

Sample code of using WMS on Windows Phone Store App using  Windows.UI.Xaml.Controls.Maps;

                HttpMapTileDataSource dataSource = new HttpMapTileDataSource();
                         dataSource.UriRequested += new TypedEventHandler<HttpMapTileDataSource, MapTileUriRequestedEventArgs>(
                                (source, args) => {
                                                //calc mercator coordinates and return args.Request.Uri
                                });
                 _map.TileSources.Add(new MapTileSource(dataSource));
                


 IMPORTANT: You must set the Active solution platform in Visual Studio to one of the following supported platforms for your app to work correctly. Select BUILD from the main menu, then Configuration Manager.

   
       
- Tested on Visual Studio 2013 Update 2, Windows 8.1 64bit

