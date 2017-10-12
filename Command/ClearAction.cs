using System;

namespace GLS.Command {

    public class ClearAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Clear; } }

        #endregion

        #region " Constructor(s) "

        public ClearAction() {}

        #endregion

    }

}