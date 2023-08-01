using Autofac;
using Elastic.CommonSchema.Serilog;
using NeilvynSampleBlueprint.Mobile.Domain;
using NeilvynSampleBlueprint.Mobile.Domain.Logging;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Logging;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Mapping;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
using System;
using System.IO;
using Xamarin.Essentials;

namespace NeilvynSampleBlueprint.Mobile.Shared.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            string loggingPath = Path.Combine(FileSystem.AppDataDirectory, "Logs", "NeilvynSampleBlueprintApp.log");

            builder.RegisterType<ServiceMapper>().As<IServiceMapper>().SingleInstance();
            builder.Register(c => HttpClientProvider.Instance.GetApi<IUserApi>()).As<IUserApi>();

            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                .Enrich.FromLogContext()
                                .WriteTo.File(
                                        new EcsTextFormatter(),     // configure the file in Elastic.CommonSchema format
                                        loggingPath,
                                        LogEventLevel.Information,  // minimum logging information
                                        null, null, false, false,
                                        new TimeSpan(5000),         // flash to file
                                        RollingInterval.Day)

                                // enriching the log template with data that you need (device ID, OS, etc), like using {SourceContext} below
#if __IOS__
                                .WriteTo.NSLog(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj} ({SourceContext}) {Exception}")
#else
                                .WriteTo.AndroidLog(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj} ({SourceContext}) {Exception}")
#endif

                                // The Android emulator assignes to your PC the IP address http://10.0.2.2. Don't use localhost,
                                // as it will point to the device itself. Has to be configured for IOS. This IP is only for development
                                .WriteTo.Seq("http://10.0.2.2:5341")

                                // ElasticSearch doesn't yet work, as can be seen from the logs
                                .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://10.0.2.2:9002"))
                                {
                                    AutoRegisterTemplate = true,
                                })
                                .CreateLogger();

            // maybe Autofac can be configured more elegantly to use Serilog as implementation of Microsoft.Extension.Logging.
            builder.Register(_ => new LoggerFactory(new ILoggerProvider[] { new SerilogLoggerProvider() }))
                   .As<ILoggerFactory>()
                   .SingleInstance();
            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .SingleInstance();

            builder.RegisterType<AppCenterLogger>().As<IAppCenterLogger>().SingleInstance();

#if DEBUG
            // In debug mode, see if something is going wrong with Serilog.
            Serilog.Debugging.SelfLog.Enable(message => System.Diagnostics.Debug.WriteLine($"Serilog debug: {message}"));
#endif
        }
    }
}
