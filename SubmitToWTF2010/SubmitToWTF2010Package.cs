using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;

namespace SubmitToWTF
{
    /// <summary>
    /// Submit to TDTWF package.
    /// </summary>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid("e5516360-5f78-4b7f-af60-48826ef72f1d")]
    [ProvideAutoLoad("ADFC4E64-0397-11D1-9F4E-00A0C911004F")]
    public sealed class SubmitToWTF2010Package : Package
    {
        private DTE2 dte;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitToWTF2010Package"/> class.
        /// </summary>
        public SubmitToWTF2010Package()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.dte = (DTE2)GetService(typeof(DTE));

            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (mcs != null)
            {
                var menuCommandID = new CommandID(new Guid("4a4357f1-e92d-4b08-87d9-71dd35f685c0"), (int)PkgCmdIDList.SubmitWTF);
                var menuItem = new OleMenuCommand((s, e) => Submit(this.dte), menuCommandID);

                menuItem.BeforeQueryStatus += menuItem_BeforeQueryStatus;
                mcs.AddCommand(menuItem);
            }
        }

        private void menuItem_BeforeQueryStatus(object sender, EventArgs e)
        {
            bool visible = false;

            var doc = this.dte.ActiveDocument;
            if (doc != null)
            {
                var selection = (TextSelection)doc.Selection;
                if (selection != null && !string.IsNullOrEmpty(selection.Text))
                    visible = true;
            }

            var menuCommand = (OleMenuCommand)sender;
            menuCommand.Visible = visible;
        }

        /// <summary>
        /// Displays the CodeSOD submit UI.
        /// </summary>
        private void Submit(DTE2 dte)
        {
            using (var form = new SubmitForm())
            {
                var doc = dte.ActiveDocument;
                if (doc != null)
                {
                    var selection = (TextSelection)doc.Selection;
                    if (selection != null)
                        form.CodeSnippet = Util.RemoveTabs(selection.Text, Util.GetTabSize(dte, doc));
                }

                form.ShowDialog();
            }
        }
    }
}
