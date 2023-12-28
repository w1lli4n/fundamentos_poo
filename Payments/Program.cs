using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Payments
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var ticketPayment = new TicketPayment(DateTime.Now.AddDays(30))) // using ajuda o garbage colector a limpar memória
            {
                Console.WriteLine(ticketPayment.Maturity);
            }

            var myClass = new PartialClass();

            var customer = new Person();
            var trueCustomer = new Person();
            var personalCustomer = new Personal();
            var corporateCustomer = new Corporate();

            // upcasting
            customer = personalCustomer;    // sem erros. A herança permite o cast implicito pra cima

            // personalCustomer = (Personal)corporateCustomer; // Quando se está no mesmo nível, ocorre o erro

            var genericPerson = new Person("Fulano");
            var anotherGenericPerson = new Person("Fulano");

            Console.WriteLine(genericPerson == anotherGenericPerson);    // retorna falso, pois um objeto éum tipo referenciado, o que significa que sua variavel guarda apenas um endereço de memória

            Console.WriteLine(genericPerson.Equals(anotherGenericPerson));  // Retorna verdadeiro, pois a interface Equatable foi implementada para este objeto
        
            var party = new Room(3);
            
            party.RoomSoldOutEvent += OnRoomSoldOut;    // define a função que será chamada (pois foi apenas delegada), quando o evento ocorrer
            
            for (short i = 0; i < 5; i++)
                party.ReserveSeat();

            //

            var materialTypes = new Material();
            var genericTypes = new Generic<Material>(); // Material implementa um tipo generico válico para Generic
            genericTypes.Method(materialTypes);

            //

            IEnumerable<TicketPayment> payments = new List<TicketPayment>();    // praticamente uma lista readonly
            IList<Person> persons = new List<Person>(); // uma lista mais versátil

            persons.Add(new Person("Willian"));
            persons.Add(new Person("Gabriela"));
            persons.Add(new Person("Luan"));
            persons.Add(new Person("Mateo"));

            foreach (var person in persons)
                Console.WriteLine(person.Name);

            var pia = persons.First(x => x.Name == "Willian");
            // Console.WriteLine(pia.Name);

            persons.Remove(pia);

            foreach (var person in persons)
                Console.WriteLine(person.Name);

            persons.AsEnumerable<Person>(); // tranforma a lista em uma lista IEnurable

        }

        private static void OnRoomSoldOut(object? sender, EventArgs e)  // A assinatura desta função deve ser igual a da função que irá delega-la
        {
            Console.WriteLine("Sold out!");
        }
    }

    public static class Settings    // classes estáticas são carregadas para memória como parte do binário. Ideal para informações vitais e constantes
    {
        public static string DumbSetting = "foo";
    }

    public sealed class UserSettings    // uma classe selada não pode ser herdada. É a forma final da classe
    {
        public string UserDumbSetting = "foo";
    }
}
