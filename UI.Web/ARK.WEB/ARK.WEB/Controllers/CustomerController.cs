using ARK.CORE.ApiClient;
using ARK.SHARED.ApiModels.Kps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ARK.WEB.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Individual()
        {
            return View();
        }

        public IActionResult Corporate()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Create()
        {
            //URL: https://tckimlik.nvi.gov.tr/nufusaKayitYeriSeriNodanSorguModulTCKimlikNo/search
            //REQUEST: {"SeriNo":"A19F49933","Ad":"HALİL","Soyad":"KOCA","BabaAdi":"ŞERİF","AnneAdi":"PAKİZE","DogumYil":"1987","Cinsiyet":"1"}
            //RESPONSE: {"success":true,"obj":{"TcKimlikNo":52108492584,"Il":"Muğla","Ilce":"Fethiye","Ad":"HALİL","Soyad":"KOCA","MahalleKoy":"","BabaAdi":"ŞERİF","AnneAdi":"PAKİZE","DogumYil":1987,"Cinsiyet":"Erkek","CiltNo":78,"AileSiraNo":184,"BireySiraNo":351,"HataAciklama":null}}

            //ViewBag.IdentityTypeList = Helper.EnumExtension.SelectListFor<Identity>();
            //ViewBag.MembershipTypeList = Helper.EnumExtension.SelectListFor<MembershipType>();
            return View();
        }

        public async Task<JsonResult> PreCreateCustomer()
        {
            CallApi callapii = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
            var asd2 = await callapii.GetPreCustomerAsync();
            return Json(asd2);
        }

        [HttpPost]
        public JsonResult OldApiCall123()
        {
            var req = new NufusSorguRequest
            {
                Ad = "HALİL",
                AnneAdi = "PAKİZE",
                BabaAdi = "ŞERİF",
                Cinsiyet = "1",
                DogumYil = "1987",
                SeriNo = "A19F49933",
                Soyad = "KOCA"
            };
            var ads = OldApiCall.OldCallApiNoToken<NufusSorguRequest, NufusSorguResponse>("https://tckimlik.nvi.gov.tr/nufusaKayitYeriSeriNodanSorguModulTCKimlikNo/search", req);

            return Json(ads);
        }

        public JsonResult VerifyIdentity(KisiVeCuzdanDogrulaRequest req)
        {

            var asd = new CallApi("",new System.Net.Http.HttpClient());
            var response = asd.KisiVeCuzdanDogrulaAsync(req.TCKimlikNo, req.Ad, req.Soyad, req.SoyadYok, req.DogumGun, req.DogumGunYok, req.DogumAy, req.DogumAyYok, req.DogumYil, req.TCKKSeriNo);



            return Json(response);
        }

        public async Task<JsonResult> GetCustomers()
        {
            var asd = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
            var response = await asd.GetCustomersAsync();

            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> GetCustomerAccounts()
        {
            var asd = new CallApi("https://localhost:5001", new System.Net.Http.HttpClient());
            var response = await asd.GetCustomersAsync();

            return Json(response);
        }

        

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //kimlik bilgileri Bireysel ise B, Yetkili adına ise Y
                //ABONE_KIMLIK_AIDIYET

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}