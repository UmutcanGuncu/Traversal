using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.FluentValidation
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator() 
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Lütfen Başlığı Doldurunuz");
            RuleFor(x=>x.Content).NotEmpty().WithMessage("Lütfen İçeriği Doldurunuz");
            RuleFor(x=>x.Title).MinimumLength(4).WithMessage("Duyuru Başlığı Minimum 4 Karakter Uzunuluğunda Olmalıdır");
            RuleFor(x=>x.Content).MinimumLength(10).WithMessage("Duyuru İçeriği Minimum 10 Karakter Uzunuluğunda Olmalıdır");

        }
    }
}
