using System.Windows.Controls;
using DateShower.ViewModels;

namespace DateShower.Views;

public partial class DatePickViewControl : UserControl
{
    private DatePickViewModel _viewModel;
    public DatePickViewControl()
    {
        InitializeComponent();
        DataContext = _viewModel = new DatePickViewModel();
    }
}