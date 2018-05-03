using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Pattern.Dog
{
  public class BorderCollie : IDog
  {
    public string Bark => "Bark";
    public string Walk => "Walk Very Fast";
  }
}
