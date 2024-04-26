using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace SuperParser.Pages;

public partial class ParseOutputPage : ReactiveUserControl<UserControl>
{
    public ParseOutputPage()
    {
        InitializeComponent();
    }
}