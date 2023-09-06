using _4A_Subtitles.Models;

using System.Windows;
using System.Windows.Markup;

namespace _4A_Subtitles
{
  public partial class AddSubtitleWindow : Window, IComponentConnector
  {

    public AddSubtitleWindow() => this.InitializeComponent();

    private void Name_GotFocus(object sender, RoutedEventArgs e) => this.Name.Text = "";

    private void Description_GotFocus(object sender, RoutedEventArgs e) => this.Description.Text = "";

    private void Add_Click(object sender, RoutedEventArgs e)
    {
      string str1 = this.Name.Text.Trim();
      string str2 = this.Description.Text.Trim();
      if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
      {
        int num = (int) MessageBox.Show("You Should Fill Params...", "Empty Fields...", MessageBoxButton.OK, MessageBoxImage.Hand);
      }
      else
      {
        PairsManager.AddPair(new MetroPair()
        {
          Name = str1,
          Description = str2
        });
        this.Close();
      }
    }
  }
}
