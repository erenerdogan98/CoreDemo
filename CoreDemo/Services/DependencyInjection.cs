using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Context;
using DAL.EntityFramework;

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
        }
    }
}
