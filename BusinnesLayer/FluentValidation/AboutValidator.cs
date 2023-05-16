using EntityLayer.Entityies;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Boş Geçilemez");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama Minimum 10 Karakter Olmalıdır");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Açıklama Maksimum 1500 Karakter Olmalıdır");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Görsel Seçiniz");

        }
    }
}
