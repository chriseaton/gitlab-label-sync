using System;

namespace GLS.Command {

    public class HelpAction : ICommandAction {

        #region " Properties "

        public GLSAction Action { get { return GLSAction.Help; } }

        #endregion

        #region " Constructor(s) "

        public HelpAction() { }

        #endregion

        #region " Methods "

        public bool Run() {
            Console.WriteLine("{0}, v{1}", ProductInfo.GetTitle(), ProductInfo.GetVersion());
            Console.WriteLine("© {0}", ProductInfo.GetCopyright());
            Console.WriteLine("https://github.com/chriseaton/gitlab-label-sync");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("This small CLI utility makes it easy to synchronize and manage labels in GitLab. Using the \"gls\" command you can list, create, change, merge, copy, and remove labels between the admin labels, group labels, and project labels.");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  gls {action} {arguments...}");
            Console.WriteLine();
            Console.WriteLine("Actions       Aliases      Arguments");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  alter        add, touch    {admin|project|group}={project|group id/path}  ...");
            Console.WriteLine("                              {id|name} name=\"{name}\"                       ...");
            Console.WriteLine("                              description=\"{description}\" color=\"{hex color}\"");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  copy         cp           {admin|project|group}={project|group id|path}   ...");
            Console.WriteLine("                             {admin|project|group}={project|group id|path} ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  create       add          {admin|project|group}={project|group id/path}   ...");
            Console.WriteLine("                              name=\"{name}\" description=\"{description}\"     ...");
            Console.WriteLine("                              color=\"{hex color}\"");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  list         ls           {admin|project|group}={project|group id|path}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  merge                     {admin|project|group}={project|group id|path}   ...");
            Console.WriteLine("                              {admin|project|group}={project|group id|path} ...");
            Console.WriteLine("                              {--recursive}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  register     reg          {gitlab url} {token} {--save}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("  remove       rm           {admin|project|group}={project|group id|path}   ...");
            Console.WriteLine("                              {id|name} {--recursive}");
            Console.WriteLine("-----------------------------------------------");
            return true;
        }

        #endregion

    }

}