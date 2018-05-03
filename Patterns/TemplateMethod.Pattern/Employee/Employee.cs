using TemplateMethod.Pattern.Worker;

namespace TemplateMethod.Pattern.Employee
{
    public abstract class Employee
    {

        public abstract IWorker DoWork();

        public IWorker Work()
        {
            return DoWork();
        }

    }
}
