using Business.Abstract;
using Business.Concrete;
using Business.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;

namespace FinalProjectWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();


            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;
                options.User.RequireUniqueEmail = true;

            });

            //builder.Services.AddDbContext<ApplicationDbContext>();

        

            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDal, AboutDal>();
            builder.Services.AddScoped<IValidator<About>, AboutValidation>();

            builder.Services.AddScoped<IAboutCountService, AboutCountManager>();
            builder.Services.AddScoped<IAboutCountDal, AboutCountDal>();
            builder.Services.AddScoped<IValidator<AboutCount>, AboutCountValidation>();

            builder.Services.AddScoped<IBusinessCatService, BusinessCatManager>();
            builder.Services.AddScoped<IBusinessCatDal, BusinessCatDal>();
            builder.Services.AddScoped<IValidator<BusinessCat>, BusinessCatValidation>();

            builder.Services.AddScoped<ICallMeService, CallMeManager>();
            builder.Services.AddScoped<ICallMeDal, CallMeDal>();
            builder.Services.AddScoped<IValidator<CallMe>, CallMeValidation>();

            builder.Services.AddScoped<ICallMeInterestedService, CallMeInterestedManager>();
            builder.Services.AddScoped<ICallMeInterestedDal, CallMeInterestedDal>();
            builder.Services.AddScoped<IValidator<CallMeInterested>, CallMeInterestedValidation>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, ContactDal>();
            builder.Services.AddScoped<IValidator<Contact>, ContactValidation>();

            builder.Services.AddScoped<IExpertiseService, ExpertiseManager>();
            builder.Services.AddScoped<IExpertiseDal, ExpertiseDal>();
            builder.Services.AddScoped<IValidator<Expertise>, ExpertiseValidation>();

            builder.Services.AddScoped<IFeedbackService, FeedbackManager>();
            builder.Services.AddScoped <IFeedbackDal, FeedbackDal>();
            builder.Services.AddScoped<IValidator<Feedback>, FeedbackValidation>();

            builder.Services.AddScoped<IIntroService, IntroManager>();
            builder.Services.AddScoped<IIntroDal, IntroDal>();
            builder.Services.AddScoped<IValidator<Intro>, IntroValidation>();

            builder.Services.AddScoped<IIntroCatService, IntroCatManager>();
            builder.Services.AddScoped<IIntroCatDal, IntroCatDal>();
            builder.Services.AddScoped<IValidator<IntroCat>, IntroCatValidation>();

            builder.Services.AddScoped<IPhotoService, PhotoManager>();
            builder.Services.AddScoped<IPhotoDal, PhotoDal>();
            builder.Services.AddScoped<IValidator<Photo>, PhotoValidation>();

            builder.Services.AddScoped<IPhotoCategoryService, PhotoCategoryManager>();
            builder.Services.AddScoped<IPhotoCategoryDal, PhotoCategoryDal>();
            builder.Services.AddScoped<IValidator<PhotoCategory>, PhotoCategoryValidation>();

            builder.Services.AddScoped<IPositionService, PositionManager>();
            builder.Services.AddScoped<IPositionDal, PositionDal>();
            builder.Services.AddScoped<IValidator<Position>, PositionValidation>();

            builder.Services.AddScoped<IQualityService, QualityManager>();
            builder.Services.AddScoped<IQualityDal, QualityDal>();
            builder.Services.AddScoped<IValidator<Quality>, QualityValidation>();

            builder.Services.AddScoped<IServicePackage, ServicePackageManager>();
            builder.Services.AddScoped<IServicePackageDal, ServicePackageDal>();
            builder.Services.AddScoped<IValidator<ServicePackage>, ServicePackageValidation>();

            builder.Services.AddScoped<IServicePackageDescription, ServicePackageDescriptionManager>();
            builder.Services.AddScoped<IServicePackageDescriptionDal, ServicePackageDescriptionDal>();
            builder.Services.AddScoped<IValidator<ServicePackageDescription>, ServicePackageDescriptionValidation>();

            builder.Services.AddScoped<ITeamService, TeamManager>();
            builder.Services.AddScoped<ITeamDal, TeamDal>();
            builder.Services.AddScoped<IValidator<Team>, TeamValidation>();

            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped < ITestimonialDal, TestimonialDal>();
            builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                            name: "areas",
                            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");

            });
            app.Run();
        }
    }
}
