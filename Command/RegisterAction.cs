using System;

namespace GLS.Command {

    public class RegisterAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Register; } }

        public string URL { get; protected set; }

        public string Token { get; protected set; }

        public bool Save { get; protected set; }

        #endregion

        #region " Constructor(s) "

        public RegisterAction() { }

        public RegisterAction(string url, string token, bool save) {
            this.URL = url;
            this.Token = token;
            this.Save = save;
        }

        #endregion

        #region " Methods "

        public bool Run() {
            //TODO
            return true;
        }

        #endregion

    }

}