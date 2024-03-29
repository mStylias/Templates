﻿using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using WpfTemplates.Sections.Home;
using WpfTemplates.Sections.Settings;

namespace WpfTemplates.DependencyInjection;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddTransient<IViewFor<HomeViewModel>, HomeView>();
        services.AddTransient<IViewFor<SettingsViewModel>, SettingsView>();

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();

        return services;
    }
}
