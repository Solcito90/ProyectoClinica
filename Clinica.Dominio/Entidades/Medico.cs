namespace Clinica.Dominio.Entidades
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;
    }
}
