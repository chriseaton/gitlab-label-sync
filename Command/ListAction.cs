using System;

namespace GLS.Command {

    public class ListAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.List; } }

        #endregion

        #region " Constructor(s) "

        public ListAction() { }

        #endregion

        #region " Methods "

        public bool Run() {
            //TODO
            return true;
        }

        #endregion

    }

}