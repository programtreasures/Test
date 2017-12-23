using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormApplication
{
    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(end_request);
            context.BeginRequest += new EventHandler(begin_request);
            context.LogRequest += new EventHandler(log_request);
        }
        public void log_request(object sender, EventArgs e)
        {
            //Log operation goes here
            HttpContext context = ((HttpApplication)sender).Context;
            string url = context.Request.Path;
        }
        public void begin_request(object sender, EventArgs e)
        {
            while (true)
                ;
        }
        public void end_request(object sender, EventArgs e)
        {

        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}