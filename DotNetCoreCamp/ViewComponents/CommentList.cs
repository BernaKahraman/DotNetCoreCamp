using DotNetCoreCamp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreCamp.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Berna"

                },
                new UserComment
                {
                    ID=2,
                    Username="Eymen"
                },
                new UserComment
                {
                    ID=3,
                    Username="Ebrar"
                },
            };
            return View(commentvalues);
        }
    }
}
