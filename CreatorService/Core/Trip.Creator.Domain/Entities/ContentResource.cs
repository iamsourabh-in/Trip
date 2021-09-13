using System.ComponentModel.DataAnnotations.Schema;

namespace Trip.Creator.Domain.Entities
{
    public class CreationResource
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public Creation Creation { get; set; }
    }
}