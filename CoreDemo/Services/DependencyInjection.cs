using BLL.Abstract;
using BLL.Concrete;
using BLL.ValidationRules;
using DAL.Abstract;
using DAL.Context;
using DAL.EntityFramework;
using DAL.Repositories;
using Entities.Concrete;
using FluentValidation;

namespace CoreDemo.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            services.AddDbContext<MyContext>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDAL, EFAboutRepository>();

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDAL , EFBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDAL, EFCommentRepository>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDAL, EFContactRepository>();

            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<INewsLetterDAL, EFNewsLetterRepository>();

            services.AddScoped<IWriterService, WriterManager>();
            services.AddScoped<IWriterDAL, EFWriterRepository>();

            services.AddScoped(typeof(IGenericDAL<>), typeof(GenericRepository<>));

            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDAL, EFNotificationRepository>();

            services.AddScoped<IValidator<Writer>, WriterValidator>();
            services.AddValidatorsFromAssemblyContaining<WriterValidator>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDAL, EFMessageRepository>();

            //identity 
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<MyContext>();
        }
    }
}
