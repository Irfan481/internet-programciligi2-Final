using HaberPortali.Models;

namespace HaberPortali.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Page { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
