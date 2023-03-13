using Amazon.S3;
using MainExwhyzee.Domain.Data;
using MainExwhyzee.Domain.Dtos.AwsDtos;
using MainExwhyzee.Domain.Services.AWS;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NirsalProject.Pages.Shared.ViewComponents
{
    public class HomeProfileViewComponent : ViewComponent
    {
        private readonly UserManager<MainExwhyzee.Domain.Models.Profile> _userManager;
         

        public HomeProfileViewComponent(
            UserManager<MainExwhyzee.Domain.Models.Profile> userManager
            )
        {
            _userManager = userManager;
           
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //string LoggedInUser = _userManager.GetUserId(HttpContext.User);
            //var user = await _userManager.FindByIdAsync(LoggedInUser);

            return View();
        }
    }
}
