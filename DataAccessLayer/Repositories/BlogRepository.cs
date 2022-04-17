using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BlogRepository : IBlogDal
    {
        public void AddBlog(Blog blog)
        {
            using var c = new Context();
            c.Add(blog);
            c.SaveChanges();
        }

        public void DeleteBlog(Blog blog)
        {
            using var c = new Context();
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog GetById(int id)
        {
            using var c = new Context();
            return c.Blogs.Find(id);
        }

        public List<Blog> ListAllBlog()
        {
            using var c = new Context();
            return c.Blogs.ToList();
        }

        public void UpdateBlog(Blog blog)
        {
            using var c = new Context();
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
/*
 * Context c = new Context() ile using olarak tanımlanan metdodların arasındaki fark;
  "Context" tüm metodların dışına tek sefer yazılıp bütün metodlarda, kodun tamamında kullanılabiliyorken,
  "Using" sadece yazıldığı metoda ait oluyor ve her metod için tekrar tekrar yazılması gerekiyor. Kod satır 
  sayısı olarak düşündüğümüzde, "Context" kodu sadece 1 satır arttırırken, "Using" her metodda ayrı ayrı yazıldığı
  için kaç metod varsa kod o kadar satır artıyor. Bu da çok büyük kodlamalar için performans açısından negatif bir etki
  yaratır.
 
 */
