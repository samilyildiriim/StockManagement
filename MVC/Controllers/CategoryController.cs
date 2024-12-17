using BLL.Controllers.Bases;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class CategoryController : MvcController
    {
        // Service injections:
        private readonly ICategoryService _categoryService;

        /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
        //private readonly IManyToManyRecordService _ManyToManyRecordService;

        public CategoryController(
            ICategoryService categoryService

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
            //, IManyToManyRecordService ManyToManyRecordService
        )
        {
            _categoryService = categoryService;

            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
            //_ManyToManyRecordService = ManyToManyRecordService;
        }

        // GET: Category
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _categoryService.Query().ToList();
            return View(list);
        }

        // GET: Category/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _categoryService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. ManyToManyRecord may be replaced with the related entity name in the controller and views. */
            //ViewBag.ManyToManyRecordIds = new MultiSelectList(_ManyToManyRecordService.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Category/Create
        //[HttpGet] // default
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _categoryService.Create(category.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    // Way 1:
                    //return RedirectToAction("Details", new { id = category.Record.Id });
                    // Way 2:
                    return RedirectToAction(nameof(Details), new { id = category.Record.Id });
                }
                ModelState.AddModelError("", result.Message); // shown in the validation summary of the view
            }
            SetViewData();
            return View(category);
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _categoryService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Category/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _categoryService.Update(category.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = category.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(category);
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _categoryService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Category/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _categoryService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
