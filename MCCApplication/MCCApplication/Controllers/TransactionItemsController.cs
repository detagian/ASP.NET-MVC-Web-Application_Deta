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
    public class TransactionItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransactionItems
        public async Task<ActionResult> Index()
        {
            try
            {
                var transactionItems = db.TransactionItems.Include(t => t.Item);
                return View(await transactionItems.ToListAsync());
            }catch(Exception e)
            {
                return Content("could not load transactionitem page");
            }
        }

        // GET: TransactionItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionItem transactionItem = await db.TransactionItems.FindAsync(id);
                if (transactionItem == null)
                {
                    return HttpNotFound();
                }
                return View(transactionItem);

            }catch(Exception e)
            {
                return Content("could not load details transactionitem");
            }
        }

        // GET: TransactionItems/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdItem = new SelectList(db.Items, "IdItem", "ItemName");
                return View();
            }catch(Exception e)
            {
                return Content("could not load create transactionitem");
            }
        }

        // POST: TransactionItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTI,Quantity,IdItem")] TransactionItem transactionItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TransactionItems.Add(transactionItem);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.IdItem = new SelectList(db.Items, "IdItem", "ItemName", transactionItem.IdItem);
                return View(transactionItem);
            }catch(Exception e)
            {
                return Content("could not create transactionitem");
            }
        }

        // GET: TransactionItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionItem transactionItem = await db.TransactionItems.FindAsync(id);
                if (transactionItem == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdItem = new SelectList(db.Items, "IdItem", "ItemName", transactionItem.IdItem);
                return View(transactionItem);
            }catch(Exception e)
            {
                return Content("could not load edit transactionitem");
            }
        }

        // POST: TransactionItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTI,Quantity,IdItem")] TransactionItem transactionItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transactionItem).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.IdItem = new SelectList(db.Items, "IdItem", "ItemName", transactionItem.IdItem);
                return View(transactionItem);
            }catch(Exception e)
            {
                return Content("could not edit transactionitem");
            }
        }

        // GET: TransactionItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionItem transactionItem = await db.TransactionItems.FindAsync(id);
                if (transactionItem == null)
                {
                    return HttpNotFound();
                }
                return View(transactionItem);
            }catch(Exception e)
            {
                return Content("could not load delete transactionitem");
            }
        }

        // POST: TransactionItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                TransactionItem transactionItem = await db.TransactionItems.FindAsync(id);
                db.TransactionItems.Remove(transactionItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                return Content("could not delete transactionitem");
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
