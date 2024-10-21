using Microsoft.Extensions.Logging;
using PhoneBookMaui.services;
using PhoneBookMaui.view;
using PhoneBookMaui.viewModel;

namespace PhoneBookMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //רישום של דפים
            builder.RegisterView().RegisterViewModel().Registerservice();
            return builder.Build();
        }
        public static MauiAppBuilder RegisterView(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AddUserPage>();
            builder.Services.AddSingleton<EditUserPage>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<LogINPage>();
            builder.Services.AddSingleton<SignInPage>();
            builder.Services.AddSingleton<UserList>();
            return builder;

        }
        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AddUserVM>();
            builder.Services.AddSingleton<EditUserVM>();
            //builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddSingleton<LogInVM>();
            builder.Services.AddSingleton<SignUserVM>();
            builder.Services.AddSingleton<UserListVM>();
            return builder;

        }
        public static MauiAppBuilder Registerservice(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IUsers,UserService>();
          
            return builder;

        }
    }
}
