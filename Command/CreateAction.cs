using System;

namespace GLS.Command {

    public class CreateAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Create; } }

        #endregion

        #region " Constructor(s) "

        public CreateAction() { }

        #endregion

        #region " Methods "

        public bool Run() {
            //TODO
            return true;
        }

        #endregion

    }

}