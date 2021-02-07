using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tam.webapp.Models;
using Tam.webapp.Services.PlayList;
using Tam.webapp.Services.Track;
using Tam.webapp.Utils;

namespace Tam.webapp.Controllers
{
    public class TrackController : Controller
    {
        private readonly IPlayListService _playList;
        private readonly ITrackService _service;

        public TrackController(ITrackService service, IPlayListService playList)
        {
            _service = service;
            _playList = playList;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var currentPlayList = HttpContext.Session.GetInt32("CurrentPlayListId");

            ViewBag.CurrentUser = HttpContext.Session.GetString("Name");
            ViewBag.CurrentUserId = HttpContext.Session.GetInt32("Id");

            ViewBag.CurrentPlayListName = (await _playList.GetPlayListByIdAsync(currentPlayList))?.Name;

            var tracksPlayList = new List<Track>();

            if (currentPlayList != null)
                tracksPlayList = await _service.GetTracksByPlaylistId((long) currentPlayList);

            return View(tracksPlayList);
        }


        public async Task<IActionResult> Details(long? id)
        {
            var song = await _service.GetTracksByIdAsync(id);
            return View(song);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Play(long? id)
        {
            var dummy = await _service.GetTracksByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Songs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Local")] Track track)
        {
            ViewBag.CurrentUser = HttpContext.Session.GetString("Name");
            ViewBag.CurrentUserId = HttpContext.Session.GetInt32("Id");

            var playlistId = HttpContext.Session.GetInt32("CurrentPlayListId");

            await FrameworkUtils.UploadFile(track.Local, track);

            if (playlistId != null) await _service.AddTrackByPlaylistIdAsync(track, (long) playlistId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }


        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var song = await _service.GetTracksByIdAsync(id);
            return View(song);
        }

        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Artist,Duration,AddedDate, LocalSource,Source")]
            Track track)
        {
            if (id != track.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateTrack(track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(track.Id))
                        return NotFound("Track Does not exist");
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(track);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound("Invalid song ");

            var song = await _service.GetTracksByIdAsync(id);
            if (song == null) return NotFound();

            return View(song);
        }


        // POST: Songs/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var track = await _service.GetTracksByIdAsync(id);

            await _service.RemoveTrack(track);

            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(long id)
        {
            return _service.GetTracksByIdAsync(id) != null;
        }
    }
}