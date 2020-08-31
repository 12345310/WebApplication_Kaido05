using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_Kaido05.Models;

namespace WebApplication_Kaido05.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //context as db
        private MyContext db = new MyContext();

        //index
        public ActionResult Index()
        {
            var members = db.Members.ToList();
            return View(members);
        }

        // details
        public ActionResult Details(int? id)
        {
            Member member = db.Members.Find(id);
            return View(member);
        }

        //create
        public ActionResult Create()
        {
            //単に入力ページを表示
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            //POSTされた時
            //値を受けっとってdbに保存します
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                //登録に成功したら一覧を表示
                return RedirectToAction("Index");
            }

            //バリデーションに問題があったら元のページに返す
            return View(member);
        }

        // edit
        public ActionResult Edit(int? id)
        {
            //指定したidの値を取得
            Member member = db.Members.Find(id);
            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Member member)
        {
            if (ModelState.IsValid)
            {
                //更新であることを明示
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // delete
        public ActionResult Delete(int? id)
        {
            //削除対象を検索
            Member member = db.Members.Find(id);
            return View(member);
        }

        //同じ名前、同じ引数が定義できない（実際は?がついているからできるけど）
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //削除対象を取得・削除・保存
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}