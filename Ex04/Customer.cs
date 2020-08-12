namespace Ex04
{
    public class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }
        public Customer()
        {

        }

        public string Name { get; private set; }
    }
}