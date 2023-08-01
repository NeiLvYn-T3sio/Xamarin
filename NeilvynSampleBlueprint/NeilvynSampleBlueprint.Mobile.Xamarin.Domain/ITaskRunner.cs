using System;
using System.Threading;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain
{
    public interface ITaskRunner
    {
        Task RunAsync(Func<Task> task);
        Task Delay(int ms);
        Task Delay(TimeSpan timeSpan, CancellationToken token);
        void StartTimer(TimeSpan timeSpan, Func<bool> func);
        void DeviceRunMainThread(Action action);
        Task<T> RunMainThreadAsync<T>(Func<Task<T>> task);
        Task RunMainThreadAsync(Func<Task> task);
        Task RunMainThreadAsync(Action action);
        void Run(Func<Task> task);
    }
}