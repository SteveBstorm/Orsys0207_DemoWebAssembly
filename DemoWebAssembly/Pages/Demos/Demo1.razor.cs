namespace DemoWebAssembly.Pages.Demos
{
    public partial class Demo1
    {
        public int Value { get; set; } = 42;

        public void Increment()
        {
            Value++;
        }

        public void Decrement(int x)
        {
            Value-=x;
        }

        public bool Check()
        { return Value < 25; }
    }
}
