using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SubmitToWTF
{
    /// <summary>
    /// Submission modal dialog.
    /// </summary>
    public sealed partial class SubmitForm : Form
    {
        /// <summary>
        /// The regular expression used for basic email validation.
        /// </summary>
        private static readonly Regex EmailRegex = new Regex(@"^[^@]+@[^.]+\.[^@\s]+$", RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitForm"/> class.
        /// </summary>
        public SubmitForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the code snippet to display.
        /// </summary>
        public string CodeSnippet
        {
            get { return this.txtCode.Text; }
            set { this.txtCode.Text = value; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txtName.Text = Environment.UserName;
        }

        /// <summary>
        /// Determines whether a string could be a valid email address.
        /// </summary>
        /// <param name="s">The string to test.</param>
        /// <returns>True if the string could be a valid email address. This is by no means exhaustive.</returns>
        private static bool IsPossiblyEmailAddress(string s)
        {
            if (Util.IsEmptyOrWhitespace(s))
                return false;

            return EmailRegex.IsMatch(s);
        }

        /// <summary>
        /// Enables or disables the controls during a submit.
        /// </summary>
        /// <param name="enabled">If set to <c>true</c> controls are enabled.</param>
        private void EnableControls(bool enabled)
        {
            this.btnSubmit.Enabled = enabled;
            this.txtName.Enabled = enabled;
            this.txtEmail.Enabled = enabled;
            this.txtSubject.Enabled = enabled;
            this.txtMessage.Enabled = enabled;
            this.txtCode.Enabled = enabled;
            this.chkDoNotPublish.Enabled = enabled;
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            this.lblSubmitting.Visible = true;

            this.bgwSubmit.RunWorkerAsync(new SubmitInfo(
                this.txtName.Text,
                this.txtEmail.Text,
                this.txtSubject.Text,
                this.txtMessage.Text,
                this.txtCode.Text,
                this.chkDoNotPublish.Checked));
        }
        /// <summary>
        /// Handles the DoWork event of the bgwSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void bgwSubmit_DoWork(object sender, DoWorkEventArgs e)
        {
            var info = (SubmitInfo)e.Argument;

            try
            {
                var service = new WebSubmit.SubmitWTF();
                e.Result = service.Submit(info.Name, info.Email, info.Subject, info.Message, info.Code, info.DoNotPublish);
            }
            catch(Exception ex)
            {
                e.Result = ex;
            }
        }
        /// <summary>
        /// Handles the RunWorkerCompleted event of the bgwSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void bgwSubmit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ex = e.Result as Exception;
            if (ex != null)
            {
                this.lblSubmitting.Visible = false;
                MessageBox.Show(this, "TRWTF is this error message: " + ex.Message, "Submit CodeSOD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls(true);
            }
            else
                this.Close();
        }
        /// <summary>
        /// Handles the TextChanged event of any TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool valid = !Util.IsEmptyOrWhitespace(this.txtName.Text)
                && !Util.IsEmptyOrWhitespace(this.txtCode.Text)
                && IsPossiblyEmailAddress(this.txtEmail.Text);

            this.btnSubmit.Enabled = valid;
        }
        /// <summary>
        /// Handles the LinkClicked event of the lnkCurio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkCurio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://inedo.com/Downloads/DevCurios/?utm_source=devcurio&utm_medium=vs&utm_campaign=wtf",
                UseShellExecute = true
            });
        }

        /// <summary>
        /// Contains information about a code submission.
        /// </summary>
        private sealed class SubmitInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SubmitInfo"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="email">The email address.</param>
            /// <param name="subject">The subject.</param>
            /// <param name="message">The message.</param>
            /// <param name="code">The code.</param>
            /// <param name="doNotPublish">If set to <c>true</c> do not publish.</param>
            public SubmitInfo(string name, string email, string subject, string message, string code, bool doNotPublish)
            {
                this.Name = name;
                this.Email = email;
                this.Subject = subject;
                this.Message = message;
                this.Code = code;
                this.DoNotPublish = doNotPublish;
            }

            /// <summary>
            /// Gets the name.
            /// </summary>
            public string Name { get; private set; }
            /// <summary>
            /// Gets the email address.
            /// </summary>
            public string Email { get; private set; }
            /// <summary>
            /// Gets the subject.
            /// </summary>
            public string Subject { get; private set; }
            /// <summary>
            /// Gets the message.
            /// </summary>
            public string Message { get; private set; }
            /// <summary>
            /// Gets the code.
            /// </summary>
            public string Code { get; private set; }
            /// <summary>
            /// Gets a value indicating whether the snippet should be published.
            /// </summary>
            public bool DoNotPublish { get; private set; }
        }
    }
}
