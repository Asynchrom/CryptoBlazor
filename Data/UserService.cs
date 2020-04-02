namespace CryptoBlazor.Data
{
    public class UserService
    {
        public bool Authenthicated { get; set; }

        public UserService() {
            Authenthicated = false;
        }
    }
}
