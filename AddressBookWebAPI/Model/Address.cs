using System.ComponentModel.DataAnnotations;

namespace AddressBookWebAPI.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string email { get; set; }
        public long phone { get; set; }
        public long landline { get; set; }
        public string website { get; set; }
        public string AddressDetails { get; set; }

    }
}
