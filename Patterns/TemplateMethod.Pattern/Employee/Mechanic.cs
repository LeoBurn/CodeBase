using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMethod.Pattern.Worker;

namespace TemplateMethod.Pattern.Employee
{
    public class Mechanic : Employee
    {
        public override IWorker DoWork()
        {
            return new MechanicWorker();
        }
    }
}
