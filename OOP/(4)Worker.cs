namespace ConsoleApp1
{
    public class Worker : Human
    {
        public Worker(int name, int time) : base (name, time) {}

        public override string Output()




        {
            return this.name.ToString() + " - сотрудник";
        }
    }
}
