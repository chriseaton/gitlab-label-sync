using System;

namespace GLS {

    public enum GLSAction {
        Register,
        List,
        Create,
        Alter,
        Remove,
        Clear,
        Copy,
        Merge
    }

    public interface ICommandAction {

        GLSAction Action { get; }

    }

}