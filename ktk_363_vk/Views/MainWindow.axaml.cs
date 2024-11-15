using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using ktk_363_vk.Models;
using ktk_363_vk.ViewModels;

namespace ktk_363_vk.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext =  new BookViewModel();
    }
}