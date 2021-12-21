using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class AdminController:Controller
    {
        private IProductRepository _repository;

        public AdminController(IProductRepository repository) => _repository = repository;

        public ViewResult Index() => View(_repository.Products);
    }
}