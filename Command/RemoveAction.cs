using System;

namespace GLS.Command {

    public class RemoveAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Remove; } }

        #endregion

        #region " Constructor(s) "

        public RemoveAction() {}

        #endregion

    }

}