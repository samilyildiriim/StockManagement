using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.DAL;
using BLL.Services;
using BLL.Models;
using BLL.Services.Bases;

// Generated from Custom Template.

namespace MVC.Controllers
{
	public class ProductController : MvcController
	{
		// Service injections:
		private readonly IService<Product, ProductModel> _productService;
		private readonly ICategoryService _categoryService;

		/* Can be uncommented and used for many-to-many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
		//private readonly IManyToManyRecordService _ManyToManyRecordService;

		public ProductController(
			IService<Product, ProductModel> productService
			, ICategoryService categoryService

			/* Can be uncommented and used for many-to-many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
			//, IManyToManyRecordService ManyToManyRecordService
		)
		{
			_productService = productService;
			_categoryService = categoryService;

			/* Can be uncommented and used for many-to-many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
			//_ManyToManyRecordService = ManyToManyRecordService;
		}

		// GET: Product
		public IActionResult Index()
		{
			// Get collection service logic:
			var list = _productService.Query().ToList();
			return View(list);
		}

		// GET: Product/Details/5
		public IActionResult Details(int id)
		{
			// Get item service logic:
			var item = _productService.Query().SingleOrDefault(q => q.Record.Id == id);
			return View(item);
		}

		protected void SetViewData()
		{
			// Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
			ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Record.Id", "Name");

			/* Can be uncommented and used for many-to-many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
			//ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
		}

		// GET: Product/Create
		public IActionResult Create()
		{
			SetViewData();
			return View();
		}

		// POST: Product/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ProductModel product)
		{
			if (ModelState.IsValid)
			{
				// Insert item service logic:
				var result = _productService.Create(product.Record);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = product.Record.Id });
				}

				ModelState.AddModelError("", result.Message);
			}

			SetViewData();
			return View(product);
		}

		// GET: Product/Edit/5
		public IActionResult Edit(int id)
		{
			// Get item to edit service logic:
			var item = _productService.Query().SingleOrDefault(q => q.Record.Id == id);
			SetViewData();
			return View(item);
		}

		// POST: Product/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ProductModel product)
		{
			if (ModelState.IsValid)
			{
				// Update item service logic:
				var result = _productService.Update(product.Record);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = product.Record.Id });
				}

				ModelState.AddModelError("", result.Message);
			}

			SetViewData();
			return View(product);
		}

		// GET: Product/Delete/5
		public IActionResult Delete(int id)
		{
			// Get item to delete service logic:
			var item = _productService.Query().SingleOrDefault(q => q.Record.Id == id);
			return View(item);
		}

		// POST: Product/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// Delete item service logic:
			var result = _productService.Delete(id);
			TempData["Message"] = result.Message;
			return RedirectToAction(nameof(Index));
		}
	}
}