using System;

namespace GLS.Command {

    public class AlterAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Alter; } }

        #endregion

        #region " Constructor(s) "

        public AlterAction() {}

        #endregion

    }

}