using Newtonsoft.Json;
using Ninject;
using SSU.Coins.BLL.Interface;
using SSU.Coins.Ioc;
using System;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebPL.Model
{
    public partial class AuthCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CheckSignIn(string login, string password)
        {
            var authLogic = DependenciesResolver.Kernel.Get<IAuthLogic>();

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytePassword = encoding.GetBytes(password);

            if(authLogic.CanLogin(login, bytePassword))
                return JsonConvert.SerializeObject(new { status = "OK" });
            else
                return JsonConvert.SerializeObject(new { status = "Error" });
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string CheckSignUp(string login)
        {
            var authLogic = DependenciesResolver.Kernel.Get<IAuthLogic>();

            if (authLogic.IsExistsLogin(login))
                return JsonConvert.SerializeObject(new { status = "Error" });
            else
                return JsonConvert.SerializeObject(new { status = "OK" });
        } 
    }
}