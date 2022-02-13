using System.ComponentModel.DataAnnotations;

namespace Food_shop_backend.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Nacimiento { get; set; } 
        public string Email { get; set; }
        public int Telefono { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Edad = 0;
            Nacimiento = DateTime.Now.Date;
            Email = string.Empty;
            Telefono = 0;
        }

        public Clientes(int clienteId, string nombre, string apellido, int edad, DateTime nacimiento, string email, int telefono)
        {
            ClienteId = clienteId;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Nacimiento = nacimiento;
            Email = email;
            Telefono = telefono;
        }
    }
}
