using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BackgroundTasks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void PlayButtonClick(object sender, RoutedEventArgs e)
        {
            //var task = new BackgroundTaskBuilder()
            //{
            //    Name = "MyTask",
            //    TaskEntryPoint = typeof(MyBackgroundTask.MyTask).ToString()
            //};

            //var trigger = new ApplicationTrigger();
            //task.SetTrigger(trigger);
            //task.Register();
            //await trigger.RequestAsync();

            string myTaskName = "MyBackgroundTask";

            foreach (var task in BackgroundTaskRegistration.AllTasks)
            { 
                if (task.Value.Name == myTaskName)
                {
                    await (new MessageDialog("Task already registered")).ShowAsync();
                    return;
                }
            }

            await BackgroundExecutionManager.RequestAccessAsync();
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder()
            {
                Name = "SecondTask",
                TaskEntryPoint = "MyBackgroundTask.MyTask"
            };

            taskBuilder.SetTrigger(new TimeTrigger(15, true));
            BackgroundTaskRegistration mytask = taskBuilder.Register();

            await (new MessageDialog("Task Registered")).ShowAsync();

        }
    }
}
