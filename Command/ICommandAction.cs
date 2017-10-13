using System;
using System.Text.RegularExpressions;

namespace GLS {

    public enum GLSAction {
        Register,
        List,
        Create,
        Alter,
        Remove,
        Copy,
        Merge,
        Help
    }

    public interface ICommandAction {

        GLSAction Action { get; }

        bool Run();

    }

}