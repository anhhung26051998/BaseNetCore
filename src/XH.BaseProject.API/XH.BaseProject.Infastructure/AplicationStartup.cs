using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Infastructure.Database;

namespace XH.BaseProject.Infastructure
{
    public static class AplicationStartup
    {

        public static void Initialize(IConfiguration configuration,
            IServiceCollection services,
            string connectionString)
        {
            ConfigureIdentity(services, connectionString, configuration);
        }

        private static void ConfigureIdentity(this IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            services.AddDbContext<BaseContext>(options => {
                options.UseSqlServer(connectionString,x=>x.MigrationsAssembly("XH.BaseProject.Infastructure"));
            });
            // Đăng ký các dịch vụ của Identity
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<BaseContext>();

            // Truy cập IdentityOptions
            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = true; // Không bắt phải có số
                options.Password.RequireLowercase = true; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = true; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = true; // Không bắt buộc chữ in
                options.Password.RequiredLength = 5; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 0; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.RequireUniqueEmail = true; // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = false; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

            });

        }
    }
}
