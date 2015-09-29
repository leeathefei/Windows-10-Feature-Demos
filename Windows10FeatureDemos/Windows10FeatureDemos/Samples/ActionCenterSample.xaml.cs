using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;

namespace Windows10FeatureDemos.Samples
{
    [Menu(Caption = "Action Center", Symbol = Symbol.ClosePane)]
    public sealed partial class ActionCenterSample : UserControl
    {
        public ActionCenterSample()
        {
            this.InitializeComponent();
        }

        private void DeliverToastButton_Click(object sender, RoutedEventArgs e)
        {
            DeliverToast();
        }

        private async void DeliverToast()
        {
            // Generate a new message data item - this 
            // Simulates a toast coming in from your cloud backend
            var msgItem = new MessageItem()
            {
                ID = Guid.NewGuid().ToString().Split('-')[0].ToString(),
                Title = "Hello Msg #" + System.Environment.TickCount,
                Body = "This is a new message created at " + System.DateTime.Now.ToString("t"),
                IsRead = false
            };

            // Send a toast notification to alert the user of the new item
            // Send the Toast Notification informing the user of a new message
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(msgItem.Title));

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");

            ((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"param1\":\"" + msgItem.ID + "\",\"param2\":\"0\"}");

            ToastNotification toast = new ToastNotification(toastXml);

            // Tag the Toast with the data item ID
            // Note that Toasts sent from servers set the Tag through an HTTP Header
            toast.Tag = msgItem.ID;

            ToastNotificationManager.CreateToastNotifier().Show(toast);

            // Update the Main Tile
            // SetBadgeCountOnTileandSim();

            // Save the new messageItem to our local storage
            // await _repository.AddAsync(msgItem);

            // Update our list of MessageItems shown on our UI
            //await LoadRuntimeDataAsync();

        }
    }

    public sealed class MessageItem
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
    }

}