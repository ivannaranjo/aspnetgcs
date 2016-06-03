using Google.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lazy<Task<StorageClient>> _storageClient = new Lazy<Task<StorageClient>>(() => StorageClient.CreateAsync());
       
        public async Task<ActionResult> Index()
        {
            var client = await _storageClient.Value;
            var buckets = await client.ListAllBucketsAsync("my-demo-1331");

            return View(buckets);
        }

        public async Task<ActionResult> Bucket(string name)
        {
            var client = await _storageClient.Value;
            var files = await client.ListAllObjectsAsync(name, null);

            return View(files);
        }

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
    }
}