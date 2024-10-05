using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MusicWeb.Models;
using Newtonsoft.Json;

namespace MusicWeb.Controllers
{
    public class HomeController : Controller
    {
        CommonConnection cnn = new CommonConnection();
        [HttpGet]
        public ActionResult Index()
        {
            var listSong = cnn.GetSongs().ToList();
            if (Session["ID"] != null)
            {
                for(int i=0;i < listSong.Count;i++)
                {
                    var checkLiked = cnn.CheckSongInLibrary(int.Parse(Session["ID"].ToString()), listSong[i].ID_Song);
                    if (checkLiked != null)
                        listSong[i].IsLiked = true;
                }
            }
            
            return View(listSong);
        }
        public ActionResult Library()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var listSong = cnn.GetLibrary().ToList();
            return View(listSong);
        }

        public ActionResult Discover(string _seacrchName)
        {
            if (_seacrchName == null)
            {
                var listSong = cnn.GetSongsTop100().ToList();
                if (Session["ID"] != null)
                {
                    for (int i = 0; i < listSong.Count; i++)
                    {
                        var checkLiked = cnn.CheckSongInLibrary(int.Parse(Session["ID"].ToString()), listSong[i].ID_Song);
                        if (checkLiked != null)
                            listSong[i].IsLiked = true;
                    }
                }
                return View(listSong);
            }
            else
            {
                var listSongSearch = cnn.GetSongsSearch(_seacrchName).ToList();
                if (Session["ID"] != null)
                {
                    for (int i = 0; i < listSongSearch.Count; i++)
                    {
                        var checkLiked = cnn.CheckSongInLibrary(int.Parse(Session["ID"].ToString()), listSongSearch[i].ID_Song);
                        if (checkLiked != null)
                            listSongSearch[i].IsLiked = true;
                    }
                }
                return View(listSongSearch);
            }

        }
        [HttpPost]
        public ActionResult DetailSinger(int id)
        {
            var singer = cnn.GetSingerById(id);
            return View(singer);
        }
        [HttpPost]
        public ActionResult UpdateView(int ID_Song)
        {
            cnn.UpdateViewSong(ID_Song);
            return Json(new { success = true, message = "cap nhat thanh cong" });
        }
        [HttpPost]
        public ActionResult AddSongInLibrary(int ID_Song, int ID_AdminUser)
        {
            var checkSongExist = cnn.checkSongExist(ID_Song,ID_AdminUser);
            if (checkSongExist.Count == 0)
            {
                cnn.AddLibrary(ID_Song, ID_AdminUser);
                return Json(new { success = true, message = "cap nhat thanh cong" });
            }
            else
            {
                cnn.deleteSongInLibrary(checkSongExist[0].ID_Library);
                return Json(new { success = true, message = "cap nhat thanh cong" });
            }
            
        }

        [HttpGet]
        public ActionResult GetSongList()
        {
            try
            {
                var songList = cnn.GetLibrary().ToList();
                return Json(new { data = JsonConvert.SerializeObject(songList), message = "Success"}, JsonRequestBehavior.AllowGet);
            }catch (Exception ex) 
            {
                return Json(new { data = 0, message = ex}, JsonRequestBehavior.AllowGet) ;

            }
        }
    }
}