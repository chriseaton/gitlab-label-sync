using System;

namespace GLS.Command {

    public class CopyAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Copy; } }

        #endregion

        #region " Constructor(s) "

        public CopyAction() { }

        #endregion

        #region " Methods "

        public bool Run() {
            //TODO
            return true;
        }

        #endregion

    }

}