using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode.Core.Tests.Samples
{
  public static class EmbededResourceHelper
  {
    public static string ReadResource(string resourceName, Assembly getExecutingAssembly)
    {
      var assembly = getExecutingAssembly;
      using (Stream stream = assembly.GetManifestResourceStream(resourceName))
      {
          if (stream == null) throw new Exception(string.Format("{0} not found.", resourceName));
           return new StreamReader(stream).ReadToEnd();
      }
        
    }
   
  }
}