using System;
using System.Security;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace GLS.GitLab {

    public class GitLabConnection {

        private string m_URL = null;

        #region " Properties "

        public string URL {
            get { return m_URL; }
            private set {
                m_URL = value;
                if (m_URL != null) {
                    m_URL = m_URL.TrimEnd('/');
                }
            }
        }

        protected SecureString Token { get; private set; }

        #endregion

        #region " Constructor(s) "

        public GitLabConnection(string url, SecureString token) {
            if (url == null) {
                throw new ArgumentNullException("url");
            }
            if (token == null) {
                throw new ArgumentNullException("token");
            }
            this.URL = url;
            this.Token = token;
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Creates an HTTP Client with the proper headers and MIME type to work with the GitLab API.
        /// </summary>
        public HttpClient CreateClient() {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", this.TokenToString());
            return client;
        }

        /// <summary>
        /// Creates a GitLab API URL based on an absolute api path (ex: /api/v4/version)
        /// </summary>
        /// <returns>The GitLab API URL</returns>
        public string CreateURL(string uriAbsPath) {
            if (uriAbsPath.StartsWith('/') == false) {
                uriAbsPath = '/' + uriAbsPath;
            }
            return this.URL + uriAbsPath;
        }

        /// <summary>
        /// Makes a test API call to the GitLab server (calls the "version" endpoint)
        /// </summary>
        /// <returns>Returns true if the test succeeded, false if not.</returns>
        public bool Test() {
            using (var client = this.CreateClient()) {
                string qry = this.CreateURL("/api/v4/version");
                Program.Log.LogDebug("Calling: {0}", qry);
                Task<string> t = client.GetStringAsync(qry);
                try {
                    t.Wait();
                    Program.Log.LogDebug("Result: {0}\n{1}", qry, t.Result);
                    return true;
                } catch (AggregateException ae) {
                    Program.Log.LogError("Unable to connect: {0}", ae.InnerException.Message);
                }
            }
            return false;
        }

        /// <summary>
        /// Converts the SecureString back to a string for use with the HttpClient
        /// </summary>
        /// <returns></returns>
        private string TokenToString() {
            IntPtr bstr = Marshal.SecureStringToBSTR(this.Token);
            try {
                return Marshal.PtrToStringBSTR(bstr);
            } finally {
                Marshal.FreeBSTR(bstr);
            }
        }

        #endregion

    }

}