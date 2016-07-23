namespace Love.Net.Help.Host.Models {
    public class User {
        public User() { }

        public User(string userName) {
            UserName = userName;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
