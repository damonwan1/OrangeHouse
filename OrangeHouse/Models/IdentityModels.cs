using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrangeHouse.Models
{
    // 可以通过将更多属性添加到 ApplicationUser 类来为用户添加配置文件数据，请访问 https://go.microsoft.com/fwlink/?LinkID=317594 了解详细信息。
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public string RoleType { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : base()
        {
            //Permissions = new List<ApplicationRolePermission>();
        }
        public ApplicationRole(string roleName)
            : this()
        {
            base.Name = roleName;
        }

        [Display(Name = "角色描述")]
        public string Description { get; set; }
        /// <summary>
        /// 权限列表
        /// </summary>
       // public ICollection<ApplicationRolePermission> Permissions { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            // 在第一次启动网站时初始化数据库添加管理员用户凭据和admin 角色到数据库
            // Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}