namespace HaberPortali.Models
{
    public class Haber
    {
        public int HaberId { get; set; }
        public string HaberBaslik { get; set; } = null!;

        public string Tarih { get; set; }

        public bool IsActive { get; set; }
    }
}
