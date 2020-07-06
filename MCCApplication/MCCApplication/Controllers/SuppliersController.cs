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
    public class SuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suppliers
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Suppliers.ToListAsync());
            }catch(Exception e)
            {
                return Content("could not load supplier page ");
            }
        }

        // GET: Suppliers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = await db.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                return View(supplier);

            }catch(Exception e)
            {
                return Content("could not load detail supplier");
            }


        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }catch(Exception e)
            {
                return Content("could not load create supplier");
            }
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,JoinDate")] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Suppliers.Add(supplier);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(supplier);
            }
            catch(Exception e){
                return Content("Could not add supplier ");
            }
        }

        // GET: Suppliers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = await db.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                return View(supplier);

            }catch (Exception e){
                return Content("could not load edit supplier");
            }

            }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,JoinDate")] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(supplier).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(supplier);
            }catch(Exception e)
            {
                return Content("Could not edit supplier");
            }

            
        }

        // GET: Suppliers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Supplier supplier = await db.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return HttpNotFound();
                }
                return View(supplier);
            }catch(Exception e)
            {
                return Content("could not load delete supplier");
            }
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Supplier supplier = await db.Suppliers.FindAsync(id);
                db.Suppliers.Remove(supplier);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }catch(Exception e)
            {
                return Content("could not delete supplier");
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
