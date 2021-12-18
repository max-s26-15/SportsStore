using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IProductRepository _repository;

        public NavigationMenuViewComponent(IProductRepository repository) => 
            _repository = repository;

        public IViewComponentResult Invoke() => View(_repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x)
        );
    }
}