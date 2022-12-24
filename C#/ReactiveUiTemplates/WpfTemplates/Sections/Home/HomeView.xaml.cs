﻿using ReactiveUI;
using System.Reactive.Disposables;

namespace WpfTemplates.Sections.Home;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, vm => vm.MessageText, v => v.messageTextBlock.Text)
                .DisposeWith(disposables);
        });
    }
}
