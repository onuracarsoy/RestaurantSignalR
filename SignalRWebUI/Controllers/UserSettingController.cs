using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Models.IdentityDtos;
using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Controllers
{
    public class UserSettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserSettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserUpdate()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.FirstName = values.FirstName;
            userEditDto.LastName = values.LastName;
            userEditDto.UserName = values.UserName;

            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserEditDto userEditDto)
        {

            // Şifre doğruluğunu kontrol et
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var checkPassword = await _userManager.CheckPasswordAsync(user, userEditDto.Password);

            if (!checkPassword)
            {
                ViewBag.checkPassword = "Şifre Yanlış!";
                return View();
            }

            // Şifre doğrulandı, diğer bilgileri güncelle
            user.FirstName = userEditDto.FirstName;
            user.LastName = userEditDto.LastName;
            user.UserName = userEditDto.UserName;


            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("UserUpdate","UserSetting");
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserEditPasswordDto userEditPasswordDto)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var isOldPasswordCorrect = await _userManager.CheckPasswordAsync(user, userEditPasswordDto.OldPassword);

            if (!isOldPasswordCorrect)
            {
                ViewBag.isOldPasswordCorrect = "Mecvut Şifre Yanlış!";
                return View();
            }

            // Identity'de şifre güncelleme işlemi
            var result = await _userManager.ChangePasswordAsync(user, userEditPasswordDto.OldPassword, userEditPasswordDto.Password);

            if (result.Succeeded)
            {
                // Şifre güncelleme başarılı ise istediğiniz bir sayfaya yönlendirme
                return RedirectToAction("Index", "Login");
            }
            return View();

        }



    }

}



