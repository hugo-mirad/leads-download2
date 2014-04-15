using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoFillForm;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using System.Net;
using System.Data.SqlClient;

namespace test_msu
{
    public partial class Form1 : Form
    {
        int i = 0; int j = 0;
        DAL objDal = new DAL();
        Boolean stopebay = true; Boolean stopbackpage = true; Boolean stopclaz = true; Boolean stopoodle = true; Boolean stoplocanto = true;
       
        public Form1()
        {
            InitializeComponent();
        }
        #region fillpage
        string content = "";
        int varexit = 0;
        string str = "";
        int excnt = 0;
        private string FillCurrentPageData(string uri)
        {
            string content = string.Empty;
            try
            {
                if (varexit != 1)
                {
                    try
                    {
                        HttpWebRequest httpreq = default(HttpWebRequest);
                        //= WebRequest.Create(uri)
                        HttpWebResponse httpresp = default(HttpWebResponse);
                        StreamReader sr = default(StreamReader);

                        httpreq = (HttpWebRequest)WebRequest.Create(uri);

                        httpresp = (HttpWebResponse)httpreq.GetResponse();

                        //'Read Data from the Page in to Stream Reader

                        sr = new StreamReader(httpresp.GetResponseStream());
                        //content = sr.ReadToEnd();
                        BackgroundWorker BackgroundWorker1 = new BackgroundWorker();
                        //AddHandler BackgroundWorker1.RunWorkerCompleted, AddressOf BackgroundWorker1_RunWorkerCompleted
                        BackgroundWorker1.WorkerSupportsCancellation = true;
                        BackgroundWorker1.RunWorkerAsync(readStream(sr));
                        BackgroundWorker1.Dispose();
                        sr.Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("timed out"))
                        {
                            if (excnt < 100)
                            {
                                excnt += 1;
                                FillCurrentPageData(uri);
                            }
                        }
                        //if (ex.Message.Contains("The remote server returned an error"))
                        //{
                        //    if (excnt < 100)
                        //    {
                        //        excnt += 1;
                        //        FillCurrentPageData(uri);
                        //    }
                        //    else
                        //        MessageBox.Show(ex.Message);
                        //}
                        //The remote server returned an error: (520).
                    }
                }
                else
                {
                    this.Dispose();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return content;
        }
        public bool readStream(StreamReader sr)
        {

            Application.DoEvents();
            content = sr.ReadToEnd();

            return true;

        }
        #endregion
        #region sites
        #region claz
        public void Claz(string cityname)
        {
            int varcount = 0;
            string price = ""; string title = ""; string desc = "";
            string PhoneNumber = ""; string city = ""; string url = ""; string state = ""; string loc = "";
            string mainurl = "http://" + cityname + ".claz.org/classifieds/vehicles/cars?p=";
            for (int u = 1; u <= 50; u++)
            {
                FillCurrentPageData(mainurl + u);

                Regex r1 = new Regex("<div class=\"heading\">(.*?)</div>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc1 = null;
                mc1 = r1.Matches(str);
                al1.Clear();
                al1.InsertRange(al1.Count, mc1);
                if (al1.Count == 0)
                    return;
                Regex r2 = new Regex("<div class=\"breadcrumbs\">(.*?)</div>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc2 = null;
                mc2 = r2.Matches(str);
                al2.Clear();
                al2.InsertRange(al2.Count, mc2);

                Regex r3 = new Regex("<div class=\"source\">(.*?)</div>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc3 = null;
                mc3 = r3.Matches(str);
                al3.Clear();
                al3.InsertRange(al3.Count, mc3);

                if (al1.Count > 0 && al2.Count > 0 && al3.Count > 0)
                {
                    for (int i = 0; i < al1.Count; i++)
                    {
                        if (al1[i].ToString().IndexOf("title") != -1)
                        {
                            title = al1[i].ToString();
                            title = title.Substring(title.IndexOf("title"), title.IndexOf("onclick") - title.IndexOf("title"));
                            title = title.Replace("title", "");
                            title = title.Replace("onclick", "");
                            title = title.Replace("=", "");
                            title = title.Replace("\"", "").Trim();
                        }
                        if (al1[i].ToString().IndexOf("title") != -1 && al1[i].ToString().IndexOf("href") != -1)
                        {
                            url = al1[i].ToString().Substring(al1[i].ToString().IndexOf("href"), al1[i].ToString().IndexOf("title") - al1[i].ToString().IndexOf("href"));
                            url = url.Replace("href=", "");
                            url = url.Replace("\"", "").Trim();
                        }
                        if (al1[i].ToString().IndexOf("<div class=\"price\">") != -1)
                        {
                            price = al1[i].ToString().Substring(al1[i].ToString().IndexOf("<div class=\"price\">"));
                            price = price.Replace("<div class=\"price\">", "");
                            price = price.Replace("</div>", "");
                        }
                        if (al2[i].ToString().IndexOf("<a class=\"city\"") != -1)
                        {
                            loc = al2[i].ToString().Substring(al2[i].ToString().IndexOf("<a class=\"city\""));
                            loc = loc.Substring(0, loc.IndexOf("</a>"));
                            loc = loc.Substring(loc.LastIndexOf(">"));
                            loc = loc.Replace(">", "");
                            city = loc.Substring(0, loc.IndexOf(","));
                            city = city.Replace(",", "");
                            state = loc.Replace(city, "");
                            state = state.Replace(",", "");
                        }
                        if (al3[i].ToString().IndexOf("</span>") != -1)
                        {
                            PhoneNumber = al3[i].ToString().Substring(0, al3[i].ToString().IndexOf("</span>"));
                            PhoneNumber = PhoneNumber.Replace("</span>", "");
                            PhoneNumber = PhoneNumber.Substring(PhoneNumber.LastIndexOf(">"));
                            PhoneNumber = PhoneNumber.Replace(">", "");
                            PhoneNumber = PhoneNumber.Replace("-", "");
                        }
                        varcount++;
                        //objDal.saveClazLeads(title, price, city, PhoneNumber, url, desc);
                        objDal.SaveLeadsData("", "", title, PhoneNumber, price, url, "", state, city, "", "", "", "", desc, "", "", "", "", "", "", "", "");
                        Navigate.Text = varcount.ToString();
                    }
                }
            }

        }
        #endregion
        #region oodle
        public void GetLeadsForOodle(string state)
        {
            int varcount = 0;
            string mainurl = "http://cars.oodle.com/used-cars/for-sale/" + state + "/condition_used/?o=";

            int res = 0;
            for (int i = 0; i <= 267; i++)
            {
                res = i * 15;
                string url1 = mainurl + res;

                FillCurrentPageData(url1);

                //url list
                Regex r11 = new Regex("<span class=\"listing-title\">(.*?)</span>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al11 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc11 = null;
                mc11 = r11.Matches(str);
                al11.Clear();
                al11.InsertRange(al11.Count, mc11);
                if (al11.Count > 0)
                {
                    if (stopoodle)
                    {
                        for (int k = 0; k < al11.Count; k++)
                        {
                            string sname = ""; string title = ""; string url = "";
                            string price = ""; string phno = "";
                            string location = ""; string description = "";
                            string statename = ""; string city = "";
                            if (stopoodle)
                            {
                                #region data
                                if (al11[k].ToString().IndexOf("href=") != -1)
                                    url = al11[k].ToString().Substring(al11[k].ToString().IndexOf("href="));
                                if(url.IndexOf("title=\"\"") !=-1)
                                url = url.Substring(0, url.IndexOf("title=\"\""));
                                url = url.Replace(",,", "");
                                url = url.Replace("href=", "");
                                url = url.Replace("\"", "");
                                url = "http://cars.oodle.com" + url;
                                FillCurrentPageData(url);
                                //seller-name
                                Regex r1 = new Regex("<span id=\"seller-name\">(.*?)</span>");
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                                System.Text.RegularExpressions.MatchCollection mc1 = null;
                                mc1 = r1.Matches(str);
                                al1.Clear();
                                al1.InsertRange(al1.Count, mc1);
                                if (al1.Count > 0)
                                {
                                    for (int j = 0; j < al1.Count; j++)
                                    {
                                        sname = al1[j].ToString();
                                        if (sname.IndexOf("</a>") != -1)
                                        {
                                            sname = sname.Substring(0, sname.IndexOf("</a>"));
                                            sname = sname.Replace("</a>", "");
                                            sname = sname.Substring(sname.LastIndexOf(">"));
                                            sname = sname.Replace(">", "");
                                        }
                                        else
                                        {
                                            sname = sname.Replace("<span>", "");
                                            sname = sname.Replace("</span>", "");
                                        }
                                    }
                                }

                                //title
                                Regex r2 = new Regex("<h2 id=\"detail-title-text\">(.*?)</h2>");
                                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc2 = null;
                                mc2 = r2.Matches(str);
                                al2.Clear();
                                al2.InsertRange(al2.Count, mc2);
                                if (al2.Count > 0)
                                {
                                    for (int j = 0; j < al2.Count; j++)
                                    {
                                        title = al2[j].ToString();
                                        title = title.Replace("<h2 id=\"detail-title-text\">", "");
                                        title = title.Replace("</h2>", "");
                                        title = title.Replace("\t", "").Trim();
                                    }
                                }

                                //price
                                Regex r3 = new Regex("<div id=\"listing-price\">(.*?)</div>(.*?)</div>");//<span class=\"h2\">(.*?)</span> 
                                // <div class=\"h1gray\">(.*?)</div>
                                System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc3 = null;
                                mc3 = r3.Matches(str);
                                al3.Clear();
                                al3.InsertRange(al3.Count, mc3);
                                if (al3.Count > 0)
                                {
                                    for (int j = 0; j < al3.Count; j++)
                                    {
                                        price = al3[j].ToString();
                                        if (price.IndexOf("<span>") != -1)
                                            price = price.Substring(price.IndexOf("<span>"));
                                        price = price.Replace("<span>", "");
                                        price = price.Replace("</span>", "");
                                        price = price.Replace("</div>", "");
                                        price = price.Replace("\t", "").Trim();
                                    }
                                }

                                //location
                                Regex r4 = new Regex("<div id=\"listing-location\" class=\"clearfix\">(.*?)</div>(.*?)</div>");
                                System.Collections.ArrayList al4 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc4 = null;
                                mc4 = r4.Matches(str);
                                al4.Clear();
                                al4.InsertRange(al4.Count, mc4);
                                if (al4.Count > 0)
                                {
                                    for (int j = 0; j < al4.Count; j++)
                                    {
                                        location = al4[j].ToString();
                                        location = location.Replace("</div>", "");
                                        if (location.LastIndexOf(">") != -1)
                                            location = location.Substring(location.LastIndexOf(">"));
                                        location = location.Replace(">", "");
                                        if (location.IndexOf(",") != -1)
                                        {
                                            city = location.Substring(0, location.IndexOf(","));
                                            statename = location.Replace(city, "");
                                            statename = statename.Replace(",", "");
                                        }
                                        else
                                        {
                                            city = "";
                                            statename = location;
                                        }
                                    }
                                }

                                //description
                                Regex r5 = new Regex("<div id=\"listing-description\" class=\"clearfix\">(.*?)</div>(.*?)</div>");
                                //<div id="listing-description" class="clearfix">
                                System.Collections.ArrayList al5 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc5 = null;
                                mc5 = r5.Matches(str);
                                al5.Clear();
                                al5.InsertRange(al5.Count, mc5);
                                if (al5.Count > 0)
                                {
                                    for (int j = 0; j < al5.Count; j++)
                                    {
                                        description = al5[j].ToString();
                                        if (description.IndexOf("<span>") != -1)
                                        {
                                            description = description.Substring(description.IndexOf("<span>"));
                                            description = description.Replace("<span>", "");
                                            description = description.Replace("</span>", "");
                                            description = description.Replace("</div>", "");

                                            string phone = Regex.Replace(description, "[A-Za-z]", "");
                                            string[] digits = Regex.Split(phone, @"\D+");
                                            for (int ph = 0; ph < digits.Length; ph++)
                                            {
                                                if (digits[ph].Length == 10)
                                                {
                                                    phno = digits[ph];
                                                }

                                                else if ((digits.Length > ph + 2) && digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                                {
                                                    phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                                }

                                                else if ((digits.Length > ph + 1) && digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                                {
                                                    phno = digits[ph] + digits[ph + 1];
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                #region save
                                varcount++;
                                //objDal.SaveoodleData(title, sname, phno, price, statename,city, description, url);
                                objDal.SaveLeadsData("", "", title, phno, price, url, sname, statename, city, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                Navigate.Text = "Page :" + (1 + i).ToString() + "Rec No:" + (varcount + 1).ToString();
                                #endregion
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region locanto
        public void GetLeadsForLocanto(string statecode)
        {
            string pages = ""; int page = 0;
            //string mainurl = "http://www.locanto.com/Vehicles/H/?professional=0&page=";
            string mainurl = "http://" + statecode + ".locanto.com/Vehicles/H/";
            if (stoplocanto)
            {
                FillCurrentPageData(mainurl);

                Regex regexindividual31 = new Regex("<div style=\"padding:3px 0 0 240px;\">(.*?)</div>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList individualCararraylist31 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection regexindividualCollec31 = null;
                regexindividualCollec31 = regexindividual31.Matches(str);
                individualCararraylist31.Clear();
                individualCararraylist31.InsertRange(individualCararraylist31.Count, regexindividualCollec31);
                if (individualCararraylist31.Count > 0)
                {
                    pages = individualCararraylist31[0].ToString().Replace("<div style=\"padding:3px 0 0 240px;\">", "");
                    pages = Regex.Replace(pages, "[^0-9]", "");
                    pages = (int.Parse(pages) / 25).ToString();
                    page = int.Parse(pages);
                    if (page > 79)
                        page = 79;
                }
                for (int p = 0; p <= page; p++)
                {
                    if (stoplocanto)
                    {
                        #region tot

                        FillCurrentPageData(mainurl + p + "/");

                        Regex regexindividual3 = new Regex("<span class=\"textHeader \">(.*?)</span>");
                        str = content;
                        str = content.Replace('\n', ' ');
                        System.Collections.ArrayList individualCararraylist3 = new System.Collections.ArrayList();
                        System.Text.RegularExpressions.MatchCollection regexindividualCollec3 = null;
                        regexindividualCollec3 = regexindividual3.Matches(str);
                        individualCararraylist3.Clear();
                        individualCararraylist3.InsertRange(individualCararraylist3.Count, regexindividualCollec3);

                        for (int dj = 0; dj < individualCararraylist3.Count; dj++)
                        {
                            string desc = ""; string title = ""; string price = "";
                            string pubDate = ""; string name = "";
                            string location = ""; string place = ""; string phno = string.Empty;
                            string state = ""; string city = "";

                            #region fetch
                            string url = individualCararraylist3[dj].ToString();

                            url = url.Substring(url.IndexOf("href="));
                            url = url.Replace("href=", "");
                            url = url.Substring(0, url.IndexOf("onclick"));
                            //url = url.Replace(">", "");
                            url = url.Replace("\"", "");
                            title = individualCararraylist3[dj].ToString();
                            title = title.Replace("<span class=\"textHeader \">", "");
                            title = title.Substring(title.IndexOf(">"));
                            title = title.Replace(">", "").Trim();
                            if (title.IndexOf("<span") != -1)
                            {
                                //location = title.Substring(title.IndexOf("<span"));
                                title = title.Substring(0, title.IndexOf("<span"));
                                //location = location.Replace("<span class=\"textLoc\"", "");
                                //location = location.Replace("</span", "").Trim();
                                //if (location.IndexOf(",") != -1)
                                //    city = location.Substring(0, location.IndexOf(","));
                                //else
                                //    city = location;
                                //state = location.Replace(city, "");
                                //state = state.Replace(",", "");
                                //state = Regex.Replace(state, "[0-9]", "");
                            }
                            else
                                title = title.Replace("</span", "");
                            //location = title.Substring(title.IndexOf("<span"));
                            FillCurrentPageData(url);

                            Regex r3 = new Regex("<div class=\"user_content\">(.*?)</div>");//<span class=\"h2\">(.*?)</span> 
                            // <div class=\"h1gray\">(.*?)</div>
                            System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection mc3 = null;
                            mc3 = r3.Matches(str);
                            al3.Clear();
                            al3.InsertRange(al3.Count, mc3);
                            for (int x = 0; x < al3.Count; x++)
                            {
                                desc = al3[x].ToString();
                                desc = desc.Replace("<div class=\"user_content\">", "");
                                desc = desc.Replace("</div>", "");
                                //desc = desc.Substring(0, desc.IndexOf("<!-- AddThis Button BEGIN -->"));

                                string phone = Regex.Replace(desc, "[A-Za-z]", "");

                                string[] digits = Regex.Split(phone, @"\D+");

                                for (int ph = 0; ph < digits.Length; ph++)
                                {
                                    if (digits[ph].Length == 10)
                                    {
                                        phno = digits[ph];
                                    }
                                    else if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                    {
                                        phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                    }

                                    else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                    {
                                        phno = digits[ph] + digits[ph + 1];
                                    }
                                }
                            }
                            Regex r2 = new Regex("<div class=\"h1gray\">(.*?)</div>");
                            System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection mc2 = null;
                            mc2 = r2.Matches(str);
                            al2.Clear();
                            al2.InsertRange(al2.Count, mc2);

                            for (int i = 0; i < al2.Count; i++)
                            {
                                price = al2[0].ToString();
                                price = price.Replace("<div class=\"h1gray\">", "");
                                price = price.Replace("</div>", "");
                            }
                            Regex r4 = new Regex("<span itemprop=\"postalCode\">(.*?)</span>");
                            System.Collections.ArrayList al4 = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection mc4 = null;
                            mc4 = r4.Matches(str);
                            al4.Clear();
                            al4.InsertRange(al4.Count, mc4);
                            if (al4.Count > 0)
                            {
                                for (int i = 0; i < al4.Count; i++)
                                {
                                    location = al4[0].ToString();
                                    location = location.Replace("<span itemprop=\"postalCode\">", "");
                                    location = location.Replace("</span>", "");
                                    if (location.IndexOf(",") != -1)
                                    {
                                        city = location.Substring(0, location.IndexOf(","));
                                        city = city.Replace(",", "");
                                        //state = location.Substring(location.IndexOf(city));
                                        //state = Regex.Replace(state, "[0-9]", "");
                                    }
                                    else
                                    {
                                        city = location;
                                        //state = "";
                                    }
                                }
                            }
                            #endregion
                            #region Save
                            //objDal.SaveLocanto_Leads(title, desc, state,city, price, phno, url);
                            objDal.SaveLeadsData("", "", title, phno, price, url, "", statecode, city, "", "", "", "", desc, "", "", "", "", "", "", "", "");
                            Navigate.Text = (int.Parse(Navigate.Text) + 1).ToString();
                            #endregion
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
        #region backpage
        public void BackPage(string state)
        {
            string phno = ""; string title = ""; string price = "";
            int varcount = 0; string city = "";
            for (int j = 1; j <= 100; j++)
            {
                string mainurl = "http://" + state.Replace(" ", "").ToLower() + ".backpage.com/AutosForSale/" + "?page=" + j;
                FillCurrentPageData(mainurl);

                Regex r1 = new Regex("<div class=\"cat\">(.*?)</div>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc1 = null;
                mc1 = r1.Matches(str);
                al1.Clear();
                al1.InsertRange(al1.Count, mc1);

                if (al1.Count > 0)
                {
                    if (stopbackpage)
                    {
                        for (int i = 0; i < al1.Count; i++)
                        {
                            if (stopbackpage)
                            {
                                string url = al1[i].ToString();
                                url = url.Replace("<div class=\"cat\">", "");
                                url = url.Substring(0, url.IndexOf(">"));
                                url = url.Replace("<a href=", "");
                                url = url.Replace("\r", "");
                                url = url.Replace("\"", "").Trim();

                                FillCurrentPageData(url);

                                Regex r21 = new Regex("<div style=\"padding-left:2em;\">(.*?)</div>");
                                System.Collections.ArrayList al21 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc21 = null;
                                mc21 = r21.Matches(str);
                                al21.Clear();
                                al21.InsertRange(al21.Count, mc21);
                                if (al21.Count > 0)
                                {
                                    city = al21[0].ToString();
                                    city = city.Replace("<div style=\"padding-left:2em;\">", "");
                                    city = city.Replace("&bull; Location:", "").Trim();
                                    city = city.Replace("</div>", "").Trim();
                                    if (city.IndexOf(",") != -1)
                                    {
                                        city = city.Substring(0, city.IndexOf(","));
                                        city = city.Replace(",", "");
                                    }


                                }

                                Regex r2 = new Regex("<a class=\"h1link\" href=\"javascript:void;\">(.*?)</a>");
                                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc2 = null;
                                mc2 = r2.Matches(str);
                                al2.Clear();
                                al2.InsertRange(al2.Count, mc2);
                                if (al2.Count > 0)
                                {
                                    for (int k = 0; k < al2.Count; k++)
                                    {
                                        title = al2[k].ToString();
                                        title = title.Replace("<a class=\"h1link\" href=\"javascript:void;\">", "");
                                        title = title.Replace("</a>", "");
                                        title = title.Replace("<h1>", "");
                                        title = title.Replace("</h1>", "");
                                        if (title.Contains("$"))
                                        {
                                            title = title.Replace(",", "");
                                            price = title.Substring(0, title.IndexOf(" "));
                                        }
                                    }
                                }

                                Regex r3 = new Regex("<div class=\"postingBody\">(.*?)</div>(.*?)<p class=\"metaInfoDisplay\">");
                                //<span class=\"h2\">(.*?)</span> 
                                // <div class=\"h1gray\">(.*?)</div>
                                System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                                str = content;
                                str = content.Replace('\n', ' ');
                                System.Text.RegularExpressions.MatchCollection mc3 = null;
                                mc3 = r3.Matches(str);
                                al3.Clear();
                                al3.InsertRange(al3.Count, mc3);
                                phno = "";
                                if (al3.Count > 0)
                                {
                                    for (int l = 0; l < al3.Count; l++)
                                    {
                                        string desc = al3[l].ToString();
                                        string phone = Regex.Replace(desc, "[A-Za-z]", "");
                                        string[] digits = Regex.Split(phone, @"\D+");
                                        for (int ph = 0; ph < digits.Length; ph++)
                                        {
                                            if (digits[ph].Length == 10)
                                            {
                                                phno = digits[ph];
                                            }

                                            else if ((digits.Length > ph + 2) && digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                            {
                                                phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                            }

                                            else if ((digits.Length > ph + 1) && digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                            {
                                                phno = digits[ph] + digits[ph + 1];
                                            }
                                        }
                                        if (phno == "")
                                        {
                                            Regex r4 = new Regex("<p class=\"metaInfoDisplay\">(.*?)</p>");
                                            System.Collections.ArrayList al4 = new System.Collections.ArrayList();
                                            str = content;
                                            str = content.Replace('\n', ' ');
                                            System.Text.RegularExpressions.MatchCollection mc4 = null;
                                            mc4 = r4.Matches(str);
                                            al4.Clear();
                                            al4.InsertRange(al4.Count, mc4);
                                            if (al4.Count > 0)
                                            {
                                                for (int m = 0; m < al4.Count; m++)
                                                {
                                                    string desc1 = al4[m].ToString();
                                                    phone = Regex.Replace(desc1, "[A-Za-z]", "");
                                                    digits = Regex.Split(phone, @"\D+");
                                                    for (int ph = 0; ph < digits.Length; ph++)
                                                    {
                                                        if (digits[ph].Length == 10)
                                                        {
                                                            phno = digits[ph];
                                                        }

                                                        else if ((digits.Length > ph + 2) && digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                                        {
                                                            phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                                        }

                                                        else if ((digits.Length > ph + 1) && digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                                        {
                                                            phno = digits[ph] + digits[ph + 1];
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                varcount++;
                                //objDal.SaveBackPageLeads(title, price, phno, cmbState.SelectedItem.ToString().ToLower(), url);
                                objDal.SaveLeadsData("", "", title, phno, price, url, "", state, city, "", "", "", "", "", "", "", "", "", "", "", "", "");
                                Navigate.Text = "Page :" + j.ToString() + "Rec No:" + (varcount + 1).ToString();
                            }
                        }
                    }
                }
            }

        }
        #endregion
        #region ebayclassifieds
        public void Ebayclassifieds(string statename)
        {
            if (stopebay)
            {
                int varcount = 0;
                string sname = ""; string price = ""; string location = "";
                string pho = ""; string desc = ""; string url = ""; string title = "";
                string mainurl = "http://www.ebayclassifieds.com/state/";
                string state = statename.ToLower();
                if (state.Contains(" "))
                    state = state.Replace(" ", "+");
                mainurl = mainurl + state;
                FillCurrentPageData(mainurl);

                Regex r1 = new Regex("<li>(.*?)</li>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection mc1 = null;
                mc1 = r1.Matches(str);
                al1.Clear();
                al1.InsertRange(al1.Count, mc1);
                if (stopebay)
                {
                    if (al1.Count > 0)
                    {
                        for (int i = 0; i < al1.Count; i++)
                        {
                            int page = 0;
                            string a = al1[i].ToString().Replace("<li>", "");
                            a = a.Substring(0, a.IndexOf(">"));
                            a = a.Replace("<a href=", "");
                            a = a.Replace("\"", "");

                            FillCurrentPageData(a + "cars/?catId=100028");

                            Regex r2 = new Regex("<span class=\"ec-breadcrumb\" style=\"padding-left: 5px;\">(.*?)</span>");
                            System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                            str = content;
                            str = content.Replace('\n', ' ');
                            System.Text.RegularExpressions.MatchCollection mc2 = null;
                            mc2 = r2.Matches(str);
                            al2.Clear();
                            al2.InsertRange(al2.Count, mc2);
                            if (al2.Count > 0)
                            {
                                string res = al2[0].ToString();
                                res = Regex.Replace(res, "[A-Za-z]", "");
                                string[] res1 = Regex.Split(res, @"\D+");
                                page = (int.Parse(res1[res1.Length - 2]) / 24) + 1;
                            }
                            if (stopebay)
                            {
                                for (int j = 0; j <= page; j++)
                                {
                                    if (stopebay)
                                    {
                                        #region ebay
                                        FillCurrentPageData(a + "cars/?catId=100028&page=" + j);
                                        Regex r3 = new Regex("<div class=\"ad-title\"><p>(.*?)</p></div>");//<span class=\"h2\">(.*?)</span> 
                                        // <div class=\"h1gray\">(.*?)</div>
                                        System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                                        str = content;
                                        str = content.Replace('\n', ' ');
                                        System.Text.RegularExpressions.MatchCollection mc3 = null;
                                        mc3 = r3.Matches(str);
                                        al3.Clear();
                                        al3.InsertRange(al3.Count, mc3);
                                        if (al3.Count > 0)
                                        {
                                            for (int k = 0; k < al3.Count; k++)
                                            {
                                                url = al3[k].ToString();
                                                url = url.Substring(url.IndexOf("href="), url.IndexOf("id=") - url.IndexOf("href="));
                                                url = url.Replace("href=", "");
                                                url = url.Replace("\"", "");

                                                FillCurrentPageData(url);

                                                Regex r4 = new Regex("<h1 id=\"ad-title\">(.*?)</span></h1>");
                                                System.Collections.ArrayList al4 = new System.Collections.ArrayList();
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection mc4 = null;
                                                mc4 = r4.Matches(str);
                                                al4.Clear();
                                                al4.InsertRange(al4.Count, mc4);
                                                if (al4.Count > 0)
                                                {
                                                    for (int l = 0; l < al4.Count; l++)
                                                    {
                                                        string tot = al4[l].ToString();
                                                        if (tot.IndexOf("<span class=\"price\">") != -1)
                                                        {
                                                            title = tot.Substring(tot.IndexOf("<span>"), tot.IndexOf("<span class=\"price\">") - tot.IndexOf("<span>"));
                                                            tot = tot.Replace(title, "");
                                                            title = title.Replace("<span>", "");
                                                            title = title.Replace("</span>", "");
                                                        }
                                                        if (tot.IndexOf("<span class=\"location\">") != -1)
                                                        {
                                                            price = tot.Substring(tot.IndexOf("<span class=\"price\">"), tot.IndexOf("<span class=\"location\">") - tot.IndexOf("<span class=\"price\">"));
                                                            tot = tot.Replace(price, "");
                                                            price = price.Replace("<span class=\"price\">", "");
                                                            price = price.Replace("</span>", "");
                                                            price = price.Replace("-", "");
                                                        }
                                                        if (tot.IndexOf("<span class=\"location\">") != -1)
                                                        {
                                                            location = tot.Substring(tot.IndexOf("<span class=\"location\">"), tot.IndexOf("</span>") - tot.IndexOf("<span class=\"location\">"));
                                                            location = location.Substring(location.IndexOf(">"));
                                                            location = location.Replace(">", "");
                                                            location = location.Replace("(", "");
                                                            location = location.Replace(")", "");
                                                        }
                                                    }
                                                }

                                                Regex r5 = new Regex("<strong id=\"postedBy\">(.*?)</strong>");
                                                //<div id="listing-description" class="clearfix">
                                                System.Collections.ArrayList al5 = new System.Collections.ArrayList();
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection mc5 = null;
                                                mc5 = r5.Matches(str);
                                                al5.Clear();
                                                al5.InsertRange(al5.Count, mc5);
                                                if (al5.Count > 0)
                                                {
                                                    for (int m = 0; m < al5.Count; m++)
                                                    {
                                                        sname = al5[m].ToString();
                                                        sname = sname.Replace("<strong id=\"postedBy\">", "");
                                                        sname = sname.Replace("</strong>", "");
                                                    }
                                                }

                                                Regex r6 = new Regex("<li class=\"desc-text\">(.*?)</li>");
                                                System.Collections.ArrayList al6 = new System.Collections.ArrayList();
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection mc6 = null;
                                                mc6 = r6.Matches(str);
                                                al6.Clear();
                                                al6.InsertRange(al6.Count, mc6);
                                                if (al6.Count > 0)
                                                {
                                                    for (int n = 0; n < al6.Count; n++)
                                                    {
                                                        desc = al6[n].ToString();
                                                        desc = desc.Replace("<li class=\"desc-text\">", "");
                                                        desc = desc.Replace("</li>", "");
                                                    }
                                                }

                                                Regex r7 = new Regex("<span class=\"bld phd orange-text\">(.*?)</span>");
                                                //<div id="listing-description" class="clearfix">
                                                System.Collections.ArrayList al7 = new System.Collections.ArrayList();
                                                str = content;
                                                str = content.Replace('\n', ' ');
                                                System.Text.RegularExpressions.MatchCollection mc7 = null;
                                                mc7 = r7.Matches(str);
                                                al7.Clear();
                                                al7.InsertRange(al7.Count, mc7);
                                                if (al7.Count > 0)
                                                {
                                                    for (int p = 0; p < al7.Count; p++)
                                                    {
                                                        string ph = al7[p].ToString();
                                                        if (ph.IndexOf("{") != -1)
                                                        {
                                                            ph = ph.Substring(ph.IndexOf("{"), ph.IndexOf("}") - ph.IndexOf("{"));
                                                            ph = ph.Substring(0, ph.LastIndexOf(","));
                                                            string[] ph1 = ph.Split(',');
                                                            pho = "";
                                                            foreach (string phindex in ph1)
                                                            {
                                                                string abs = phindex.ToString();
                                                                pho += abs.Substring(abs.IndexOf(":"));
                                                                pho = pho.Replace("'", "");
                                                                pho = pho.Replace(":", "");
                                                                pho = Regex.Replace(pho, "[^0-9a-zA-Z]+", "");
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                                varcount++;
                                                //objDal.SaveebayData(title, sname, pho, price, location, desc, url, state);
                                                objDal.SaveLeadsData("", "", title, pho, price, url, sname, state, location, "", "", "", "", desc, "", "", "", "", "", "", "", "");
                                                Navigate.Text = "Rec No:" + (varcount + 1).ToString();
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region globalfreeclassifiedads
        public void GetLeadsForGlobal()
        {
            int varcount = 0;
            for (int a = 1; a <= 43; a++)
            {
                string mainurl = "http://usa.global-free-classified-ads.com/cars-cid-14-page-" + a;
                FillCurrentPageData(mainurl);

                //<span class="location">
                Regex r2 = new Regex("<span class=\"location\">(.*?)</span>");
                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                str = content;
                str = content.Replace('\n', ' ');
                System.Text.RegularExpressions.MatchCollection mc2 = null;
                mc2 = r2.Matches(str);
                al2.Clear();
                al2.InsertRange(al2.Count, mc2);
                
                Regex regexindividual31 = new Regex("<h1>(.*?)</h1>");
                str = content;
                str = content.Replace('\n', ' ');
                System.Collections.ArrayList individualCararraylist31 = new System.Collections.ArrayList();
                System.Text.RegularExpressions.MatchCollection regexindividualCollec31 = null;
                regexindividualCollec31 = regexindividual31.Matches(str);
                individualCararraylist31.Clear();
                individualCararraylist31.InsertRange(individualCararraylist31.Count, regexindividualCollec31);
                for (int p = 0; p < individualCararraylist31.Count; p++)
                {

                    string desc = ""; string title = ""; string price = "";
                    string pubDate = ""; string name = "";
                    string location = ""; string place = ""; string phno = string.Empty;
                    string city = ""; string state = "";
                    string url = individualCararraylist31[p].ToString();
                    url = url.Substring(url.IndexOf("href="));
                    url = url.Replace("href=", "");
                    url = url.Substring(0, url.IndexOf(">"));
                    url = url.Replace("\"", "");

                    location = al2[p].ToString().Replace("<span class=\"location\">", "");
                    location = location.Replace("</span>", "");
                    location = location.Replace("</a>", "");
                    if(location.IndexOf(">") != -1)
                    location = location.Substring(location.IndexOf(">"));
                    location = location.Replace("Cars", "");
                    location = location.Replace(">", "");
                    location = location.Replace(":", "");
                    if (location.IndexOf(",") != -1)
                    {
                        city = location.Substring(0, location.IndexOf(","));
                        state = location.Replace(city + ",", "");
                        if (state.IndexOf(",") != -1)
                            state = state.Substring(0, state.IndexOf(","));
                    }
                    else
                    {
                        state = location;
                        city = "";
                    }
                    FillCurrentPageData(url);

                    Regex r3 = new Regex("<div class=\"content_box_1\">(.*?)</div>");
                    System.Collections.ArrayList al3 = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection mc3 = null;
                    mc3 = r3.Matches(str);
                    al3.Clear();
                    al3.InsertRange(al3.Count, mc3);
                    for (int x = 0; x < al3.Count; x++)
                    {
                        if (al3[x].ToString().Contains("Seller's Comments and Description:"))
                        {
                            desc = al3[x].ToString();
                            desc = desc.Replace("<div class=\"user_content\">", "");
                            desc = desc.Replace("</div>", "");
                            desc = desc.Replace("<div class=\"content_box_1\">", "");
                            desc = desc.Replace("<h3>Seller's Comments and Description:</h3>", "");
                            desc = desc.Replace("<p>", "");
                            string phone = Regex.Replace(desc, "[A-Za-z]", "");

                            string[] digits = Regex.Split(phone, @"\D+");

                            for (int ph = 0; ph < digits.Length; ph++)
                            {
                                if (digits[ph].Length == 10)
                                {
                                    phno = digits[ph];
                                }
                                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
                                {
                                    phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
                                }

                                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
                                {
                                    phno = digits[ph] + digits[ph + 1];
                                }
                            }
                        }
                    }
                    //Regex r2 = new Regex("<p class=\"content_section\">(.*?)</p>");
                    //System.Collections.ArrayList al2 = new System.Collections.ArrayList();
                    //str = content;
                    //str = content.Replace('\n', ' ');
                    //System.Text.RegularExpressions.MatchCollection mc2 = null;
                    //mc2 = r2.Matches(str);
                    //al2.Clear();
                    //al2.InsertRange(al2.Count, mc2);

                    //location = al2[1].ToString();
                    //location = location.Replace("<p class=\"content_section\">", "");
                    //location = location.Replace("</p>", "").Trim();
                    //if (location.IndexOf(",") == 0)
                    //{
                    //    city = location.Substring(1);
                    //    if (city.IndexOf(",") != -1)
                    //    {
                    //        city = city.Substring(0, city.IndexOf(",")).Trim();
                    //        state = location.Substring(1);
                    //        state = state.Replace(city + ",", "");
                    //        if (state.IndexOf(",") != -1)
                    //            state = state.Substring(0, state.IndexOf(",")).Trim();
                    //        else state = city;
                    //    }
                    //    else
                    //    {
                    //        state = city;
                    //        city = "";
                    //    }
                    //}
                    //else
                    //{
                    //    if (location.IndexOf(",") == -1)
                    //    {
                    //        city = location;
                    //        state = "";
                    //    }
                    //    else
                    //    {
                    //        location = location.Substring(location.IndexOf(",")).Trim();
                    //        if (location.IndexOf(",") == 0)
                    //        {
                    //            city = location.Substring(1);
                    //            if (city.IndexOf(",") != -1)
                    //                city = city.Substring(0, city.IndexOf(",")).Trim();
                    //            else
                    //                city = "";
                    //            state = location.Substring(1);
                    //            state = state.Replace(city + ",", "");
                    //            if (state.IndexOf(",") != -1)
                    //                state = state.Substring(0, state.IndexOf(",")).Trim();
                    //            else
                    //                state = city;
                    //        }
                    //    }
                    //}
                    Regex r21 = new Regex("<h1 class=\"seller_username\">(.*?)</h1>");
                    System.Collections.ArrayList al21 = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection mc21 = null;
                    mc21 = r21.Matches(str);
                    al21.Clear();
                    al21.InsertRange(al21.Count, mc21);

                    if (al21.Count > 0)
                    {
                        name = al21[0].ToString();
                        name = name.Replace("</a>", "");
                        name = name.Replace("</h1>", "");
                        name = name.Substring(name.LastIndexOf(">"));
                        name = name.Replace(">", "");
                    }
                    Regex r211 = new Regex("<h1 class=\"listing_title\" style=\"display: inline;\">(.*?)</h1>");
                    System.Collections.ArrayList al211 = new System.Collections.ArrayList();
                    str = content;
                    str = content.Replace('\n', ' ');
                    System.Text.RegularExpressions.MatchCollection mc211 = null;
                    mc211 = r211.Matches(str);
                    al211.Clear();
                    al211.InsertRange(al211.Count, mc211);

                    for (int i = 0; i < al211.Count; i++)
                    {
                        string title1 = al211[i].ToString();
                        title1 = title1.Replace("<h1 class=\"listing_title\" style=\"display: inline;\">", "");
                        title = title1.Substring(0, title1.IndexOf("<span"));
                        title1 = title1.Replace(title, "");
                        price = title1.Replace("<span class=\"value price\">", "");
                        price = price.Substring(0, price.IndexOf("<"));
                    }
                    varcount++;
                    objDal.SaveLeadsData("", "", title, phno, price, url, "", state, city, location, "", "", "", desc, "", "", "", "", "", "", "", "");
                    //objDal.SaveGlobal(title, price, phno, city, state, name, a, url);
                    Navigate.Text = "Page :" + a.ToString() + "Rec No:" + (varcount + 1).ToString();
                }
            }
        }
        #endregion
        
        #region Dump
        #region carvelocity not done
        //public void GetLeadsForcarvelocity(string StateN, string CityN, int StateID)
        //{
        //    StateN = StateN.ToLower();
        //    CityN = CityN.ToLower();
        //    string mainurl = "http://www.carvelocity.com/loc/" + StateN+"/"+CityN;
        //    FillCurrentPageData(mainurl);

        //    Regex regexindividual31 = new Regex("<div class=\"gr_title\">(.*?)</div>");
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Collections.ArrayList individualCararraylist31 = new System.Collections.ArrayList();
        //    System.Text.RegularExpressions.MatchCollection regexindividualCollec31 = null;
        //    regexindividualCollec31 = regexindividual31.Matches(str);
        //    individualCararraylist31.Clear();
        //    individualCararraylist31.InsertRange(individualCararraylist31.Count, regexindividualCollec31);

        //    Regex regexindividual311 = new Regex("<td class=\"dxpSummary\" nowrap=\"nowrap\">(.*?)</td>");//<tr><td class=\"dxpSummary\" style=\"white-space:nowrap;\">(.*?)</tr>");
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Collections.ArrayList individualCararraylist311 = new System.Collections.ArrayList();
        //    System.Text.RegularExpressions.MatchCollection regexindividualCollec311 = null;
        //    regexindividualCollec311 = regexindividual311.Matches(str);
        //    individualCararraylist311.Clear();
        //    individualCararraylist311.InsertRange(individualCararraylist311.Count, regexindividualCollec311);
        //    if (individualCararraylist311.Count>0)
        //    {
        //        string pages = individualCararraylist311[0].ToString();
        //        pages = pages.Replace("", "");
        //        pages = pages.Substring(pages.IndexOf("of"),pages.IndexOf("("));
        //    }
        //for (int p = 0; p < 26; p++)
        //{
        //    #region tot

        //    FillCurrentPageData(mainurl);

        //    Regex regexindividual3 = new Regex("<span class=\"textHeader \">(.*?)</span>");
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Collections.ArrayList individualCararraylist3 = new System.Collections.ArrayList();
        //    System.Text.RegularExpressions.MatchCollection regexindividualCollec3 = null;
        //    regexindividualCollec3 = regexindividual3.Matches(str);
        //    individualCararraylist3.Clear();
        //    individualCararraylist3.InsertRange(individualCararraylist3.Count, regexindividualCollec3);

        //    for (int dj = 0; dj < individualCararraylist3.Count; dj++)
        //    {
        //        string desc = ""; string title = ""; string price = "";
        //        string phno = "";
        //        FillCurrentPageData("http://www.carvelocity.com/used-chevrolet-150-1957-alexander-city/7004620");
        //        Regex r3 = new Regex("<span id=\"LblListingTitle\" class=\"listingType\">(.*?)</span>");
        //        System.Collections.ArrayList al3 = new System.Collections.ArrayList();
        //        str = content;
        //        str = content.Replace('\n', ' ');
        //        System.Text.RegularExpressions.MatchCollection mc3 = null;
        //        mc3 = r3.Matches(str);
        //        al3.Clear();
        //        al3.InsertRange(al3.Count, mc3);
        //        for (int x = 0; x < al3.Count; x++)
        //        {
        //            title = al3[x].ToString();
        //            title = title.Replace("<span id=\"LblListingTitle\" class=\"listingType\">", "");
        //            title = title.Replace("</span>", "");
        //            title = title.Replace("</strong>", "");
        //            price = title.Substring(title.IndexOf("<strong>"));
        //            price = price.Replace("<strong>", "");
        //            title = title.Substring(title.IndexOf("&nbsp"));
        //        }
        //        Regex r2 = new Regex("<div class=\"top-content\">(.*?)</div>");
        //        System.Collections.ArrayList al2 = new System.Collections.ArrayList();
        //        str = content;
        //        str = content.Replace('\n', ' ');
        //        System.Text.RegularExpressions.MatchCollection mc2 = null;
        //        mc2 = r2.Matches(str);
        //        al2.Clear();
        //        al2.InsertRange(al2.Count, mc2);

        //        for (int i = 0; i < al2.Count; i++)
        //        {
        //            desc = al2[i].ToString();
        //            string phone = Regex.Replace(desc, "[A-Za-z]", "");
        //            string[] digits = Regex.Split(phone, @"\D+");
        //            for (int ph = 0; ph < digits.Length; ph++)
        //            {
        //                if (digits[ph].Length == 10)
        //                {
        //                    phno = digits[ph];
        //                }
        //                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 3 && digits[ph + 2].Length == 4)
        //                {
        //                    phno = digits[ph] + digits[ph + 1] + digits[ph + 2];
        //                }

        //                else if (digits[ph].Length == 3 && digits[ph + 1].Length == 7)
        //                {
        //                    phno = digits[ph] + digits[ph + 1];
        //                }
        //            }
        //        }
        //        Regex r21 = new Regex("<div class=\"listingDescription\">(.*?)</div>");
        //        //<span id="LblDescription" class="textgen">(.*?)</span>
        //        System.Collections.ArrayList al21 = new System.Collections.ArrayList();
        //        str = content;
        //        str = content.Replace('\n', ' ');
        //        System.Text.RegularExpressions.MatchCollection mc21 = null;
        //        mc21 = r21.Matches(str);
        //        al21.Clear();
        //        al21.InsertRange(al21.Count, mc21);

        //        for (int i = 0; i < al21.Count; i++)
        //        {
        //            desc = al21[i].ToString();
        //        }

        //        //SaveLocanto_Leads(title, desc, location, price, phno, url);
        //        Navigate.Text = (int.Parse(Navigate.Text) + 1).ToString();
        //    }
        //    #endregion
        //}
        //}
        #endregion
        //public void RegexCollections()
        //{
        //    string mainurl = "http://cars.oodle.com/view/2008-bmw-x5-3-0si/3619472752-normandy-tn/";
        //    FillCurrentPageData(mainurl);

        //    Regex r1 = new Regex("<span id=\"seller-name\">(.*?)</span>");
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Collections.ArrayList al1 = new System.Collections.ArrayList();
        //    System.Text.RegularExpressions.MatchCollection mc1 = null;
        //    mc1 = r1.Matches(str);
        //    al1.Clear();
        //    al1.InsertRange(al1.Count, mc1);

        //    Regex r2 = new Regex("<h2 id=\"detail-title-text\">(.*?)</h2>");
        //    System.Collections.ArrayList al2 = new System.Collections.ArrayList();
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Text.RegularExpressions.MatchCollection mc2 = null;
        //    mc2 = r2.Matches(str);
        //    al2.Clear();
        //    al2.InsertRange(al2.Count, mc2);

        //    Regex r3 = new Regex("<div id=\"listing-price\">(.*?)</div>(.*?)</div>");//<span class=\"h2\">(.*?)</span> 
        //    // <div class=\"h1gray\">(.*?)</div>
        //    System.Collections.ArrayList al3 = new System.Collections.ArrayList();
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Text.RegularExpressions.MatchCollection mc3 = null;
        //    mc3 = r3.Matches(str);
        //    al3.Clear();
        //    al3.InsertRange(al3.Count, mc3);

        //    Regex r4 = new Regex("<div id=\"listing-location\" class=\"clearfix\">(.*?)</div>(.*?)</div>");
        //    System.Collections.ArrayList al4 = new System.Collections.ArrayList();
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Text.RegularExpressions.MatchCollection mc4 = null;
        //    mc4 = r4.Matches(str);
        //    al4.Clear();
        //    al4.InsertRange(al4.Count, mc4);

        //    Regex r5 = new Regex("<div id=\"listing-description\" class=\"clearfix\">(.*?)</div>(.*?)</div>");
        //    //<div id="listing-description" class="clearfix">
        //    System.Collections.ArrayList al5 = new System.Collections.ArrayList();
        //    str = content;
        //    str = content.Replace('\n', ' ');
        //    System.Text.RegularExpressions.MatchCollection mc5 = null;
        //    mc5 = r5.Matches(str);
        //    al5.Clear();
        //    al5.InsertRange(al5.Count, mc5);
        //}
        #region claz
        //        public void Claz()
        //        {
        //            int varcount = 0;
        //            string price = ""; string title = ""; string desc = "";
        //            string PhoneNumber = ""; string city = "";
        //            string mainurl = "http://claz.org/classifieds/vehicles/cars?p=";
        //            for (int u = 1; u <= 50; u++)
        //            {
        //                FillCurrentPageData(mainurl + u);

        //                Regex r1 = new Regex("<div class=\"heading\">(.*?)</div>");
        //                str = content;
        //                str = content.Replace('\n', ' ');
        //                System.Collections.ArrayList al1 = new System.Collections.ArrayList();
        //                System.Text.RegularExpressions.MatchCollection mc1 = null;
        //                mc1 = r1.Matches(str);
        //                al1.Clear();
        //                al1.InsertRange(al1.Count, mc1);
        //                if (al1.Count > 0)
        //                {
        //                    for (int i = 0; i < al1.Count; i++)
        //                    {
        //                        string url = al1[i].ToString();
        //                        price = url.IndexOf("<div class=\"price\">") != -1 ? url.Substring(url.IndexOf("<div class=\"price\">")) : "";
        //                        price = price.Replace("<div class=\"price\">", "");
        //                        price = price.Replace("</div>", "");
        //                        //if (url.IndexOf("title=") != -1 && url.IndexOf("href=") != -1)
        //                        {
        //                            url = url.Substring(url.IndexOf("href="), url.IndexOf("title=") - url.IndexOf("href=")).Trim();
        //                            url = url.Replace("href=", "");
        //                            url = url.Replace("\"", "");
        //                        }
        //                        FillCurrentPageData(url);
        //                        Regex r2 = new Regex("<h1 itemprop=\"name\">(.*?)</h1>");
        //                        System.Collections.ArrayList al2 = new System.Collections.ArrayList();
        //                        str = content;
        //                        str = content.Replace('\n', ' ');
        //                        System.Text.RegularExpressions.MatchCollection mc2 = null;
        //                        mc2 = r2.Matches(str);
        //                        al2.Clear();
        //                        al2.InsertRange(al2.Count, mc2);
        //                        if (al2.Count > 0)
        //                        {
        //                            for (int j = 0; j < al2.Count; j++)
        //                            {
        //                                title = al2[j].ToString().Replace("<h1 itemprop=\"name\">", "");
        //                                title = title.Replace("</h1>", "");
        //                            }
        //                        }
        //                        Regex r3 = new Regex("<h2>(.*?)</h2>");//<span class=\"h2\">(.*?)</span> 
        //                        // <div class=\"h1gray\">(.*?)</div>
        //                        System.Collections.ArrayList al3 = new System.Collections.ArrayList();
        //                        str = content;
        //                        str = content.Replace('\n', ' ');
        //                        System.Text.RegularExpressions.MatchCollection mc3 = null;
        //                        mc3 = r3.Matches(str);
        //                        al3.Clear();
        //                        al3.InsertRange(al3.Count, mc3);
        //                        if (al3.Count > 0)
        //                        {
        //                            for (int j = 0; j < al3.Count; j++)
        //                            {
        //                                city = al3[j].ToString().Replace("<h2>", "");
        //                                city = city.Replace("> Classifieds > Vehicles > Cars</a></h2>", "");
        //                                city=city.Substring(city.IndexOf(">"));
        //                                city = city.Replace(">", "").Trim();
        //                            }
        //                        }
        //                        Regex r4 = new Regex("<div style=\"padding:30px 0 20px 0;(.*?) itemprop=\"description\" >(.*?)</div>");
        //                        System.Collections.ArrayList al4 = new System.Collections.ArrayList();
        //                        str = content;
        //                        str = content.Replace('\n', ' ');
        //                        System.Text.RegularExpressions.MatchCollection mc4 = null;
        //                        mc4 = r4.Matches(str);
        //                        al4.Clear();
        //                        al4.InsertRange(al4.Count, mc4);
        //                        if (al4.Count > 0)
        //                        {
        //                            for (int j = 0; j < al4.Count; j++)
        //                            {
        //                                desc = al4[j].ToString().Substring(al4[j].ToString().IndexOf(">"));
        //                                string sentence = desc;//.Replace(" ","").Trim();
        //                                string[] digits = Regex.Split(sentence, @"\D+");
        //                                PhoneNumber = "";
        //                                #region phone
        //                                for (int p = 0; p < digits.Length; p++)
        //                                {
        //                                    if (digits[p].Length == 10)
        //                                    {
        //                                            PhoneNumber = digits[p];
        //                                    }
        //                                    else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
        //                                    {
        //                                        PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
        //                                    }

        //                                    else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
        //                                    {
        //                                        PhoneNumber = digits[p] + digits[p + 1];
        //                                    }
        //                                }
        //                                if (PhoneNumber == "")
        //                                {
        //                                    sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
        //                                    sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
        //                                    sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
        //                                    sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
        //                                    sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");

        //                                    sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
        //                                    digits = Regex.Split(sentence, @"\D+");
        //                                    string PhoneNumber1 = string.Empty;

        //                                    for (int p = 0; p < digits.Length; p++)
        //                                    {
        //                                        if (digits[p].Length == 10)
        //                                        {
        //                                                PhoneNumber = digits[p];
        //                                        }
        //                                        if (p + 1 < digits.Length)
        //                                        {
        //                                            if ((p + 2 < digits.Length))
        //                                            {
        //                                                if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
        //                                                {
        //                                                    PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
        //                                                }
        //                                            }
        //                                            else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
        //                                            {
        //                                                PhoneNumber = digits[p] + digits[p + 1];
        //                                            }
        //                                        }
        //                                        else if (digits[p].Length == 11)
        //                                        {
        //                                            PhoneNumber = digits[p];
        //                                            if (PhoneNumber[0] == 0 || PhoneNumber[0] == 1)
        //                                            {
        //                                                PhoneNumber = PhoneNumber.Substring(1);
        //                                            }
        //                                            else if (PhoneNumber[10] == 0)
        //                                            {
        //                                                PhoneNumber = PhoneNumber.Substring(0, 10);
        //                                            }
        //                                        }

        //                                    }
        //                                }

        //#endregion
        //                            }
        //                        }
        //                        varcount++;
        //                        objDal.saveClazLeads(title, price, city, PhoneNumber, url, desc);
        //                        Navigate.Text = varcount.ToString();
        //                    }
        //                }
        //            }
        //        }
        #endregion
        #region claz with cities
        //public void Claz(string cityname)
        //{
        //    int varcount = 0;
        //    string price = ""; string title = ""; string desc = "";
        //    string PhoneNumber = ""; string city = "";
        //    string mainurl = "http://"+cityname+".claz.org/classifieds/vehicles/cars?p=";
        //    for (int u = 1; u <= 50; u++)
        //    {
        //        FillCurrentPageData(mainurl + u);

        //        Regex r1 = new Regex("<div class=\"heading\">(.*?)</div>");
        //        str = content;
        //        str = content.Replace('\n', ' ');
        //        System.Collections.ArrayList al1 = new System.Collections.ArrayList();
        //        System.Text.RegularExpressions.MatchCollection mc1 = null;
        //        mc1 = r1.Matches(str);
        //        al1.Clear();
        //        al1.InsertRange(al1.Count, mc1);
        //        if (al1.Count > 0)
        //        {
        //            for (int i = 0; i < al1.Count; i++)
        //            {
        //                string url = al1[i].ToString();
        //                price = url.IndexOf("<div class=\"price\">") != -1 ? url.Substring(url.IndexOf("<div class=\"price\">")) : "";
        //                price = price.Replace("<div class=\"price\">", "");
        //                price = price.Replace("</div>", "");
        //                //if (url.IndexOf("title=") != -1 && url.IndexOf("href=") != -1)
        //                {
        //                    url = url.Substring(url.IndexOf("href="), url.IndexOf("title=") - url.IndexOf("href=")).Trim();
        //                    url = url.Replace("href=", "");
        //                    url = url.Replace("\"", "");
        //                }
        //                FillCurrentPageData(url);
        //                Regex r2 = new Regex("<h1 itemprop=\"name\">(.*?)</h1>");
        //                System.Collections.ArrayList al2 = new System.Collections.ArrayList();
        //                str = content;
        //                str = content.Replace('\n', ' ');
        //                System.Text.RegularExpressions.MatchCollection mc2 = null;
        //                mc2 = r2.Matches(str);
        //                al2.Clear();
        //                al2.InsertRange(al2.Count, mc2);
        //                if (al2.Count > 0)
        //                {
        //                    for (int j = 0; j < al2.Count; j++)
        //                    {
        //                        title = al2[j].ToString().Replace("<h1 itemprop=\"name\">", "");
        //                        title = title.Replace("</h1>", "");
        //                    }
        //                }
        //                Regex r3 = new Regex("<h2>(.*?)</h2>");//<span class=\"h2\">(.*?)</span> 
        //                // <div class=\"h1gray\">(.*?)</div>
        //                System.Collections.ArrayList al3 = new System.Collections.ArrayList();
        //                str = content;
        //                str = content.Replace('\n', ' ');
        //                System.Text.RegularExpressions.MatchCollection mc3 = null;
        //                mc3 = r3.Matches(str);
        //                al3.Clear();
        //                al3.InsertRange(al3.Count, mc3);
        //                if (al3.Count > 0)
        //                {
        //                    for (int j = 0; j < al3.Count; j++)
        //                    {
        //                        city = al3[j].ToString().Replace("<h2>", "");
        //                        city = city.Replace("> Classifieds > Vehicles > Cars</a></h2>", "");
        //                        city = city.Substring(city.IndexOf(">"));
        //                        city = city.Replace(">", "").Trim();
        //                    }
        //                }
        //                Regex r4 = new Regex("<div style=\"padding:30px 0 20px 0;(.*?) itemprop=\"description\" >(.*?)</div>");
        //                System.Collections.ArrayList al4 = new System.Collections.ArrayList();
        //                str = content;
        //                str = content.Replace('\n', ' ');
        //                System.Text.RegularExpressions.MatchCollection mc4 = null;
        //                mc4 = r4.Matches(str);
        //                al4.Clear();
        //                al4.InsertRange(al4.Count, mc4);
        //                if (al4.Count > 0)
        //                {
        //                    #region if
        //                    for (int j = 0; j < al4.Count; j++)
        //                    {
        //                        desc = al4[j].ToString().Substring(al4[j].ToString().IndexOf(">"));
        //                        string sentence = desc;//.Replace(" ","").Trim();
        //                        string[] digits = Regex.Split(sentence, @"\D+");
        //                        PhoneNumber = "";
        //                        #region phone
        //                        for (int p = 0; p < digits.Length; p++)
        //                        {
        //                            if (digits[p].Length == 10)
        //                            {
        //                                PhoneNumber = digits[p];
        //                            }
        //                            else if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
        //                            {
        //                                PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
        //                            }

        //                            else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
        //                            {
        //                                PhoneNumber = digits[p] + digits[p + 1];
        //                            }
        //                        }
        //                        if (PhoneNumber == "")
        //                        {
        //                            sentence = sentence.ToLower(); sentence = sentence.Replace(" ", "").Trim();
        //                            sentence = sentence.Replace("one", "1"); sentence = sentence.Replace("two", "2"); sentence = sentence.Replace("three", "3");
        //                            sentence = sentence.Replace("four", "4"); sentence = sentence.Replace("five", "5"); sentence = sentence.Replace("six", "6");
        //                            sentence = sentence.Replace("seven", "7"); sentence = sentence.Replace("eight", "8"); sentence = sentence.Replace("nine", "9");
        //                            sentence = sentence.Replace("zero", "0"); sentence = sentence.Replace("o", "0");

        //                            sentence = Regex.Replace(sentence, @"[^a-zA-Z0-9]", "");
        //                            digits = Regex.Split(sentence, @"\D+");
        //                            string PhoneNumber1 = string.Empty;

        //                            for (int p = 0; p < digits.Length; p++)
        //                            {
        //                                if (digits[p].Length == 10)
        //                                {
        //                                    PhoneNumber = digits[p];
        //                                }
        //                                if (p + 1 < digits.Length)
        //                                {
        //                                    if ((p + 2 < digits.Length))
        //                                    {
        //                                        if (digits[p].Length == 3 && digits[p + 1].Length == 3 && digits[p + 2].Length == 4)
        //                                        {
        //                                            PhoneNumber = digits[p] + digits[p + 1] + digits[p + 2];
        //                                        }
        //                                    }
        //                                    else if (digits[p].Length == 3 && digits[p + 1].Length == 7)
        //                                    {
        //                                        PhoneNumber = digits[p] + digits[p + 1];
        //                                    }
        //                                }
        //                                else if (digits[p].Length == 11)
        //                                {
        //                                    PhoneNumber = digits[p];
        //                                    if (PhoneNumber[0] == 0 || PhoneNumber[0] == 1)
        //                                    {
        //                                        PhoneNumber = PhoneNumber.Substring(1);
        //                                    }
        //                                    else if (PhoneNumber[10] == 0)
        //                                    {
        //                                        PhoneNumber = PhoneNumber.Substring(0, 10);
        //                                    }
        //                                }

        //                            }
        //                        }

        //                        #endregion
        //                    }
        //                    #endregion
        //                }

        //                varcount++;
        //                objDal.saveClazLeads(title, price, city, PhoneNumber, url, desc);
        //                Navigate.Text = varcount.ToString();
        //            }
        //        }
        //        else return;
        //    }
        //}
        #endregion
        #endregion
        #endregion
        
        private void cmbSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSites.SelectedItem.ToString() == "oodle")
            {
                Form1.ActiveForm.Text = "oodle";
                cmbState_old.Visible = true;
                cmbState.Visible = false;
                clazcities.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                DataSet ds = objDal.Get_Categories("usp_GetCategories");
                cmbState_old.DataSource = ds;
                cmbState_old.DisplayMember = "Table.Category";
                cmbState_old.ValueMember = "Table.CatId";
            }
            if (cmbSites.SelectedItem.ToString() == "ebay")
            {
                Form1.ActiveForm.Text = "ebay";
                cmbState.Visible = true;
                cmbState_old.Visible = false;
                clazcities.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                DataSet ds = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_ebay");
                cmbState.DataSource = ds;
                cmbState.DisplayMember = "Table.State_Name";
                cmbState.ValueMember = "Table.State_Id";
                //if(ds.Tables[0].Rows.Count>0)
                //cmbState.Text = ds.Tables[0].Rows[0]["State_Code"].ToString();
                //else cmbState.Text = "";
            }
            if (cmbSites.SelectedItem.ToString() == "global")
            {
                Form1.ActiveForm.Text = "global";
                cmbState.Visible = false;
                cmbState_old.Visible = false;
                clazcities.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
            }
            if (cmbSites.SelectedItem.ToString() == "backpage")
            {
                Form1.ActiveForm.Text = "backpage";
                cmbState.Visible = true;
                cmbState_old.Visible = false;
                clazcities.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                DataSet ds = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_backpage");
                cmbState.DataSource = ds;
                cmbState.DisplayMember = "Table.State_Name";
                cmbState.ValueMember = "Table.State_Id";
                //if (ds.Tables[0].Rows.Count > 0)
                //    cmbState.Text = ds.Tables[0].Rows[0]["State_Code"].ToString();
                //else cmbState.Text = "";
            }
            if (cmbSites.SelectedItem.ToString() == "locanto")
            {
                Form1.ActiveForm.Text = "locanto";
                cmbState.Visible = true;
                cmbState_old.Visible = false;
                clazcities.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;
                DataSet ds = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_locanto");
                cmbState.DataSource = ds;
                cmbState.DisplayMember = "Table.State_Code";
                cmbState.ValueMember = "Table.State_Id";
                //if (ds.Tables[0].Rows.Count > 0)
                //cmbState.Text = ds.Tables[0].Rows[0]["State_Code"].ToString();
                //else cmbState.Text = "";
            }
            if (cmbSites.SelectedItem.ToString() == "claz")
            {
                Form1.ActiveForm.Text = "claz";
                DataSet ds = objDal.GET_STATES_Craiglistcars("USP_GET_CITIES_claz");
                clazcities.DataSource = ds;
                clazcities.DisplayMember = "Table.CityName";
                clazcities.ValueMember = "Table.CityId";
                cmbState.Visible = false;
                cmbState_old.Visible = false;
                clazcities.Visible = true;
                comboBox1.Visible = false;
                textBox1.Visible = false;
            }
        }
        private void btn_End_Click(object sender, EventArgs e)
        {
            if (cmbSites.SelectedItem.ToString() == "ebay")
            {
                stopebay = false;
            }
            else if (cmbSites.SelectedItem.ToString() == "backpage")
            {
                stopbackpage = false;
            }
            else if (cmbSites.SelectedItem.ToString() == "claz")
            {
                stopclaz = false;
            }
            else if (cmbSites.SelectedItem.ToString() == "locanto")
            {
                stoplocanto = false;
            }
            else if (cmbSites.SelectedItem.ToString() == "oodle")
            {
                stopoodle = false;
            }
            Application.Exit();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmbSites.SelectedItem.ToString() == "oodle")
            {
                #region oodle
                DataSet dsStated = new DataSet();
                dsStated = objDal.Get_Categories("usp_getCategories");
                if (stopoodle)
                {
                    for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                    {
                        if (stopoodle)
                        {
                            DataSet dsStatesAfter = new DataSet();
                            dsStatesAfter = objDal.Get_Categories("usp_getCategories");
                            DataView dv = dsStatesAfter.Tables[0].DefaultView;
                            dv.RowFilter = "Category= '" + dsStated.Tables[0].Rows[i]["Category"].ToString() + "'";
                            DataTable dt = dv.ToTable();
                            if (dt.Rows.Count == 0)
                            { continue; }

                            if (dsStated.Tables[0].Rows.Count > 0)
                            {

                                if (stopoodle)
                                {
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["Category"].ToString(), "1", "0", "usp_save_tran_oodle");
                                    cmbState_old.Text = dsStated.Tables[0].Rows[i]["Category"].ToString();
                                    GetLeadsForOodle(dsStated.Tables[0].Rows[i]["Category"].ToString());
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["Category"].ToString(), "1", "1", "usp_save_tran_oodle");
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                #endregion
            }
            else if (cmbSites.SelectedItem.ToString() == "global")
            {
                GetLeadsForGlobal();
            }
            else if (cmbSites.SelectedItem.ToString() == "locanto")
            {
                #region locanto
                DataSet dsStated = new DataSet();
                dsStated = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_locanto");
                if (stopebay)
                {
                    for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                    {
                        if (stopebay)
                        {
                            DataSet dsStatesAfter = new DataSet();
                            dsStatesAfter = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_locanto");
                            DataView dv = dsStatesAfter.Tables[0].DefaultView;
                            dv.RowFilter = "State_Code= '" + dsStated.Tables[0].Rows[i]["State_Code"].ToString() + "'";
                            DataTable dt = dv.ToTable();
                            if (dt.Rows.Count == 0)
                            { continue; }

                            if (dsStated.Tables[0].Rows.Count > 0)
                            {

                                if (stopebay)
                                {
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Code"].ToString(), "1", "0", "usp_save_tran_locanto");
                                    cmbState.Text = dsStated.Tables[0].Rows[i]["State_Code"].ToString();
                                    GetLeadsForLocanto(dsStated.Tables[0].Rows[i]["State_Code"].ToString());
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Code"].ToString(), "1", "1", "usp_save_tran_locanto");
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                #endregion
            }
            else if (cmbSites.SelectedItem.ToString() == "ebay")
            {
                #region ebay
                DataSet dsStated = new DataSet();
                dsStated = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_ebay");
                if (stopebay)
                {
                    for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                    {
                        if (stopebay)
                        {
                            DataSet dsStatesAfter = new DataSet();
                            dsStatesAfter = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_ebay");
                            DataView dv = dsStatesAfter.Tables[0].DefaultView;
                            dv.RowFilter = "State_Name= '" + dsStated.Tables[0].Rows[i]["State_Name"].ToString()+"'";
                            DataTable dt = dv.ToTable();
                            if (dt.Rows.Count == 0)
                            { continue; }

                            if (dsStated.Tables[0].Rows.Count > 0)
                            {

                                if (stopebay)
                                {
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Name"].ToString(), "1", "0","usp_save_tran_ebay");
                                    Ebayclassifieds(dsStated.Tables[0].Rows[i]["State_name"].ToString());
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Name"].ToString(), "1", "1","usp_save_tran_ebay");
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                #endregion
            }        
            else if (cmbSites.SelectedItem.ToString() == "backpage")
            {
                #region backpage
                DataSet dsStated = new DataSet();
                dsStated = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_backpage");
                if (stopebay)
                {
                    for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                    {
                        if (stopbackpage)
                        {
                            DataSet dsStatesAfter = new DataSet();
                            dsStatesAfter = objDal.GET_STATES_Craiglistcars("USP_GET_STATES_backpage");
                            DataView dv = dsStatesAfter.Tables[0].DefaultView;
                            dv.RowFilter = "State_Name= '" + dsStated.Tables[0].Rows[i]["State_Name"].ToString() + "'";
                            DataTable dt = dv.ToTable();
                            if (dt.Rows.Count == 0)
                            { continue; }

                            if (dsStated.Tables[0].Rows.Count > 0)
                            {

                                if (stopbackpage)
                                {
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Name"].ToString(), "1", "0", "usp_save_tran_backpage");
                                    BackPage(dsStated.Tables[0].Rows[i]["State_name"].ToString());
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["State_Name"].ToString(), "1", "1", "usp_save_tran_backpage");
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                #endregion
            }
            else if (cmbSites.SelectedItem.ToString() == "claz")
            {
                #region claz
                DataSet dsStated = new DataSet();
                dsStated = objDal.GET_STATES_Craiglistcars("USP_GET_CITIES_claz");
                if (stopclaz)
                {
                    for (int i = 0; i < dsStated.Tables[0].Rows.Count; i++)
                    {
                        if (stopclaz)
                        {
                            DataSet dsStatesAfter = new DataSet();
                            dsStatesAfter = objDal.GET_STATES_Craiglistcars("USP_GET_CITIES_claz");
                            DataView dv = dsStatesAfter.Tables[0].DefaultView;
                            dv.RowFilter = "CityName= '" + dsStated.Tables[0].Rows[i]["CityName"].ToString() + "'";
                            DataTable dt = dv.ToTable();
                            if (dt.Rows.Count == 0)
                            { continue; }

                            if (dsStated.Tables[0].Rows.Count > 0)
                            {

                                if (stopclaz)
                                {
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["CityName"].ToString(), "1", "0", "usp_save_tran_claz");
                                    clazcities.Text = dsStated.Tables[0].Rows[i]["CityName"].ToString();
                                    Claz(dsStated.Tables[0].Rows[i]["CityName"].ToString());
                                    objDal.SaveTransaction_Cars(dsStated.Tables[0].Rows[i]["CityName"].ToString(), "1", "1", "usp_save_tran_claz");
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                #endregion
            }
        }

        private void Del_History_Click(object sender, EventArgs e)
        {
            if (cmbSites.SelectedIndex == -1)
                MessageBox.Show("Select Website for deleting Transaction History");
            else
            {
                var confirmResult = MessageBox.Show("Do you want to delete transaction history ?", "Confirm Delete!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (cmbSites.SelectedItem.ToString() == "ebay")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_ebay");
                    }
                    else if (cmbSites.SelectedItem.ToString() == "backpage")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_backpage");
                    }
                    else if (cmbSites.SelectedItem.ToString() == "locanto")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_locanto");
                    }
                    else if (cmbSites.SelectedItem.ToString() == "oodle")
                    {
                        objDal.del_history("delete from dbo.tbl_transaction_oodle");
                    }

                }
                else if (confirmResult == DialogResult.No)
                {
                    MessageBox.Show("History not deleted");
                }
            }
        }
    }
}