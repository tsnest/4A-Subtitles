using System;
using System.IO;

namespace _4A_Subtitles.Models
{
  public class MetroPair
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public void Read(BinaryReader reader, char[] table)
    {
      this.Name = "";
      this.Description = "";
      byte num = 1;
      while (num > (byte) 0)
      {
        num = reader.ReadByte();
        if (num > (byte) 0)
          this.Name += ((char) num).ToString();
      }
      byte index = 1;
      while (index > (byte) 0)
      {
        index = reader.ReadByte();
        if (index > (byte) 0)
          this.Description += table[(int) index].ToString();
      }
    }

    public void Write(BinaryWriter writer, char[] table)
    {
      byte num = 0;
      foreach (char ch in this.Name)
        writer.Write((byte) ch);
      writer.Write(num);
      foreach (char ch in this.Description)
      {
        char c = ch;
        int index = Array.FindIndex<char>(table, (Predicate<char>) (x => (int) x == (int) c));
        if (index == -1)
          throw new ArgumentOutOfRangeException("c");
        writer.Write((byte) index);
      }
      writer.Write(num);
    }
  }
}
