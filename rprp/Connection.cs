using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace mw
{
	internal class Connection
	{
		private CookieContainer cJar = new CookieContainer();

		private string UserAgent = "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.1667.0 Safari/537.36";

		internal string HttpPost(string uri, string post, bool follow_redirect = true, string refer = "")
		{
			string message;
			bool flag;
			try
			{
				HttpWebRequest userAgent = (HttpWebRequest)WebRequest.Create(new Uri(uri));
				userAgent.CookieContainer = this.cJar;
				userAgent.UserAgent = this.UserAgent;
				userAgent.KeepAlive = false;
				userAgent.Method = "POST";
				userAgent.Referer = refer;
				if (follow_redirect)
				{
					userAgent.AllowAutoRedirect = false;
				}
				byte[] bytes = Encoding.ASCII.GetBytes(post);
				userAgent.ContentType = "application/x-www-form-urlencoded";
				userAgent.ContentLength = (long)((int)bytes.Length);
				Stream requestStream = userAgent.GetRequestStream();
				requestStream.Write(bytes, 0, (int)bytes.Length);
				requestStream.Close();
				HttpWebResponse response = (HttpWebResponse)userAgent.GetResponse();
				if (!follow_redirect)
				{
					flag = true;
				}
				else
				{
					flag = (response.StatusCode == HttpStatusCode.MovedPermanently ? false : response.StatusCode != HttpStatusCode.Found);
				}
				if (!flag)
				{
				}
				string end = (new StreamReader(response.GetResponseStream())).ReadToEnd();
				message = end;
			}
			catch (Exception exception)
			{
				message = exception.Message;
				Console.WriteLine("E HttpPost: " + message);
			}
			return message;
		}

		internal string SimpleHttpGet(string uri)
		{
			string message;
			try
			{
				HttpWebRequest userAgent = (HttpWebRequest)WebRequest.Create(new Uri(uri));
				userAgent.CookieContainer = this.cJar;
				userAgent.UserAgent = this.UserAgent;
				userAgent.KeepAlive = false;
				userAgent.AllowAutoRedirect = false;
				userAgent.Method = "GET";
				string end = (new StreamReader(userAgent.GetResponse().GetResponseStream())).ReadToEnd();
				message = end;
			}
			catch (Exception exception)
			{
				message = exception.Message;
				Console.WriteLine("E SimpleHttpGet: " + message);
			}
			return message;
		}

		public string SimpleHttpPost(string uri, string post)
		{
			string message;
			try
			{
				HttpWebRequest userAgent = (HttpWebRequest)WebRequest.Create(new Uri(uri));
				userAgent.CookieContainer = this.cJar;
				userAgent.UserAgent = this.UserAgent;
				userAgent.KeepAlive = false;
				userAgent.Method = "POST";
				userAgent.Referer = "http://www.mafiaway.nl/";
				byte[] bytes = Encoding.ASCII.GetBytes(post);
				userAgent.ContentType = "application/x-www-form-urlencoded";
				userAgent.ContentLength = (long)((int)bytes.Length);
				Stream requestStream = userAgent.GetRequestStream();
				requestStream.Write(bytes, 0, (int)bytes.Length);
				requestStream.Close();
				string end = (new StreamReader(userAgent.GetResponse().GetResponseStream())).ReadToEnd();
				message = end;
			}
			catch (Exception exception)
			{
				message = exception.Message;
				Console.WriteLine("E SimpleHttpPost: " + message);
			}
			return message;
		}
	}
}