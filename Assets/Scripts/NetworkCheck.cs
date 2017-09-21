﻿using UnityEngine;
using System.Collections;
using System.Net;
using System;
using System.IO;

public class NetworkCheck : MonoBehaviour
{
    public bool hasInternet = false;
    private IEnumerator coroutine;
    public string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {

                    using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }
    void Start()
    {
        checkInternet();
        coroutine = WaitAndUpdate(60f);
        StartCoroutine(coroutine);

    }

    private IEnumerator WaitAndUpdate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            checkInternet();
        }
    }

    public void checkInternet(){

        string HtmlText1 = GetHtmlFromUri("http://www.google.com");
        string HtmlText2 = GetHtmlFromUri("http://www.baidu.com/");
        if (HtmlText1 == "" && HtmlText2 == "")
        {
            //No connection
            Debug.Log("Connection Not Found");
            hasInternet = false;
        }
        else if (!HtmlText1.Contains("schema.org/WebPage"))
        {
            //Redirecting since the beginning of googles html contains that 
            //phrase and it was not found
        }
        else
        {
            //success
            Debug.Log("Connection Found");
            hasInternet = true;
        }
    }
}