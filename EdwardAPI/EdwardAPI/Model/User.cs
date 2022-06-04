using System.ComponentModel.DataAnnotations.Schema;

namespace EdwardAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string API_KEY { get; set; } = string.Empty;
        public string API_SECRET { get; set; } = string.Empty;
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    }

    public class Person
    {
        public int PersonID { get; set; }   
        public string FirstName { get; set; } = string.Empty ;
        public string LastName { get; set; } = string.Empty;

    }
}
