using ReactiveUI;
using System;

namespace WpfTemplates.DependencyInjection.Factories;
public interface IViewModelFactory
{
    IRoutableViewModel CreateRoutableViewModel(Type viewModelType);
}