namespace Eventos.Web.Models
{
    public class EntradaVM
    {
        public int IdEntrada { get; set; }
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime FechaCompra { get; set; }
    }

    public class EntradaCompradaVM
    {
        public int IdEntrada { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string NombreComprador { get; set; }
        public string EmailComprador { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
