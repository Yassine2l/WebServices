using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace myDateService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://mondomaine.fr/monAppli/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public String getDate1()
        {
            return DateTime.Now.ToString();

        }

        [WebMethod]
        public String getDate2(Format f)
        {
            DateTime date = DateTime.Now;
            switch (f)
            {
                case Format.JMA:
                    return date.ToString("dd/MM/yyyy");
                    break;
                case Format.HMS:
                    return date.ToString("HH:mm:ss");
                    break;
                case Format.HMSJMA:
                    return date.ToString("HH:mm:ss dd/MM/yyyy");
                    break;
            }
            return date.ToString();

        }

        [WebMethod]
        public Date getDate3()
        {
            DateTime date = DateTime.Now;
            return new Date(date.Day, date.Month, date.Year);

        }
    }
    public class Date
    {
        public int jour;
        public int mois;
        public int annee;
        public Date()
        {
        }
        public Date(int j, int m, int a)
        {
            jour = j; mois = m; annee = a;
        }
    }

    public enum Format
    {
        JMA, // jour mois annee
        HMS, // Heure, minutes, secondes
        HMSJMA
    }
}
