using System.Collections.ObjectModel;

namespace _4A_Subtitles.Models
{
  public class PairsManager
  {
    public static ObservableCollection<MetroPair> _DatabasePairs = new ObservableCollection<MetroPair>();

    public static ObservableCollection<MetroPair> GetPairs() => PairsManager._DatabasePairs;

    public static void AddPair(MetroPair pair) => PairsManager._DatabasePairs.Add(pair);

    public static void DeletePair(int index) => PairsManager._DatabasePairs.RemoveAt(index);

    public static void ReplacePairs(ObservableCollection<MetroPair> pairs)
    {
      PairsManager._DatabasePairs.Clear();
      foreach (MetroPair pair in (Collection<MetroPair>) pairs)
        PairsManager.AddPair(pair);
    }
  }
}
