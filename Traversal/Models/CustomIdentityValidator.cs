using Microsoft.AspNetCore.Identity;

namespace Traversal.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz Minimum {length} Karakter Olmalı"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifrenizde Minimum 1 Adet Büyük Harf Bulunmalı"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifrenizde Minimum 1 Adet Küçüm Harf Bulunmalıdır"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code= "PasswordRequiresNonAlphanumeric",
                Description="Şifrenizde *?!,. vb Minimum 1 Karakter Bulunmalıdır"
            };
        }
        
    }
}
