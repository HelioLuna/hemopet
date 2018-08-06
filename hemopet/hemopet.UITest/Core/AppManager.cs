using System;
using Xamarin.UITest;

namespace hemopet.UITest.Core
{
    static class AppManager
    {
        public static IApp app;

        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' é igual a NULL. Chame 'AppManager.StartApp()' antes de acessar.");
                return app;
            }
        }

        public static Platform? platform;

        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' é igual a NULL.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            if (platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .ApkFile("../../../hemopet.Droid/bin/Debug/com.sesau.apk")
                    .Debug()
                    .StartApp();
            }

            if (platform == Platform.iOS)
            {
                app = ConfigureApp
                    .iOS
                    .AppBundle("path/to/iOSapp.app" + "EXAMPLE:" + "../../../iOSAppProject/bin/iPhoneSimulator/Debug/iosapp.app")
                    .Debug()
                    .StartApp();
            }
        }
    }
}
