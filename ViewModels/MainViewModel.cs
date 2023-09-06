using _4A_Subtitles.Commands;
using _4A_Subtitles.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace _4A_Subtitles.ViewModels
{
  public class MainViewModel
  {
    public ObservableCollection<MetroPair> Pairs { get; set; }

    public ICommand ShowWindowCommand { get; set; }

    public MainViewModel()
    {
      this.Pairs = PairsManager.GetPairs();
      this.ShowWindowCommand = (ICommand) new RelayCommand(new Action<object>(this.ShowWindow), new Predicate<object>(this.CanShowWindow));
    }

    private bool CanShowWindow(object obj) => true;

    private void ShowWindow(object obj)
    {
      Window window = obj as Window;
      AddSubtitleWindow addSubtitleWindow = new AddSubtitleWindow();
      addSubtitleWindow.Owner = window;
      addSubtitleWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      addSubtitleWindow.Show();
    }
  }
}
