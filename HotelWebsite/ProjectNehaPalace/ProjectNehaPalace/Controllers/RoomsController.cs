using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectNehaPalace.Models;
using ProjectNehaPalace.Models.HotelModels;

namespace ProjectNehaPalace.Controllers
{
    public class RoomsController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:51947/api/rooms";
        RoomClient roomClient = new RoomClient("http://localhost:50254");
        public async Task<ActionResult> Index()
        {
            List<Room> RoomsList = new List<Room>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/rooms/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var RoomsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    RoomsList = JsonConvert.DeserializeObject<List<Room>>(RoomsResponse);

                }
                //returning the employee list to view  
                return View(RoomsList);
            }
        }


    }
}