using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Pattern.Dog
{
  public interface IDog
  {
    string Bark { get; }

    string Walk { get; }
  }
}
