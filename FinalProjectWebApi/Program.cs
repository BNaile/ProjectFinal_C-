
using Business.Abstract;
using Business.Concrete;
using Business.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.Membership;
using Microsoft.IdentityModel.Tokens;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace FinalProjectWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var Configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            //ad;n düzeldersen
            #region Mid

          
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
            builder.Services.AddScoped<IFeedbackDal, FeedbackDal>();
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
            builder.Services.AddScoped<ITestimonialDal, TestimonialDal>();
            builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidation>();

            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
