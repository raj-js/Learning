using System.ComponentModel.DataAnnotations;

namespace LearningEfCore
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [ConcurrencyCheck]
        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }
    }
}
