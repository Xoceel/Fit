using Fit.Data;
using Fit.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace Fit
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            string licenseKey = Environment.GetEnvironmentVariable("SYNCF_LICENSE");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<WeightTrackingPage>();
            builder.Services.AddSingleton<FitnessDatabase>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
