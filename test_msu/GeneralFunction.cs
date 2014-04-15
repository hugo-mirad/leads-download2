using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoFillForm
{
    public static class GeneralFunction
    {
        public static void SetDropDownValue(WebBrowser objbrowser, string ControlName, string ControlOuterText)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("select"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        for (int i = 0; i < element.Children.Count; i++)
                        {
                            if (element.Children[i].OuterText == ControlOuterText)
                            {
                                //element.Children[i].SetAttribute("selected", "selected");
                                element.GetElementsByTagName("option")[i].SetAttribute("selected", "selected");
                                element.InvokeMember("onchange");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void geturl(WebBrowser objbrowser)
        {
            foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
            {
                if (element.GetAttribute("value") == "View / Edit")
                {
                    // foreach (HtmlElement el in element.Document.GetElementsByTagName("body"))
                    //{
                    if (element.GetAttribute("name") == "view")
                    {
                        //element.OuterHtml = "<INPUT" + " for testing" + "</p>";
                        if (element.OuterHtml.Contains("/members/adverts_delete"))
                        { }
                        //<INPUT class=inputstyle1 style="WIDTH: 60px" onclick="changeaction('/members/adverts_delete.php','827725610')" type=button alt=Delete value=Delete name=delete>
                    }
                    // }
                }
            }
        }
        public static void SetDropDownNameandValue(WebBrowser objbrowser, string ControlName, string Controlvalue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("select"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        element.SetAttribute("value", Controlvalue);
                        objbrowser.Document.InvokeScript("click");
                        element.RaiseEvent("onChange");
                        //element.InvokeMember("onchange");
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetDropDownName(WebBrowser objbrowser, string ControlName, string ControlOuterText)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("select"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        for (int i = 0; i < element.Children.Count; i++)
                        {
                            if (element.Children[i].OuterText == ControlOuterText)
                            {
                                element.Children[i].SetAttribute("selected", "selected");
                                objbrowser.Document.InvokeScript("click");
                                element.RaiseEvent("onChange");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetTextValue(WebBrowser objbrowser, string ControlName, string ControlInnerText)
        {
            try
            {
                objbrowser.Document.GetElementById(ControlName).InnerText = ControlInnerText;
            }
            catch (Exception ex)
            { }
        }
        public static void SetTextValueFocus(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                objbrowser.Document.GetElementById(ControlName).InvokeMember("focus");
            }
            catch (Exception ex)
            { }
        }
        public static void SetMultiTextValue(WebBrowser objbrowser, string ControlName, string ControlInnerText)
        {
            var a = "";
            try
            {
                //foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("textarea"))
                //{
                //    a = element.Name;
                //    element.InnerText = "Hello";

                objbrowser.Document.GetElementsByTagName("textarea").GetElementsByName(ControlName)[0].InnerText = ControlInnerText;
                //}
            }
            catch (Exception ex)
            { }
        }
        public static void SetMultiTextName(WebBrowser objbrowser, string ControlName, string ControlInnerText)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("textarea"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        element.InnerText = ControlInnerText;
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetTextvaluebyName(WebBrowser objbrowser, string ControlName, string ControlInnerText)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        element.InnerText = ControlInnerText;
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickInvoke(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("name") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickBYTypeAndValue(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("value") == ControlValue)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickBody(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("button"))
                {
                    if (element.GetAttribute("type") == ControlName)
                    //if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            {
            }
        }
        public static void ButtonClickBody1(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == ControlName)
                    //if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            { }
        }
        public static void ButtonClickInvokeInnerText(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.InnerText == InnerTxt)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void ImgeButtonClickInvoke(WebBrowser objbrowser, string ControlTitle)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("img"))
                {
                    //for (int i = 0; i < element.Children.Count; i++)
                    // {
                    if (element.GetAttribute("title") == ControlTitle)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                    //}
                }
            }
            catch (Exception ex)
            { }
        }
        public static void ImgeButtonimageInvoke(WebBrowser objbrowser, string ControlTitle)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("img"))
                {
                    //for (int i = 0; i < element.Children.Count; i++)
                    // {
                    if ((element.GetAttribute("Src") == ControlTitle) || (element.GetAttribute("src") == ControlTitle))
                    {
                        element.InvokeMember("click");
                        return;
                    }
                    //}
                }
            }
            catch (Exception ex)
            { }
        }
        public static void HfClickInvoke(WebBrowser objbrowser, string ControlTitle)
        {
            try
            {
                HtmlElementCollection links = objbrowser.Document.GetElementsByTagName("A");
                foreach (HtmlElement link in links)  // this ex is given another SO post 
                {
                    if (link.InnerHtml.Equals("<IMG height=20 alt=\"\" src=\"/images/btn-logout.gif\" width=94 border=0>"))
                        link.InvokeMember("Click");
                }
                //foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                // {
                // foreach (HtmlElement element1 in objbrowser.Document.GetElementsByTagName("img"))
                // {

                // if (element1.GetAttribute("src") == ControlTitle)
                // {
                //  element1.InvokeMember("click");
                //    return;
                // }


                // }
                // }
            }
            catch (Exception ex)
            { }
        }
        public static void ImgeButtonClickInvokeTypeandName(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == "image" && element.GetAttribute("name") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void ImgeButtonClickInvokeTypeandValue(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == "image" && element.GetAttribute("value") == ControlValue)
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickInvokeValue(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("value").Trim() == ControlValue.Trim())
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickInvokeValueJustgoods(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {

                    if (element.GetAttribute("value") == ControlValue)
                    {
                        for (int i = 0; i < element.Children.Count; i++)
                        {
                            element.InvokeMember("click");
                            return;
                        }
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void Submit(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("value") == ControlValue)
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }

        }
        public static void ButtonClickType(WebBrowser objbrowser, string ControlClass)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type").Trim() == "button" && element.GetAttribute("classname").Trim() == ControlClass)
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void ButtonClickByValue(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("value") == ControlValue)
                    {
                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void CheckedInvoke(WebBrowser objbrowser, string ControlName)
        {
            try
            {

                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("name") == ControlName && element.GetAttribute("type").Equals("checkbox"))
                    {

                        element.SetAttribute("checked", "true");

                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void RadioSetValue(WebBrowser objbrowser, string ControlName, string ControlValue)
        {
            try
            {

                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    // if (element.GetAttribute("name") == ControlName && element.GetAttribute("type").Equals("radio") && element .GetAttribute ("value")==ControlValue )
                    if (element.GetAttribute("name") == ControlName && element.GetAttribute("value") == ControlValue)
                    {

                        element.SetAttribute("checked", "true");

                        element.InvokeMember("Click");

                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void RadioSetOnlyValue(WebBrowser objbrowser, string ControlName, string ControlValue)
        {
            foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
            {
                if (element.GetAttribute("value") == ControlValue)
                {

                    element.SetAttribute("checked", "true");

                    return;
                }
            }
        }
        public static void LinkInvoke(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.InnerText != null)
                    {
                        if (element.InnerText == "Terms of Use")
                        {
                        }
                        if (element.InnerText.Trim() == InnerTxt.Trim())
                        {

                            element.InvokeMember("click");
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeClsads(WebBrowser objbrowser, string InnerTxt, string InnerTxtnew)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    //if (element.InnerText == "Wanted")
                    //{
                    //}
                    if ((element.InnerText == InnerTxt) || (element.InnerText == InnerTxtnew))
                    {

                        element.InvokeMember("click");
                        return;
                    }

                }

            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeContains(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    string stnm = element.InnerText;
                    if (stnm != null)
                    {


                        if (InnerTxt.Contains(stnm))
                        {

                            element.InvokeMember("click");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeOnMouseOver(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.InnerText.Trim() == InnerTxt)
                    {

                        element.InvokeMember("onmouseover");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetDivValuebyClass(WebBrowser objbrowser, string ControlClass, string ControlInnerHtml)
        {
            try
            {

                HtmlDocument doc = objbrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("div");
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute("classname").Trim() == ControlClass)
                    {

                        element.InnerHtml = "<P align=center>" + ControlInnerHtml + "<BR></P>";


                    }
                }

            }
            catch (Exception ex)
            { }

        }
        public static void SetBodyValuebyClass(WebBrowser objbrowser, string ControlClass, string ControlInnerHtml)
        {
            try
            {

                //  HtmlElement iframe = objbrowser.Document.GetElementById("tinymce");
                //iframe.GetElementById("file_upload_input").SetAttribute("value", "myfile.txt");


                HtmlDocument doc = objbrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("body");
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute("classname").Trim() == ControlClass)
                    {

                        element.InnerHtml = "<p>" + ControlInnerHtml + "</p>";


                    }
                }

            }
            catch (Exception ex)
            { }

        }
        public static void SetValueForLiteral(WebBrowser objbrowser, string ControlID, string ControlInnerText)
        {
            try
            {

                HtmlDocument doc = objbrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("UL");
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute("Id").Trim() == ControlID)
                    {

                        foreach (HtmlElement element1 in element.Children)
                        {
                            if (element1.InnerText.Contains(ControlInnerText))
                            {

                                element1.SetAttribute("class", "selected");
                                element1.InvokeMember("selected");

                                element1.InvokeMember("click");
                                return;
                            }

                        }

                    }
                }

            }
            catch (Exception ex)
            { }

        }
        public static void FileUploadInvoke(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                int pc = 0;

                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("name") == ControlName && element.GetAttribute("type").Equals("file"))
                    {
                        if (pc < 3)
                        {
                            element.InvokeMember("click");
                            pc++;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void FileUploadInvokeanunico(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                int pc = 0;

                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("name") == ControlName && element.GetAttribute("type").Equals("file"))
                    {
                        if (pc < 3)
                        {


                            element.InvokeMember("click");
                            pc++;

                        }




                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetDropDownID(WebBrowser objbrowser, string ControlId, string ControlOuterText)
        {

            try
            {

                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("select"))
                {


                    if (element.GetAttribute("id").Trim() == ControlId)
                    {

                        for (int i = 2; i < element.Children.Count; i++)
                        {

                            if (element.Children[i].OuterText.Trim() == ControlOuterText)
                            {

                                element.Children[i].SetAttribute("selected", "selected");
                                element.InvokeMember("onchange");
                                element.Document.InvokeScript("click");

                                return;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetClassValue(WebBrowser objbrowser, string controlName, string Controlvalue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == controlName)
                    {
                        element.InnerText = Controlvalue;
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }

        }
        public static void ButtonClick(WebBrowser objbrowser, string ControlType)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == ControlType)
                    //if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            {
            }
        }
        public static void ButtonClickByName(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    //if (element.GetAttribute("name") == ControlName)
                    if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            {
            }
        }
        public static void LinkInvokeDiv(WebBrowser objbrowser, string ControlName, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("div"))
                {
                    if (element.GetAttribute("classname") == ControlName)
                    {
                        if (element.InnerText == InnerTxt)
                        {


                            element.InvokeMember("click");
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeFBInnerDiv(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("div"))
                {

                    if (element.InnerText == InnerTxt)
                    {


                        element.InvokeMember("click");
                        return;
                    }

                }

            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeFBDiv(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("div"))
                {
                    if (element.GetAttribute("classname") == ControlName)
                    {



                        element.InvokeMember("click");
                        return;

                    }
                }

            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeClassifiedValley(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.InnerText == InnerTxt)
                    {


                        element.InvokeMember("click");
                        return;

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokehf(WebBrowser objbrowser)
        {
            try
            {
                //foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("span"))
                //   {

                //if (element.GetAttribute("class") == ControlName)
                //{

                HtmlElementCollection links = objbrowser.Document.GetElementsByTagName("a");

                foreach (HtmlElement link in links)
                {
                    if (link.InnerText.Contains("car"))
                    {


                        link.InvokeMember("Click");
                    }
                }


                //  }
                //}


                ////foreach (HtmlElementCollection link in objbrowser.Document.GetElementsByTagName("a"))
                ////{


                ////   // //if (element.InnerText == InnerTxt)
                // if (link.Contains("Place"))
                // // if (element.GetAttribute("href") == ControlName)
                //// if (element.GetAttribute("class") == ControlName)
                // {

                //     link.InvokeMember("click");
                //     return;
            }
            //  }



            catch (Exception ex)
            { }
        }
        public static void LinkInvokeFB(WebBrowser objbrowser, string ControlName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("span"))
                {

                    if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("Click");

                    }
                }







            }
            //  }



            catch (Exception ex)
            { }
        }
        public static void SpanInnerText(WebBrowser objbrowser, string InnerText)
        {
            try
            {

                HtmlElementCollection spantags = objbrowser.Document.GetElementsByTagName("span");

                foreach (HtmlElement span in spantags)
                {
                    if (span.InnerText == InnerText)
                    {


                        span.InvokeMember("Click");
                    }
                }


                //  }
                //}


                ////foreach (HtmlElementCollection link in objbrowser.Document.GetElementsByTagName("a"))
                ////{


                ////   // //if (element.InnerText == InnerTxt)
                // if (link.Contains("Place"))
                // // if (element.GetAttribute("href") == ControlName)
                //// if (element.GetAttribute("class") == ControlName)
                // {

                //     link.InvokeMember("click");
                //     return;
            }
            //  }



            catch (Exception ex)
            { }
        }
        public static void LinkInvokepic(WebBrowser objbrowser)
        {
            try
            {


                HtmlElementCollection links = objbrowser.Document.GetElementsByTagName("a");

                foreach (HtmlElement link in links)
                {
                    if (link.InnerText.Contains("Proceed to upload my photos"))
                    {


                        link.InvokeMember("Click");
                    }
                }



            }




            catch (Exception ex)
            { }
        }
        public static void Linkhref(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.GetAttribute("href") == ControlValue)
                    {
                        // if (element.InnerText == InnerTxt)
                        // {


                        element.InvokeMember("click");
                        return;
                        //  }
                    }
                }

            }
            catch (Exception ex)
            { }

        }
        public static void LinkInvokeCollectorCarsPic(WebBrowser objbrowser)
        {
            try
            {


                HtmlElementCollection links = objbrowser.Document.GetElementsByTagName("a");

                foreach (HtmlElement link in links)
                {
                    if (link.InnerText.Contains("1"))
                    {


                        link.InvokeMember("Click");
                    }
                }



            }




            catch (Exception ex)
            { }
        }
        public static void LinkInvokeMotoSeller(WebBrowser objbrowser, string ClassName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.GetAttribute("classname") == ClassName)
                    {
                        if (element.InnerText.Contains("Autos"))
                        {

                            element.InvokeMember("click");
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokepintrest(WebBrowser objbrowser, string ClassName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.GetAttribute("classname") == ClassName)
                    {


                        element.InvokeMember("click");
                        return;


                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeContainsMotoSeller(WebBrowser objbrowser, string ClassName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    //if (element.InnerText == InnerText) 
                    //if (element.InnerText.Contains("Place"))
                    if (element.GetAttribute("classname") == ClassName)
                    {
                        if (element.InnerText.Contains("Cars"))
                        {

                            element.InvokeMember("click");
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeMotoSellerStateName(WebBrowser objbrowser, string ClassName, string StateName)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    //if (element.InnerText == InnerText) 
                    //if (element.InnerText.Contains("Place"))
                    if (element.GetAttribute("classname") == ClassName)
                    {
                        if (element.InnerText.Contains(StateName))
                        {

                            element.InvokeMember("click");
                            return;
                        }

                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void LinkInvokeByValue(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("value").Trim() == ControlValue)
                    {

                        element.InvokeMember("click");
                        return;
                    }

                }
            }
            catch (Exception ex)
            { }
        }
        public static void SetDivValuebyInnerText(WebBrowser objbrowser, string ControlClass, string ControlInnerText)
        {
            try
            {

                HtmlDocument doc = objbrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("div");
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute("classname").Trim() == ControlClass)
                    {

                        element.InnerText = ControlInnerText;


                    }
                }


            }
            catch (Exception ex)
            { }

        }
        public static void SetDivValuebyclass(WebBrowser objbrowser, string ControlClass)
        {
            try
            {

                HtmlDocument doc = objbrowser.Document;
                HtmlElementCollection col = doc.GetElementsByTagName("div");
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute("id").Trim() == ControlClass)
                    {
                        element.InvokeMember("click");
                        return;



                    }
                }


            }
            catch (Exception ex)
            { }

        }
        public static void ButtonClickBody2(WebBrowser objbrowser, string innerText)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("button"))
                {
                    if (element.InnerText == innerText)
                    //if (element.GetAttribute("classname") == ControlName)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        #region tumblr
        public static void LinkhrefForTumbler(WebBrowser objbrowser, string ControlValue)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.Id == ControlValue)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }

            }
            catch (Exception ex)
            { }

        }
        public static void ButtonClicktumblr(WebBrowser objbrowser, string ControlType)
        {

            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("button"))
                {
                    if (element.GetAttribute("type") == ControlType && element.Id == "save_button")
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch
            {
            }
        }
        public static void ButtonClickspan(WebBrowser objbrowser, string text)
        {
            var a = "";
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("span"))
                {
                    //a = element.GetAttribute("class");
                    //if (element.InnerText == text)
                    //{
                    if (element.InnerText == "Create a board")
                    {
                        element.InvokeMember("click");
                        return;
                    }
                    //}
                }
            }
            catch
            {
            }
        }
        #endregion

        #region cargurus
        public static void ButtonClick(WebBrowser objBrowser, string type, string id)
        {
            try
            {
                foreach (HtmlElement element in objBrowser.Document.GetElementsByTagName("input"))
                {
                    if (element.GetAttribute("type") == type && element.Id == id)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public static void spanLinkInvoke(WebBrowser objBrowser, String title)
        {
            foreach (HtmlElement element in objBrowser.Document.GetElementsByTagName("span"))
            {
                if (element.GetAttribute("title") == title)
                {
                    element.InvokeMember("click");
                    return;
                }
            }
        }
        public static void spanLinkInvoke1(WebBrowser objBrowser, String innerText)
        {
            foreach (HtmlElement element in objBrowser.Document.GetElementsByTagName("span"))
            {
                if (element.InnerText != null)
                {
                    if (element.InnerText.Trim() == innerText)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
        }
        public static void ButtonClickInvokeInnerText1(WebBrowser objbrowser, string InnerTxt)
        {
            try
            {
                foreach (HtmlElement element in objbrowser.Document.GetElementsByTagName("a"))
                {
                    if (element.InnerText == InnerTxt)
                    {
                        element.InvokeMember("click");
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
      
        #endregion
       
        
    }
}
