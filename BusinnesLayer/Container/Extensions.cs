using BusinnesLayer.Abstract;
using BusinnesLayer.Abstract.AbstractUnitOfWork;
using BusinnesLayer.Concrete;
using BusinnesLayer.Concrete.UnitOfWorkConcrete;
using BusinnesLayer.FluentValidation;
using BusinnesLayer.FluentValidation.AnnouncementValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinnesLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EFGuideDAL>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EFContactDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IAccountService,AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();
            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();

        }
        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTO>, AnnouncementUpdateValitation>();
        }
    }
}
