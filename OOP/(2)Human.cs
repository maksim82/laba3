namespace ConsoleApp1
{
    public abstract class Human : zxc
    {
        public int time;
        public int name;
        public Human (int name, int time)
        {
            this.name = name;
            this.time = time;
        }

        public abstract string Output();
    }
}
