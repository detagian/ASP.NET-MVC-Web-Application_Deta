using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCCApplication.Models;

namespace MCCApplication.Controllers
{
    public class ItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Items
        public async Task<ActionResult> Index()
        {
            try
            {

                var items = db.Items.Include(i => i.Supplier);
                return View(await items.ToListAsync());
            }catch(Exception e)
            {
                return Content("could not load item page");
            }
        }

        // GET: Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = await db.Items.FindAsync(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);

            }catch(Exception e)
            {
                return Content("could not load details item");
            }
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            try
            {

                ViewBag.Id = new SelectList(db.Suppliers, "Id", "Name");
                return View();

            }catch(Exception e)
            {
                return Content("could not load create item");
            }
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdItem,ItemName,Price,Stock,Id")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Items.Add(item);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.Id = new SelectList(db.Suppliers, "Id", "Name", item.Id);
                return View(item);
            }catch(Exception e)
            {
                return Content("could not create/add item");
            }
        }

        // GET: Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = await db.Items.FindAsync(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Id = new SelectList(db.Suppliers, "Id", "Name", item.Id);
                return View(item);
            }catch(Exception e)
            {
                return Content("could not load edit item");
            }
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdItem,ItemName,Price,Stock,Id")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(item).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.Id = new SelectList(db.Suppliers, "Id", "Name", item.Id);
                return View(item);
            }catch (Exception e)
            {
                return Content("could not edit item");
            }
        }

        // GET: Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = await db.Items.FindAsync(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }catch (Exception e)
            {
                return Content("could not load delete item");
            }
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Item item = await db.Items.FindAsync(id);
                db.Items.Remove(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                return Content("could not delete item");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
