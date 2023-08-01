using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common
{
    [ExcludeFromCodeCoverage]
    public class TaskRunner : ITaskRunner
    {
        public void Run(Func<Task> task)
        {
            Task.Run(task);
        }

        public async Task RunAsync(Func<Task> task)
        {
            await Task.Run(task);
        }

        public async Task RunMainThreadAsync(Action action)
        {
            if (Device.IsInvokeRequired)
            {
                await Device.InvokeOnMainThreadAsync(action);
                return;
            }

            action?.Invoke();
        }
        
        public async Task RunMainThreadAsync(Func<Task> task)
        {
            if (task == null)
            {
                return;
            }

            if (Device.IsInvokeRequired)
            {
                await Device.InvokeOnMainThreadAsync(task);
                return;
            }

            await task.Invoke();
        }

        public async Task<T> RunMainThreadAsync<T>(Func<Task<T>> task)
        {
            if (task == null)
            {
                return default;
            }

            if (Device.IsInvokeRequired)
            {
                return await MainThread.InvokeOnMainThreadAsync(task);
            }

            return await task.Invoke();
        }

        public Task Delay(int ms)
        {
            return Task.Delay(ms);
        }

        public Task Delay(TimeSpan timeSpan, CancellationToken token)
        {
            return Task.Delay(timeSpan, token);
        }

        public void StartTimer(TimeSpan timeSpan, Func<bool> func)
        {
            Device.StartTimer(timeSpan, func);
        }

        public void DeviceRunMainThread(Action action)
        {
            if (MainThread.IsMainThread)
            {
                MainThread.BeginInvokeOnMainThread(action);
                return;
            }

            action?.Invoke();
        }
    }
}
