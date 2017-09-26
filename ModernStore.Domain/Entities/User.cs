using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password, string confirmPassword)
        {
            this.Username = username;
            this.Password = EncryptPassword(password);
            this.Active = true;

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(confirmPassword), "The Password and Confirmation Password are not equals");
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool Active { get; private set; }

        public void Activate() => this.Active = true;

        public void DeActivate() => this.Active = false;

        private static string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            pass += "|54be1d80-b6d0-45c0-b8d7-13b3c798729f";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(pass));
            var sbString = new System.Text.StringBuilder();

            for (var i = 0; i < data.Length; i++)
                sbString.Append(data[i].ToString("x2"));

            return sbString.ToString();
        }
    }
}
