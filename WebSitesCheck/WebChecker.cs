using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebSitesCheck
{
    public class WebChecker
    {
        public List<string> siteUrls = new List<string>();
        private Dictionary<string, int> checkedSiteUrls = new Dictionary<string, int>();
        private string url;

        public List<string> InputUrls(int sitesQuantity)
        {
            for(int i = 0; i < sitesQuantity; i++)
            {
                Console.WriteLine("Input site url you would like to check: ");
                siteUrls.Add(Console.ReadLine());
            }
            return siteUrls;
            
        }
        public void UrlCheck(List<string> siteUrls)
        {
            
                foreach(string url in siteUrls)
                {
                    try
                    {
                        this.url = url;
                        HttpWebRequest reqw = (HttpWebRequest)HttpWebRequest.Create(url);
                        HttpWebResponse resp = (HttpWebResponse)reqw.GetResponse();
                        checkedSiteUrls.Add(url, (int)resp.StatusCode);
                    }
                    catch (Exception ex)
                    {
                        string[] code = ex.Message.Split('(', ')');
                        checkedSiteUrls.Add(url, int.Parse(code[1]));
                        Console.WriteLine(ex.Message);
                    }
                }
            
            
            
        }

        public void ShowResults()
        {
            List<string> accessible = new List<string>();
            List<string> notAccessible = new List<string>();
            List<string> unKnown = new List<string>();
            foreach (KeyValuePair<string, int> checkedUrl in checkedSiteUrls)
            {
                if(checkedUrl.Value == 200)
                {
                    accessible.Add(checkedUrl.Key);
                }
                else if (checkedUrl.Value == 500)
                {
                    notAccessible.Add(checkedUrl.Key);
                }
                else if (checkedUrl.Value == 404)
                {
                    unKnown.Add(checkedUrl.Key);
                }
            }
            Console.Write("Accessible [" + accessible.Count + "] : ");
            foreach(string item in accessible)
            {
                Console.Write(item + ", ");
            }
            Console.Write("Not accessible [" + notAccessible.Count + "] : ");
            foreach (string item in notAccessible)
            {
                Console.Write(item + ", ");
            }
            Console.Write("Unknown [" + unKnown.Count + "] : ");
            foreach (string item in unKnown)
            {
                Console.Write(item + ", ");
            }
        }
    }
}
