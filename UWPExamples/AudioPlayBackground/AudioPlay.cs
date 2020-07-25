using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace AudioPlayBackground
{
    public sealed class AudioPlay : IBackgroundTask
    {
        private BackgroundTaskDeferral _defferal;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _defferal = taskInstance.GetDeferral();
            taskInstance.Task.Completed += Task_Completed;
        }

        private void Task_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            _defferal.Complete();
        }
    }
}
