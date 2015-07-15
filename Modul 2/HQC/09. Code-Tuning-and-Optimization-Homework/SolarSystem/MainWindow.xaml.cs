using System.Windows;

namespace SolarSystem
{
	/// <summary>
	///     Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly OrbitsCalculator _data = new OrbitsCalculator();

		public MainWindow()
		{
			this.DataContext = this._data;
			this.InitializeComponent();
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e) { this._data.StartTimer(); }
		private void Pause_Checked(object sender, RoutedEventArgs e) { this._data.Pause(true); }
		private void Pause_Unchecked(object sender, RoutedEventArgs e) { this._data.Pause(false); }
	}
}