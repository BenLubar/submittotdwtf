using System;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using Microsoft.VisualStudio.CommandBars;

namespace SubmitToWTF
{
    /// <summary>
    /// The Visual Studio add-in object.
    /// </summary>
	[CLSCompliant(false)]
    public sealed class Connect : IDTExtensibility2, IDTCommandTarget
	{
        private DTE2 _applicationObject;
        private AddIn _addInInstance;
        private CommandBarButton submitButton;

        /// <summary>
        /// Initializes a new instance of the <see cref="Connect"/> class.
        /// </summary>
		public Connect()
		{
		}

		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;

            var commandBars = (CommandBars)_applicationObject.CommandBars;
            var ctxMenu = commandBars["Code Window"];

            submitButton = (CommandBarButton)ctxMenu.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            submitButton.Caption = "Submit as WTF...";
            submitButton.Click += submitButton_Click;
        }
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}
		public void OnAddInsUpdate(ref Array custom)
		{
		}
		public void OnStartupComplete(ref Array custom)
		{
		}
		public void OnBeginShutdown(ref Array custom)
		{
		}
        /// <summary>
        /// Execs the specified CMD name.
        /// </summary>
        /// <param name="CmdName">Name of the CMD.</param>
        /// <param name="ExecuteOption">The execute option.</param>
        /// <param name="VariantIn">The variant in.</param>
        /// <param name="VariantOut">The variant out.</param>
        /// <param name="Handled">if set to <c>true</c> [handled].</param>
        public void Exec(string CmdName, vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled)
        {
            if (CmdName == _addInInstance.ProgID + ".SubmitWTF")
                Submit();
        }
        /// <summary>
        /// Queries the status.
        /// </summary>
        /// <param name="CmdName">Name of the CMD.</param>
        /// <param name="NeededText">The needed text.</param>
        /// <param name="StatusOption">The status option.</param>
        /// <param name="CommandText">The command text.</param>
        public void QueryStatus(string CmdName, vsCommandStatusTextWanted NeededText, ref vsCommandStatus StatusOption, ref object CommandText)
        {
            if (CmdName == _addInInstance.ProgID + ".SubmitWTF")
            {
                vsCommandStatus status = vsCommandStatus.vsCommandStatusInvisible;

                var doc = _applicationObject.ActiveDocument;
                if (doc != null)
                {
                    var selection = (TextSelection)doc.Selection;
                    if (selection != null && !string.IsNullOrEmpty(selection.Text))
                        status = vsCommandStatus.vsCommandStatusEnabled;
                }

                StatusOption = status;
                if(submitButton != null)
                    submitButton.Enabled = (status & vsCommandStatus.vsCommandStatusEnabled) != 0;
            }
        }

        /// <summary>
        /// Displays the CodeSOD submit UI.
        /// </summary>
        private void Submit()
        {
            using (var form = new SubmitForm())
            {
                var doc = _applicationObject.ActiveDocument;
                if (doc != null)
                {
                    var selection = (TextSelection)doc.Selection;
                    if (selection != null)
                        form.CodeSnippet = Util.RemoveTabs(selection.Text, Util.GetTabSize(_applicationObject, doc));
                }

                form.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event on the submit button.
        /// </summary>
        /// <param name="Ctrl">Source of the event.</param>
        /// <param name="CancelDefault">Value indicating whether the default action should be canceled.</param>
        private void submitButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Submit();
        }
    }
}
