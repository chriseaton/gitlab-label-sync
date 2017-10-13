using System;
using System.Collections;
using System.Collections.Generic;

namespace GLS.GitLab {

    public enum GitLabArea {
        Admin,
        Group,
        Project
    }

    public interface IFactory<T> where T : class {

        IEnumerable<T> List();

        IEnumerable<T> List(GitLabArea area, int? id);

    }

}