using MusicWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace MusicWeb.Controllers
{
    public class AdminController : Controller
    {
        public CommonConnection cnn = new CommonConnection();
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                if (Session["RoleUser"].ToString() == "admin")
                {
                    Session["screen"] = "srcUser";
                    var listUser = cnn.GetUsers().ToList();
                    return View(listUser);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }

        }
        [HttpGet]
        public ActionResult CreateAdminUser()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var result = new AdminUserModel();
            return View(result);
        }
        [HttpPost]
        public ActionResult CreateAdminUser(AdminUserModel person)
        {
            cnn.AddAdminUser(person);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public ActionResult EditAdminUser(int id)
        {
            var getUser = cnn.GetUsersById(id);
            return View(getUser);
        }
        [HttpPost]
        public ActionResult EditAdminUser(AdminUserModel person)
        {
            cnn.EditAdminUser(person);
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public ActionResult DeleteAdminUser(int id)
        {
            var getUser = cnn.GetUsersById(id);
            return View(getUser);
        }
        [HttpPost]
        public ActionResult DeleteAdminUser(AdminUserModel person)
        {
            cnn.DeleteAdminUser(person);
            return RedirectToAction("Index", "Admin");
        }
        /*End admin user*/
        [HttpGet]
        public ActionResult Song()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Session["screen"] = "srcSong";
            var ListSong = cnn.GetSongs().ToList();
            return View(ListSong);
        }
        [HttpGet]
        public ActionResult AddSong()
        {
            var result = new SongViewModel();
            result.song = new Song();

            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var categoryDropdownList = cnn.GetCatergoryDropdownList();
            result.CategoryDropdownList = categoryDropdownList;
            var singerList = cnn.GetSingerList();
            result.SingerDropList = singerList;
            return View(result);
        }
        [HttpPost]
        public ActionResult AddSong(SongViewModel songView)
        {

            try
            {
                if (songView.song.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(songView.song.ImageUpload.FileName);
                    string extension = Path.GetExtension(songView.song.ImageUpload.FileName);
                    fileName = fileName + extension;
                    songView.song.ImageSong = "/Content/images/" + fileName;
                    songView.song.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
                if (songView.song.AudioUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(songView.song.AudioUpload.FileName);
                    string extension = Path.GetExtension(songView.song.AudioUpload.FileName);
                    fileName = fileName + extension;
                    songView.song.Audio_Song = "/Content/music/" + fileName;
                    songView.song.AudioUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/music"), fileName));
                }
                songView.song.View_Song = 0;
                songView.song.ID_Catergory = int.Parse(songView.selectedCategory);
                songView.song.ID_Singer = int.Parse(songView.selectedSinger);
                cnn.AddSong(songView);
                return RedirectToAction("Song", "Admin");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditSong(int id)
        {

            var result = new SongViewModel();
            result.song = new Song();

            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            result = cnn.GetSongById(id);
            var categoryDropdownList = cnn.GetCatergoryDropdownList();
            result.CategoryDropdownList = categoryDropdownList;
            var singerList = cnn.GetSingerList();
            result.SingerDropList = singerList;
            return View(result);
        }
        [HttpPost]
        public ActionResult EditSong(SongViewModel songView)
        {
            try
            {
                if (songView.song.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(songView.song.ImageUpload.FileName);
                    string extension = Path.GetExtension(songView.song.ImageUpload.FileName);
                    fileName = fileName + extension;
                    songView.song.ImageSong = "/Content/images/" + fileName;
                    songView.song.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
                if (songView.song.AudioUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(songView.song.AudioUpload.FileName);
                    string extension = Path.GetExtension(songView.song.AudioUpload.FileName);
                    fileName = fileName + extension;
                    songView.song.Audio_Song = "/Content/music/" + fileName;
                    songView.song.AudioUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/music"), fileName));
                }
                songView.song.View_Song = 0;
                songView.song.ID_Catergory = int.Parse(songView.selectedCategory);
                songView.song.ID_Singer = int.Parse(songView.selectedSinger);
                cnn.EditSong(songView);
                return RedirectToAction("Song", "Admin");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteSong(int id)
        {
            var getSong = cnn.GetSongById(id);
            return View(getSong);
        }
        [HttpPost]
        public ActionResult DeleteSong(SongViewModel songs)
        {
            try
            {
                cnn.DeleteSong(songs.song.ID_Song);
                return RedirectToAction("Song", "Admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Singer()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Session["screen"] = "srcSinger";
            var ListSong = cnn.GetSinger().ToList();
            return View(ListSong);
        }
        [HttpGet]
        public ActionResult AddSinger()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Singer singer = new Singer();
            return View(singer);
        }
        [HttpPost]
        public ActionResult AddSinger(Singer singer)
        {
            try
            {
                if (Session["ID"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                if (singer.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(singer.ImageUpload.FileName);
                    string extension = Path.GetExtension(singer.ImageUpload.FileName);
                    fileName = fileName + extension;
                    singer.ImageSinger = "/Content/images/" + fileName;
                    singer.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
                singer.View_moth = 0;
                cnn.AddSinger(singer);
                return RedirectToAction("Singer", "Admin");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
            
        }
        [HttpGet]
        public ActionResult EditSinger(int id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var singer = cnn.GetSingerById(id);
            return View(singer);
        }
        [HttpPost]
        public ActionResult EditSinger(Singer singer)
        {
            try
            {
                if (singer.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(singer.ImageUpload.FileName);
                    string extension = Path.GetExtension(singer.ImageUpload.FileName);
                    fileName = fileName + extension;
                    singer.ImageSinger = "/Content/images/" + fileName;
                    singer.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
                singer.View_moth = 0;
                cnn.EditSinger(singer);
                return RedirectToAction("Singer", "Admin");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteSinger(int id)
        {
            var getSinger = cnn.GetSingerById(id);
            return View(getSinger);
        }
        [HttpPost]
        public ActionResult DeleteSinger(Singer singer)
        {
            try
            {
                cnn.DeleteSinger(singer.ID_Singer);
                return RedirectToAction("Singer", "Admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
        [HttpPost]
        public ActionResult seachAdmin(string _seacrchName)
        {
            if (Session["screen"].ToString() == "srcUser")
            {
                var seachAdminUser = cnn.SeachAccount(_seacrchName);
                return View("Index",seachAdminUser.ToList());
            }
            if (Session["screen"].ToString() == "srcSong")
            {
                var seachsong = cnn.GetSongsSearch(_seacrchName);
                return View("Song",seachsong.ToList());
            }
            if (Session["screen"].ToString() == "srcSinger")
            {
                var seachsinger= cnn.SeachSinger(_seacrchName);
                return View("Singer",seachsinger.ToList());
            }
            if (Session["screen"].ToString() == "srcLibrary")
            {
                var seachsinger= cnn.SeachLibrary(_seacrchName);
                return View("Library",seachsinger.ToList());
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Library()
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Session["screen"] = "srcLibrary";
            var ListSong = cnn.GetLibraryAdmin().ToList();
            return View(ListSong);
        }
        [HttpGet]
        public ActionResult LibraryDelete(int id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var ListSong = cnn.GetLibraryAdminByID(id);
            return View(ListSong);
        }
        [HttpPost]
        public ActionResult LibraryDelete(LibraryModel lb)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            cnn.DeleteLibrary(lb.ID_Library);
            return RedirectToAction("Library");
        }

    }
}