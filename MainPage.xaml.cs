
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

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
			await Parse();
			cvs.Source = ModelsList; //.GroupBy(x => x.Amount);
		}

		private async Task Parse()
		{
			var a = new XMLParser();
			ModelsList = await a.ParseFile<LHVReportModel>(file);
			
		}

		//private void Button_Click(object sender, RoutedEventArgs e)
		//{
		//	if (sender is ToggleButton button && button.IsChecked.Value)
		//	{
		//		cvs.IsSourceGrouped = true;
		//		cvs.Source = ModelsList.GroupBy(x => x.Side);
		//	}
		//	else
		//	{
		//		cvs.IsSourceGrouped = false;
		//		cvs.Source = ModelsList;
		//	}
		//}
	}
}
