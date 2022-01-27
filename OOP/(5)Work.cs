namespace ConsoleApp1
{
    public class Work : zxc
    {
        public int time;
        public int name;
        public Work(int name, int time)
        {
            this.name = name;
            this.time = time;
        }
        public string Output()
        {
            return this.name.ToString() + " - задача        " + this.time.ToString() + " - затрата";
        }
    }
}
