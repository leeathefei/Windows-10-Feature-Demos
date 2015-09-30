using System;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Live Tiles")]
    public sealed partial class LiveTileSamples : UserControl
    {
        // TODO: Implement Live Tile Samples

        public LiveTileSamples()
        {
            this.InitializeComponent();
        }

        private void _updateLiveTile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            UpdateLiveTile();
        }

        private void UpdateLiveTile()
        {
            // build badge
            var type = BadgeTemplateType.BadgeNumber;
            var xml = BadgeUpdateManager.GetTemplateContent(type);

            // update element
            var elements = xml.GetElementsByTagName("badge");
            var element = elements[0] as Windows.Data.Xml.Dom.XmlElement;

            int rnd = new Random().Next(100);

            element.SetAttribute("value", rnd.ToString());

            // send to lock screen
            var updator = BadgeUpdateManager.CreateBadgeUpdaterForApplication();
            var notification = new BadgeNotification(xml);
            updator.Update(notification);

        }

        private void _createSecondaryLiveTile_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CreateSecondaryTile();
        }

        private async void CreateSecondaryTile()
        {
            var tileId = "DetailsTile";
            var pinned = SecondaryTile.Exists(tileId);

            if (!pinned)
            {
                var tile = new SecondaryTile(tileId)
                {
                    DisplayName = "Record details"
                };

                // extra details
                var success = await tile.RequestCreateAsync();
            }

        }

    }
}
