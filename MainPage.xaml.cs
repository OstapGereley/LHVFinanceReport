
using System;
using System.Collections.Generic;
using Windows.Storage;
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
		private StorageFile file;
		public List<LHVReportModel> ModelsList { get; set; }
		public MainPage()
		{
			InitializeComponent();
		}

		private async void AddFileButtonClick(object sender, RoutedEventArgs e)
		{
			var openPicker = new FileOpenPicker
			{
				ViewMode = PickerViewMode.Thumbnail,
				SuggestedStartLocation = PickerLocationId.PicturesLibrary
			};
			openPicker.FileTypeFilter.Add(".txt");
			openPicker.FileTypeFilter.Add(".xml");

			file = await openPicker.PickSingleFileAsync();
			FilePathBox.Text = file.DisplayName;
			Parse();
		}

		private async void Parse()
		{
			var a = new XMLParser();
			MyGrid.ItemsSource = await a.ParseFile<LHVReportModel>(file);
		}

	
	}
}
