using System.Windows.Forms;

namespace SubmitToWTF
{
    public partial class SubmitForm : Form
    {
        public SubmitForm()
        {
            InitializeComponent();
        }

        private bool completed = false;

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var style = browser.Document.CreateElement("style");
            style.InnerHtml = @"#navigation, #navigation-bumper, .title, #footer {
	display: none;
}

#wrapper .content-container:nth-last-child(2) {
	padding-bottom: 0;
}

#wrapper .content-container .content {
	background: #fff;
	padding: 2em;
	margin: 2em auto;
	box-shadow: 0.5em 0.5em 2em #210;
}

body {
	background: #eb7 url(https://what.thedailywtf.com/uploads/files/1459185290970-wood.jpg);
}";
            browser.Document.Body.AppendChild(style);

            var snippet = browser.Document.GetElementById("submitform-codesnippet");
            if (snippet != null)
            {
                snippet.SetAttribute("value", codeSnippet);
            }
            completed = true;
        }

        private string codeSnippet = "";
        public string CodeSnippet
        {
            get
            {
                if (completed)
                {
                    var snippet = browser.Document.GetElementById("submitform-codesnippet");
                    if (snippet != null)
                    {
                        codeSnippet = snippet.GetAttribute("value");
                    }
                }
                return codeSnippet;
            }

            set
            {
                codeSnippet = value;
                if (completed)
                {
                    var snippet = browser.Document.GetElementById("submitform-codesnippet");
                    if (snippet != null)
                    {
                        snippet.SetAttribute("value", value);
                    }
                }
            }
        }
    }
}
