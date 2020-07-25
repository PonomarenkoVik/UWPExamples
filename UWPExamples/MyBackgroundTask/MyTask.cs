using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace MyBackgroundTask
{
    public sealed class MyTask : IBackgroundTask
    {

        private BackgroundTaskDeferral _defferal;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _defferal = taskInstance.GetDeferral();
            ShowToastNotification("Hello", "Hi this my first toast!");
            _defferal.Complete();
        }

        private void ShowToastNotification(string title, string content)
        {
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastDoc = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);
            XmlNodeList toastNodeList = toastDoc.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastDoc.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastDoc.CreateTextNode(content));

            ToastNotification toast = new ToastNotification(toastDoc);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);

        }
    }
}
