using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.FluentValidation
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterrDTO>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Kısmı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Kısmı Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Kısmı Boş Geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Kısmı Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrarı Kısmı Boş Geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Kullanıcı Adı 5 Karakterden Küçük Olamaz");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı Adı 20 Karakterden Büyük Olamaz");
            RuleFor(x=>x.Password).Equal(y=> y.ConfirmPassword).WithMessage("Şifreler Birbiri İle Uyuşmuyor");
        }
    }
}
