namespace ConsoleApp1
{
    public class TeamLead : Human
    {
        public Worker[] workers;

        public TeamLead(int name, int time) : base(name, time) { }
        public override string Output()
        {
            return this.name.ToString() + " - управляющий";
        }
    }
}
