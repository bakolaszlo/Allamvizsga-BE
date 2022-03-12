using System.ComponentModel.DataAnnotations;

namespace DataManager.Model
{
    public class UserCryptTable
    {
        [Key]
        public string Name { get; set; }
        public string EncryptedName { get; set; }
    }
}
