using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GLS {

    public static class ProductInfo {

        /// <summary>
        /// Retrieve the version of an Assembly
        /// </summary>
        public static string GetVersion(Assembly asm = null) {
            string version = GetAssemblyAttributeValue(asm, "System.ReflectionAssemblyVersion");
            if (String.IsNullOrWhiteSpace(version)) {
                version = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyInformationalVersionAttribute");
            }
            if (String.IsNullOrWhiteSpace(version)) {
                version = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyFileVersionAttribute");
            }
            return version;
        }

        /// <summary>
        /// Retrieve the project URL of an Assembly
        /// </summary>
        public static string GetURL(Assembly asm = null) {
            string title = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyTitle");
            if (String.IsNullOrWhiteSpace(title)) {
                title = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyProduct");
            }
            return title;
        }

        /// <summary>
        /// Retrieve the copyright of an Assembly
        /// </summary>
        public static string GetCopyright(Assembly asm = null) {
            return GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyCopyrightAttribute");
        }

        /// <summary>
        /// Retrieve the title of an Assembly
        /// </summary>
        public static string GetTitle(Assembly asm = null) {
            string title = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyProduct");
            if (String.IsNullOrWhiteSpace(title)) {
                title = GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyTitle");
            }
            return title;
        }

        /// <summary>
        /// Retrieve the description of an Assembly
        /// </summary>
        public static string GetDescription(Assembly asm = null) {
            return GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyDescription");
        }

        /// <summary>
        /// Retrieve the company of an Assembly
        /// </summary>
        public static string GetCompany(Assembly asm = null) {
            return GetAssemblyAttributeValue(asm, "System.Reflection.AssemblyCompany");
        }

        /// <summary>
		/// Retrieve the attribute value of an Assembly
		/// </summary>
		private static string GetAssemblyAttributeValue(Assembly asm, string attributeTypeName) {
            if (asm == null) {
                asm = Assembly.GetExecutingAssembly();
            }
            IList<CustomAttributeData> asmAttributes = CustomAttributeData.GetCustomAttributes(asm);
            if (asmAttributes != null && asmAttributes.Count > 0) {
                foreach (CustomAttributeData cad in asmAttributes) {
                    string attrName = cad.ToString();
                    if (cad.ConstructorArguments != null && cad.ConstructorArguments.Count > 0) {
                        if (attrName.Contains(attributeTypeName)) {
                            return (cad.ConstructorArguments[0].Value ?? String.Empty).ToString();
                        }
                    }
                }
            }
            return String.Empty;
        }

    }
}