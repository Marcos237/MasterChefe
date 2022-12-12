namespace Api.MasterChefe.Domain.Entidades
{
    public class Eventos
    {
        public Guid Id { get; set; }
        public string? Nome{ get; set; }
        public string? Menssagem{ get; set; }
        public List<string>? eventos { get;}
        public DateTime? DataEvento { get;}

        public Eventos()
        {
            Id = Guid.NewGuid();
            DataEvento = DateTime.Now;
            eventos = new List<string>();
        }
    }
}
