namespace SignalRAssignment.Models
{
    public enum AccountType
    {
        Member,
        Staff
    }
    public class Account
    {
        //AccountId, AccountName, password, fullname, type
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; }
        public AccountType AccountType
        {
            get => (AccountType)this.Type;
            set => this.Type = (int)value;
        }
    }
}
