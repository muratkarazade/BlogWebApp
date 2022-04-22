using BlogWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogWebApp.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID= 1,
                    Username="Murat"
                },
                new UserComment
                {
                    ID = 2,
                    Username="Sadık "
                },
                new UserComment {
                    ID = 3,
                    Username="Atıl"
                }
            };
            return View(commentvalues);
        }
    }
}
