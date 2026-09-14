namespace Eventos.Web.Services
{
    public interface ISumatoriaService
    {
        int Sumar(int a, int b);
    }

    public class SumatoriaService : ISumatoriaService
    {

        public SumatoriaService() { }

        public int Sumar(int a, int b)
        {
            return a + b;
        }
    }
}
