using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothingPro.Controllers
{
    //[Authorize(Roles ="Admin,Hardware")]
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //[Authorize(Roles = "Admin,Hardware")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View("Index", roles);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //Check duplicate roles(Existing roles)

            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }



    }
}
