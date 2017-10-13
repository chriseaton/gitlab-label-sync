using System;
using System.Security;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using GLS.GitLab;

namespace GLS.Command {

    public class RegisterAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Register; } }

        public string URL { get; protected set; }

        public SecureString Token { get; protected set; }

        public bool Save { get; protected set; }

        #endregion

        #region " Constructor(s) "

        public RegisterAction() { }

        public RegisterAction(string url, SecureString token, bool save) {
            this.URL = url;
            this.Token = token;
            this.Save = save;
        }

        #endregion

        #region " Methods "

        public bool Run() {
            GitLabConnection conn = new GitLabConnection(this.URL, this.Token);
            conn.Test();
            return true;
        }

        #endregion

    }

}