using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

       //  EfCategoryRepository efCategoryRepository;
        ICategoryDal  _categoryDal;

       


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
           _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
           return _categoryDal.GetListAll();
        }
    }
}

/*
 
 EfCategoryRepository'i kullanmamızdaki dezavantaj Entity Framework'e bağımlı olmamız. İlerde başka bir teknoloji 
 geldiğinde projeyi ona geçirmek için neredeyse bütün katmanlardaki kodları tek tek değiştirmemiz gerekir ama
 interface kullanarak bu bağımlılığı yok eder ve istersek ileride daha farklı teknolojilere geçebiliriz. Avantaj
 olaraksa kısa vadede daha az kod yazıp daha kısa sürede projeyi bitirebiliriz. 

 */
