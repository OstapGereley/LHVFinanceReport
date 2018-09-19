
using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LHVFinanceReport
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

		private async void Button_Click(object sender, RoutedEventArgs e)
		{

			var openPicker = new FileOpenPicker();
			openPicker.ViewMode = PickerViewMode.Thumbnail;
			openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
			openPicker.FileTypeFilter.Add(".txt");
			openPicker.FileTypeFilter.Add(".xml");

			var file = await openPicker.PickSingleFileAsync();
			FilePathBox.Text = file.DisplayName;
		}

	
	}
}
