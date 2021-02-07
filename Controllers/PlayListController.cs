using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.webapp.Models;
using Tam.webapp.Services.PlayList;

namespace Tam.webapp.Controllers
{
    public class PlayListController : Controller
    {
        private readonly IPlayListService _service;

        public PlayListController(IPlayListService service)
        {
            _service = service;
        }


        // GET: Play_List
        public async Task<IActionResult> Index()
        {
            //Getting current User ID  
            var userid = HttpContext?.Session.GetInt32("Id")?? 1 ;

            ViewBag.CurrentUser = HttpContext?.Session.GetString("Name") ?? "empty";

            ViewBag.CurrentUserId = HttpContext?.Session.GetInt32("Id") ?? 1;

            var playLists = await _service.GetPlayListsByUserIdAsync(userid);

            playLists = playLists.OrderByDescending(s => s.CreatedDate).ToList();

            return View(playLists);
        }

        // GET: Play_List/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var playList = await _service.GetPlayListByIdAsync(id);
            return View(playList);
        }

        public IActionResult Play(long id)
        {
            HttpContext.Session.SetInt32("CurrentPlayListId", (int) id);
            return RedirectToAction("Index", "Track", id);
        }

        // GET: Play_List/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PlayList playList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                playList.CreatedDate = DateTime.Now;

                var userid = HttpContext?.Session.GetInt32("Id")?? 1;

                await _service.AddPlayListByUserId(userid, playList);

                return RedirectToAction(nameof(Index));
            }

            return View(playList);
        }

        // GET: Play_List/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var playList = await _service.GetPlayListByIdAsync(id) ?? new PlayList();
            return View(playList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Creation_Date")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdatePlayList(playList);
                return RedirectToAction(nameof(Index));
            }

            return View(playList);
        }

        // GET: Play_List/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var playList = await _service.GetPlayListByIdAsync(id);
            return View(playList);
        }

        // POST: Play_List/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var playList = await _service.GetPlayListByIdAsync(id);

            await _service.RemovePlaylistAsync(playList);

            return RedirectToAction(nameof(Index));
        }
    }
}