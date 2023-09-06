using System.IO;

namespace _4A_Subtitles
{
  public static class MyLogger
  {
    public static readonly string LoggerPath = "./MyLogs.log";

    public static void Write(string message, LogType type = LogType.Info)
    {
      if (string.IsNullOrEmpty(message))
        return;
      File.AppendAllText(MyLogger.LoggerPath, string.Format("[{0}]: {1}", (object) type, (object) message));
    }

    public static bool Contains(string message) => !string.IsNullOrEmpty(message) && File.Exists(MyLogger.LoggerPath) && File.ReadAllText(MyLogger.LoggerPath).Contains(message);
  }
}
