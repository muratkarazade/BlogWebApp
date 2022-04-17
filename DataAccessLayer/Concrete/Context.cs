using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context :DbContext
    {
        // Bağlantı stringlerimizi tanımlayacağımız method
        //Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-10TU074;Database=CoreBlogDb;Trusted_Connection=True;");
            


        }

        //Bu kısım yazılmadan önce katmanlar arası referans işlemlerinin yapılması gerekiyor!
        //Veritabanına yansıtmak istediğimiz Entityleri yazıldığı kısım.
        public DbSet<About> Abouts { get; set; }//About sınıfıdan Abouts propertisini kullanıyoruz.
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
