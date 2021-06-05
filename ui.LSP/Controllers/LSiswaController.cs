using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ui.BAWANG.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Security;

namespace ui.BAWANG.Controllers
{
    public class LSiswaController : Controller
    {

        public HttpResponseMessage GetAll()
        {
            string query = @"
                SELECT ID,[Username]
                    ,[Password]
                    ,[NIS]
                FROM [dbo].[Tb_LSiswa]";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public HttpResponseMessage GetByID(string id)
        {
            string query = @"
        SELECT ID,[Username]
            ,[Password]
            ,[NIS]
            ,[created]
            ,[creator]
            ,[edited]
            ,[editor]
        FROM [dbo].[Tb_LSiswa] where ID = '" + id + "'";

            DataTable table = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Tb_LSiswa tbsiswa)
        {
            try
            {
                string query = @"
                    INSERT INTO [dbo].[Tb_LSiswa]
                          ([Username]
                          ,[Password]
                          ,[NIS]
                          ,[creator])
                    VALUES"
                + "('" + tbsiswa.Username + "','" + tbsiswa.Password + "','" + tbsiswa.NIS + "','" + tbsiswa.creator + "') ";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "Insert Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        public string Put(Tb_LSiswa tbsiswa)
        {
            try
            {
                string query = @"UPDATE [dbo].[Tb_LSiswa] SET "
              + "      [Password] = '" + tbsiswa.Password + "'"
              + "      ,[NIS] = '" + tbsiswa.NIS + "'"
             + "       ,[edited] = getdate()"
              + "      ,[editor] = '" + tbsiswa.editor + "'"
              + "  WHERE [Username] = '" + tbsiswa.Username + "'";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "Update Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        public string Delete(string id, string userLogin)
        {
            try
            {
                //string query = @"UPDATE FROM [bawangDB].[dbo][Tb_LSiswa] SET "
                //    + "            ,isDelete = '" + 0 + "' "
                //    + "           ,edited = '" + DateTime.Now.ToString() + "' "
                //    + "            ,editor = '" + userLogin + "' "
                //    + "             WHERE [Username]= '" + username +"'";

                var EmpResponse = GetByID(id);
                var rslt = JsonConvert.DeserializeObject<List<Tb_LSiswa>>(EmpResponse.Content.ReadAsStringAsync().Result);

                string query = string.Empty;
                string descriptionData = rslt[0].Username + "|" + rslt[0].NIS + "";

                query = "insert into [dbo].[Tb_Log] (menu,[descriptionData],[creator]) values ('Siswa','" + descriptionData + "','" + userLogin + "')";
                query += ";delete from [dbo].[Tb_LSiswa] WHERE [ID] = '" + id + "'";

                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "Update Successfully";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        [Route("api/LSiswa/totaldata")]
        public HttpResponseMessage TotalData()
        {
            try
            {
                string csql = @"SELECT count(*) as total FROM [bawangDB].[dbo].[Tb_LSiswa]";

                DataTable tbl = new DataTable();
                using (var conx = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(csql, conx))
                    {
                        using (var dta = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            dta.Fill(tbl);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, tbl);
            }
            catch (Exception err)
            {
                return Request.CreateResponse(HttpStatusCode.OK, err.Message);
            }
        }


//MVC LSiswa OPEN

        [Authorize]

        // GET: LSiswa
        //Hosted web API REST Service base url  
        string Baseurl = ConfigurationManager.AppSettings["linkWeb"];
        public string userLogin = string.Empty;
        public string usrTypeLogin = string.Empty;
        public async Task<ActionResult> Index()
        {
            try
            {
                if (Session["usrTypeLogin"] == null)
                {
                    string usr = getCokie(); setSession(usr);
                }
                else
                {
                    if (Session["usrTypeLogin"].ToString() != "Siswa") { return RedirectToAction("Index", "Login"); }
                    userLogin = Session["userLogin"].ToString();
                }


                List<Tb_LSiswa> EmpInfo = new List<Tb_LSiswa>();

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/LSiswa");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        EmpInfo = JsonConvert.DeserializeObject<List<Tb_LSiswa>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(EmpInfo);
                }
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // GET: Siswa/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                //buat coding untuk menarik APILSiswa/id
                List<Tb_LSiswa> EmpInfo = new List<Tb_LSiswa>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync("api/LSiswa/" + id);

                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        EmpInfo = JsonConvert.DeserializeObject<List<Tb_LSiswa>>(EmpResponse);

                    }
                    return View(EmpInfo.FirstOrDefault());
                }
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // GET: Siswa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Siswa/Create
        [HttpPost]
        public async Task<ActionResult> Create(string id, FormCollection collection)
        {
            try
            {
                if (Session["usrTypeLogin"] == null)
                {
                    string usr = getCokie(); setSession(usr);
                }
                else
                {
                    if (Session["usrTypeLogin"].ToString() != "Siswa") { return RedirectToAction("Index", "Login"); }
                    userLogin = Session["userLogin"].ToString();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);

                    var parameters = new Dictionary<string, string> {
                        { "Username", Request.Form["Username"] }
                        , { "Password", Request.Form["Password"] }
                        , { "Nama_Siswa", Request.Form["Nama_Siswa"] }
                    , { "creator", userLogin}
                    };

                    var encodedContent = new FormUrlEncodedContent(parameters);
                    //var stringContent = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsync("api/LSiswa", encodedContent);

                }
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // GET: ADProvinsi/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("Index");
                }

                List<Tb_LSiswa> EmpInfo = new List<Tb_LSiswa>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync("api/LSiswa/" + id);
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        EmpInfo = JsonConvert.DeserializeObject<List<Tb_LSiswa>>(EmpResponse);
                    }

                    return View(EmpInfo.FirstOrDefault());
                }
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // POST: ADProvinsi/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, FormCollection collection)
        {
            try
            {
                if (Session["usrTypeLogin"] == null)
                {
                    string usr = getCokie(); setSession(usr);
                }
                else
                {
                    if (Session["usrTypeLogin"].ToString() != "Siswa") { return RedirectToAction("Index", "Login"); }
                    userLogin = Session["userLogin"].ToString();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    var parameters = new Dictionary<string, string> {
                        { "ID",  id }
                        , { "Username", Request.Form["Username"] }
                        , { "Password", Request.Form["Password"] }
                        , { "Nama_Siswa", Request.Form["Nama_Siswa"] }
                        ,{ "edited", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") }
                        ,{ "editor", userLogin }
                      };
                    var encodedContent = new FormUrlEncodedContent(parameters);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PutAsync("api/LSiswa", encodedContent);

                }
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // GET: ADProvinsi/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (Session["usrTypeLogin"] == null)
                {
                    string usr = getCokie(); setSession(usr);
                }
                else
                {
                    if (Session["usrTypeLogin"].ToString() != "Siswa") { return RedirectToAction("Index", "Login"); }
                    userLogin = Session["userLogin"].ToString();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.DeleteAsync("api/LSiswa?ID=" + id + "&userLogin=" + userLogin);

                    return RedirectToAction("Index");
                    //return View(EmpInfo);
                }
            }
            catch (Exception err)
            {
                return View(err.Message);
            }
        }

        // POST: ADProvinsi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private string getCokie()
        {
            try
            {
                string cookieName = string.Empty;
                cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string UserName = ticket.Name;

                return UserName;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }

        private void setSession(string UserName)
        {
            try
            {
                v_Login obj = new v_Login();
                string query = @"select [Nama] ,[typeLogin], Username FROM [dbo].[v_Login] where Username ='" + UserName + "'";
                DataTable table = new DataTable();
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["bawangDB"].ConnectionString))
                {
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.Text;
                            da.Fill(table);
                        }
                    }
                }

                foreach (DataRow row in table.Rows)
                {
                    obj.Nama = row.Field<string>(0);
                    obj.typeLogin = row.Field<string>(1);
                    obj.Username = row.Field<string>(2);
                }

                Session["usrTypeLogin"] = obj.typeLogin;
                Session["Nama_Siswa"] = obj.Nama;
                Session["userLogin"] = UserName;
            }
            catch
            { }
        }
    }
}