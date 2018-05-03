using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adapter.Pattern.Dog;

namespace Adapter.Pattern.Bear
{
    public class DogAdapter : IBear
    {
        private IDog _dog;

        public DogAdapter(IDog dog)
        {
            _dog = dog;
        }

        public string Roar => _dog.Bark;
        public string Walk => _dog.Walk;
    }
}
