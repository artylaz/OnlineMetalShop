using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Baskets.Queries.GetBasketCount;
using OnlineStore.Application.Categories.Commands.UpdateCategory;
using OnlineStore.Application.Categories.Queries.GetCategoryHeaderList;
using OnlineStore.Application.Categories.Queries.GetCategoryList;
using OnlineStore.Application.Categories.Queries.GetChildCategories;
using OnlineStore.Application.Categories.Queries.GetParentCategories;
using OnlineStore.Application.Characteristics.Commands.DeleteCharacteristic;
using OnlineStore.Application.Characteristics.Commands.UpdateCharacteristic;
using OnlineStore.Application.Characteristics.Queries;
using OnlineStore.Application.Pictures.Commands.Create;
using OnlineStore.Application.Pictures.Commands.Delete;
using OnlineStore.Application.Pictures.Queries.GetPictures;
using OnlineStore.Application.Products.Commands.UpdateProduct;
using OnlineStore.Application.Products.Queries.GetProductList;
using OnlineStore.Application.Users.Commands.UpdateUser;
using OnlineStore.Application.Users.Queries.GetUser;
using OnlineStore.WebMVC.Models.SiteManagerViewModels;
using OnlineStore.WebMVC.Models.StaticModels;

namespace OnlineStore.WebMVC.Controllers
{
    [Authorize(Roles = "SiteManager")]
    public class SiteManagerController : BaseController
    {
        public IWebHostEnvironment appEnvironment;
        public SiteManagerController(IWebHostEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment;
        }

        #region SiteManagerAccount
        public async Task<IActionResult> SiteManagerAccount()
        {
            var user = await Mediator.Send(new GetUserQuery { Id = UserId });
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditAccount(UserVm model)
        {
            ViewData["AmountBasket"] = await Mediator.Send(new GetBasketCountQuery { UserId = UserId });

            if (ModelState.IsValid)
            {
                UpdateUserCommand command = new()
                {
                    Id = model.Id,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    IsAccess = true,
                    LastName = model.LastName,
                    Password = model.Password,
                    Phone = model.Phone
                };
                await Mediator.Send(command);
            }
            else
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            return RedirectToAction("SiteManagerAccount");
        }
        #endregion

        #region Product


        [HttpGet]
        public async Task<IActionResult> EditProduct()
        {
            var vm = new EditProductVm
            {
                ProductCategories = await Mediator.Send(new GetChildCategoriesQuery()),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Guid CategoryId)
        {
            var vm = new EditProductVm
            {
                Products = await Mediator.Send(new GetProductListQuery { CategoryId = CategoryId }),
                ProductCategories = await Mediator.Send(new GetChildCategoriesQuery()),
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await Mediator.Send(updateProductCommand);
            return RedirectToAction("EditProduct");
        }
        #endregion

        #region Category

        [HttpGet]
        public async Task<IActionResult> EditCategory()
        {
            var categoryVm = await Mediator.Send(new GetCategoryListQuery());
            var editCategoryVm = new EditCategoryVm
            {
                ParentCategories = await Mediator.Send(new GetParentCategoriesQuery()),
                Categories = categoryVm.Categories
            };

            return View(editCategoryVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(UpdateCategoryCommand command)
        {
            await Mediator.Send(command);
            IndexMenuVM.Categorys = await Mediator.Send(new GetCategoryHeaderListQuery());

            return RedirectToAction("EditCategory");
        }
        #endregion

        #region Characteristic

        [HttpGet]
        public async Task<IActionResult> EditCharacteristic()
        {
            var editCharacteristicVm = new EditCharacteristicVm
            {
                Characteristics = await Mediator.Send(new GetCharacteristicListQuery()),
            };

            return View(editCharacteristicVm);
        }

        [HttpPost]
        public async Task<IActionResult> EditCharacteristic(UpdateCharacteristicCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction("EditCharacteristic");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCharacteristic(DeleteCharacteristicCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction("EditCharacteristic");
        }
        #endregion

        #region Picture

        [HttpGet]
        public async Task<IActionResult> EditPicture()
        {
            var editPictureVM = new EditPictureVm
            {
                Pictures = await Mediator.Send(new GetPicturesQuery())
            };
            return View(editPictureVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditPicture(IFormFile uploadedFile, string productName)
        {
            var pictureId = Guid.NewGuid();
            var fileName = uploadedFile.FileName;
            string pathImg = $"/images/products/{pictureId}.{fileName.Split(new char[] { '.' })[1]}";
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + pathImg, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            CreatePictureCommand command = new()
            {
                Id = pictureId,
                Name = pictureId.ToString(),
                Path = pathImg,
                ProductName = productName
            };

            await Mediator.Send(command);
            return RedirectToAction("EditPicture");
        }
        [HttpGet]
        public async Task<IActionResult> RemovePicture(DeletePictureCommand command)
        {
            await Mediator.Send(command);
            return RedirectToAction("EditPicture");
        }
        #endregion
    }
}
