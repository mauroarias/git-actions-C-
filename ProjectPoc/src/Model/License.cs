namespace GenesisMock.Model;

public record License
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public string email { get; set; } = null!;
    public DateTime expires_at { get; set; }
    
    public class Builder
    {
        private License user = new License();
        
        public static Builder Init()
        {
            return new Builder();
        }
        
        public Builder SetId(Guid id)
        {
            user.id = id;
            return this; 
        }
        
        public Builder SetName(string name)
        {
            user.name = name;
            return this; 
        }
        
        public Builder SetEmail(string email)
        {
            user.email = email;
            return this; 
        }

        public Builder SetExpiresAt(DateTime expiresAt)
        {
            user.expires_at = expiresAt;
            return this; 
        }

        public License Build()
        {
            return user;
        }
    }
}