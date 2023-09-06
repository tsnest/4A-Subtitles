using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace _4A_Subtitles.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (_4A_Subtitles.Properties.Resources.resourceMan == null)
          _4A_Subtitles.Properties.Resources.resourceMan = new ResourceManager("_4A_Subtitles.Properties.Resources", typeof (_4A_Subtitles.Properties.Resources).Assembly);
        return _4A_Subtitles.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => _4A_Subtitles.Properties.Resources.resourceCulture;
      set => _4A_Subtitles.Properties.Resources.resourceCulture = value;
    }
  }
}
