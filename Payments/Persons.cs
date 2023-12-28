namespace Payments
{
    public class Person : IEquatable<Person>
    {
        
        public Person(string? name = "")
        {
            this.Name = name;
        }
        
        public string? Name { get; set; }

        public bool Equals(Person? other)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return this.Name == other.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }

    public class Personal : Person
    {
        public string? CPF;

        public Personal(string? name = "") : base(name)
        {
        }
    }

    public class Corporate : Person
    {
        public string? CNPJ;

        public Corporate(string? name = "") : base(name)
        {
        }
    }
}