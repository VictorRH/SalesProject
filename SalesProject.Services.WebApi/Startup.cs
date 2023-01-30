using Microsoft.EntityFrameworkCore;
using SalesProject.Application.Interface;
using SalesProject.Application.Main;
using SalesProject.Domain.Core;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using SalesProject.Infraestructure.Repository;
using SalesProject.Transversal.Mapper;

namespace SalesProject.Services.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<FerreteriaDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("FerreteriaDB"));
            });

            //services.AddSingleton<>();
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
            services.AddTransient<IGenericRepository<Customer>, CustomerRepository>();
            services.AddTransient<ICustomerDomain, CustomerDomain>();
            services.AddTransient<ICustomerApplication, CustomerApplication>();

            services.AddTransient<IGenericRepository<CustomerCat>, CustomerCatRepository>();
            services.AddTransient<ICustomerCatDomain, CustomerCatDomain>();
            services.AddTransient<ICustomerCatApplication, CustomerCatApplication>();

            services.AddTransient<IGenericRepository<Supplier>, SupplierRepository>();
            services.AddTransient<ISupplierDomain, SupplierDomain>();
            services.AddTransient<ISupplierApplication, SupplierApplication>();

            services.AddTransient<IGenericRepository<SupplierCat>, SupplierCatRepository>();
            services.AddTransient<ISupplierCatDomain, SupplierCatDomain>();
            services.AddTransient<ISupplierCatApplication, SupplierCatApplication>();

            services.AddTransient<IGenericRepository<Cellar>, CellarRepository>();
            services.AddTransient<ICellarDomain, CellarDomain>();
            services.AddTransient<ICellarApplication, CellarApplication>();

            services.AddTransient<IGenericRepository<Product>, ProductRepository>();
            services.AddTransient<IProductDomain, ProductDomain>();
            services.AddTransient<IProductApplication, ProductApplication>();

            services.AddTransient<IGenericRepository<Brand>, ProductBrandRepository>();
            services.AddTransient<IProductBrandDomain, ProductBrandDomain>();
            services.AddTransient<IProductBrandApplication, ProductBrandApplication>();

            //Genric repository
            services.AddScoped(typeof(IGenericRepositories<>), (typeof(GenericRepository<>)));

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
