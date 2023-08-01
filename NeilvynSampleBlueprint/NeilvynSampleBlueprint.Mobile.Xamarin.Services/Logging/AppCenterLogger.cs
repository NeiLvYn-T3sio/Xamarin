using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Domain.Logging;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Logging
{
    [ExcludeFromCodeCoverage]
    public class AppCenterLogger : IAppCenterLogger
    {
        public async Task Init()
        {
            await InitializeAnalyticsReport();
            await InitializeCrashReport();
        }

        public void LogError<T>(Exception exception, string payloadName, T payload) where T : class
        {
            var payloadString = JsonConvert.SerializeObject(payload);
            Crashes.TrackError(exception, null, ErrorAttachmentLog.AttachmentWithText(payloadString, $"{payloadName}.json"));
        }

        public void LogError(Exception exception, IDictionary<string, string> properties = null)
            => Crashes.TrackError(exception, properties);

        public void LogEvent(string name, IDictionary<string, string> properties = null)
            => Analytics.TrackEvent(name, properties);

        private static Task InitializeAnalyticsReport() => Analytics.SetEnabledAsync(true);

        private static async Task InitializeCrashReport()
        {
            Crashes.SendingErrorReport += (sender, e) =>
            {
                AppCenterLog.Info(AppConstants.AppCenterLogTag, "Sending error report");

                var args = e;
                var report = args.Report;
                LogReport(report, null);
            };

            Crashes.SentErrorReport += (sender, e) =>
            {
                AppCenterLog.Info(AppConstants.AppCenterLogTag, "Sent error report");

                var args = e;
                var report = args.Report;
                LogReport(report, null);
            };

            Crashes.FailedToSendErrorReport += (sender, e) =>
            {
                AppCenterLog.Info(AppConstants.AppCenterLogTag, "Failed to send error report");

                var args = e;
                var report = args.Report;
                LogReport(report, e.Exception);
            };

            Crashes.ShouldAwaitUserConfirmation = AskForCrashSendingPermission;

            await Crashes.SetEnabledAsync(true);
        }

        private static bool AskForCrashSendingPermission()
        {
            Analytics.TrackEvent("CrashReportPermission");
            //  TODO: Crash Reporting Confirmation Dialog
            //  Build your own UI to ask for user consent here. SDK doesn't provide one by default.
            //  Return true if you built a UI for user consent and are waiting for user input on that custom UI, otherwise false.
            return false;
        }


        private static void LogReport(ErrorReport report, object exception)
        {
            if (!string.IsNullOrEmpty(report.StackTrace))
            {
                AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.StackTrace);
            }
            else
            {
                AppCenterLog.Verbose(AppConstants.AppCenterLogTag, "No system exception was found");
            }

            if (report.AndroidDetails != null)
            {
                AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.AndroidDetails.ThreadName);
            }
            else if (report.iOSDetails != null)
            {
                AppCenterLog.Verbose(AppConstants.AppCenterLogTag, report.iOSDetails.ExceptionName);
            }

            if (exception != null)
            {
                AppCenterLog.Verbose(AppConstants.AppCenterLogTag, "There is an exception associated with the failure");
            }
        }
    }
}
