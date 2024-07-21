using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.RepositoryUnitOfWork;

namespace BioLabTask.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        public UserController(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            _repositoryUnitOfWork = repositoryUnitOfWork;
        }

        [HttpGet]
        public IActionResult Search()
        {
            var users = _repositoryUnitOfWork.userRepository.Value.GetAllUsers();
            return View(users);
        }
        [HttpPost]
        public IActionResult Search(User model)
        {
            try
            {

                if (!string.IsNullOrEmpty(model.Email))
                {
                    model.Email = model.Email.Trim();
                    var users = _repositoryUnitOfWork.userRepository.Value.GetUserByEmail(model.Email);
                    return View(users);
                }
                else
                {
                    var users = _repositoryUnitOfWork.userRepository.Value.GetAllUsers();
                    return View(users);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View(new User());
        }
        [HttpPost]
        public IActionResult AddUser(User model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Name))
                {
                    var users = _repositoryUnitOfWork.userRepository.Value.GetUserByEmail(model.Email);
                    if (users.Count() > 0)
                    {
                    ModelState.AddModelError(string.Empty, "User already exists.");
                    return View(model);
                    }
              
                    else
                    {
                    _repositoryUnitOfWork.userRepository.Value.AddNewUser(model);
                    }

                }
                return RedirectToAction("Search");
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

        }
        [HttpPost]
        public IActionResult RemoveUser(long Id) 
        {
            try
            {
                _repositoryUnitOfWork.userRepository.Value.RemoveUser(Id);
                var users = _repositoryUnitOfWork.userRepository.Value.GetAllUsers();
                return RedirectToAction("Search");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var users = _repositoryUnitOfWork.userRepository.Value.GetAllUsers();

                return RedirectToAction("Search", users);
            }
        }
    }
}
