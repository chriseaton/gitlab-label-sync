using System;

namespace GLS.Command {

    public class MergeAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Merge; } }

        #endregion

        #region " Constructor(s) "

        public MergeAction() { }

        #endregion

        #region " Methods "

        public bool Run() {
            //TODO
            return true;
        }

        #endregion

    }

}