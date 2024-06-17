using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace Recipe_app
{
    #if DEBUG                                   // connect to local service on the
    [Application(UsesCleartextTraffic = true)]  // emulator's host for debugging,
    #else                                       // access via http://10.0.2.2
    [Application]                               
    #endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        {
            // Remove Entry control underline
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.LightGray.ToAndroid());
            });
            return MauiProgram.CreateMauiApp();
        }
    }
            
}
