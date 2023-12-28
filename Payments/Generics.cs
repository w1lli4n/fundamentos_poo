namespace Payments
{
    public class Generic<T> // Está classe aceita genéricos como tipos de parametros
        where T : IGeneric  // Neste caso, T pode ser apenas um tipo que implemente a interface IGeneric
    {
        public void Method(T parameter)
        {
            // T pode ser qualquer tipo
        }
    }

    public interface IGeneric   // Interface
    {

    }

    public class Material : IGeneric    // Material implementa a interface IGeneric, por tanto é um tipo válido para Generic.Method(T)
    {

    }
}