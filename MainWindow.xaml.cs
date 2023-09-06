using _4A_Subtitles.Models;
using _4A_Subtitles.ViewModels;

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace _4A_Subtitles
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private MetroLocalization _mLocalization;

    public MainWindow()
    {
      this.InitializeComponent();
      this.DataContext = (object) new MainViewModel();
      this._mLocalization = new MetroLocalization();
    }

    public void ImportLocalization()
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Select Metro Localization";
        openFileDialog.Filter = "Metro Localization (*.lng) | *.lng";
        bool? nullable1 = openFileDialog.ShowDialog();
        if (nullable1.HasValue)
        {
          bool? nullable2 = nullable1;
          bool flag = false;
          if (!(nullable2.GetValueOrDefault() == flag & nullable2.HasValue))
          {
            string path = openFileDialog.FileName.Trim();
            if (!path.EndsWith(".lng"))
            {
              int num = (int) MessageBox.Show("Incorrect File Path...", "Localization Bad Format...", MessageBoxButton.OK, MessageBoxImage.Hand);
              return;
            }
            using (FileStream input = File.OpenRead(path))
            {
              using (BinaryReader reader = new BinaryReader((Stream) input))
              {
                this._mLocalization.Read(reader);
                PairsManager.ReplacePairs(this._mLocalization.MetroPairs);
                return;
              }
            }
          }
        }
        int num1 = (int) MessageBox.Show("You should select MetroLocalization File...", "Localization Doesn't Select...", MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Application Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        MyLogger.Write(ex.Message, LogType.Error);
      }
    }

    public void ExportLocalization()
    {
      try
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Title = "Select Metro Localization";
        saveFileDialog.Filter = "Metro Localization (*.lng) | *.lng";
        bool? nullable1 = saveFileDialog.ShowDialog();
        if (nullable1.HasValue)
        {
          bool? nullable2 = nullable1;
          bool flag = false;
          if (!(nullable2.GetValueOrDefault() == flag & nullable2.HasValue))
          {
            string path = saveFileDialog.FileName.Trim();
            if (!path.EndsWith(".lng"))
            {
              int num = (int) MessageBox.Show("Incorrect File Path...", "Localization Bad Format...", MessageBoxButton.OK, MessageBoxImage.Hand);
              return;
            }
            using (FileStream output = File.OpenWrite(path))
            {
              using (BinaryWriter writer = new BinaryWriter((Stream) output))
              {
                this._mLocalization.MetroPairs = PairsManager.GetPairs();
                this._mLocalization.Write(writer);
                int num = (int) MessageBox.Show("Metro Localization Saved By Path: '" + path + "'", "Localization Saved!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
              }
            }
          }
        }
        int num1 = (int) MessageBox.Show("You should select MetroLocalization File...", "Localization Doesn't Select...", MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message, "Application Error", MessageBoxButton.OK, MessageBoxImage.Hand);
        MyLogger.Write(ex.Message, LogType.Error);
      }
    }

    public bool FilterPair(object obj)
    {
      MetroPair metroPair = (MetroPair) obj;
      string str = this.SearchText.Text.Trim();
      return metroPair.Name.Contains(str) || metroPair.Description.Contains(str);
    }

    private void ImportAction_Click(object sender, RoutedEventArgs e) => this.ImportLocalization();

    private void ExportAction_Click(object sender, RoutedEventArgs e) => this.ExportLocalization();

    private void SearchAction_Click(object sender, RoutedEventArgs e) => this.PairsList.Items.Filter = new Predicate<object>(this.FilterPair);

    private void SearchText_GotFocus(object sender, RoutedEventArgs e) => this.SearchText.Text = "";

    private void PairsList_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key != Key.Delete || this.PairsList.SelectedIndex == -1 || MessageBox.Show("Are you sure to delete this value?", "Are you?", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
        return;
      PairsManager.DeletePair(this.PairsList.SelectedIndex);
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
