public abstract class Payment : IDisposable, IPayment   // Uma classe encapsula código // IDisposable cria uma interface destrutora para a classe   // esta classe sendo abstrata, impede a mesma de ser instanciada
    {
        // construtor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Payment(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // propriedades
        // protected DateTime Maturity;  // visibilidade protected viabiliza filhos enchegarem a mãe

        DateTime IPayment.PaymentDate { get; set; } // get e set simplificado, porém mantém a homogeniedade no código   

        private Address _billingAddress;
        protected Address BillingAddress
        {
            get { return _billingAddress; }
            set { _billingAddress = value; }
        }

        // Métodos

        protected virtual void Pay() { }

        public void Dispose()
        {
            Console.WriteLine("Payment due");
        }
    }

    public class TicketPayment : Payment    // Uma classe sempre pode herdar de outra
    {
        public TicketPayment(DateTime maturity)
        {
            this.Maturity = maturity;
            this.TicketCode = "1234";
        }

        public DateTime Maturity { get; set; }
        private readonly string TicketCode;  // visibilidade private limita à própria classe 

        protected override void Pay()
        {
            base.Pay();
            Console.WriteLine(this.TicketCode);
        }

    }

    public class CreditCardPayment : Payment    // visibilidade public permite a todos enchergarem a classe
    {
        public CreditCardPayment()
        {
            this.CreditCardNumber = "1234";
        }
        private readonly string? CreditCardNumber;

        protected override void Pay()  // Um método pode ter varias formas
        {
            base.Pay();
            Console.WriteLine(this.CreditCardNumber);
        }
    }

    public class Address
    {
        protected string? ZipCode;
        protected string? Number;
    }

    public interface IPayment
    {
        DateTime PaymentDate { get; set; }
    }