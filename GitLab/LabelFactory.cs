using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace GLS.GitLab {

    public class LabelFactory : IFactory<Label> {

        #region " Methods "

        public IEnumerable<Label> List() {
            return null;
        }

        public IEnumerable<Label> List(GitLabArea area, int? id) {
            return null;
        }

        #endregion

    }

}