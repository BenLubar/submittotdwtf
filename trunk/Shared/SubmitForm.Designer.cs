namespace SubmitToWTF
{
    partial class SubmitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblName;
            System.Windows.Forms.Label lblEmail;
            System.Windows.Forms.Label lblSubject;
            System.Windows.Forms.Label lblMessage;
            System.Windows.Forms.Label lblCode;
            System.Windows.Forms.SplitContainer splitContainer1;
            System.Windows.Forms.Label lblDoNotPublish;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitForm));
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chkDoNotPublish = new System.Windows.Forms.CheckBox();
            this.bgwSubmit = new System.ComponentModel.BackgroundWorker();
            this.lblSubmitting = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            lblEmail = new System.Windows.Forms.Label();
            lblSubject = new System.Windows.Forms.Label();
            lblMessage = new System.Windows.Forms.Label();
            lblCode = new System.Windows.Forms.Label();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            lblDoNotPublish = new System.Windows.Forms.Label();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = System.Drawing.Color.Transparent;
            lblName.Location = new System.Drawing.Point(50, 43);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(63, 13);
            lblName.TabIndex = 0;
            lblName.Text = "Your Name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = System.Drawing.Color.Transparent;
            lblEmail.Location = new System.Drawing.Point(53, 69);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(60, 13);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Your Email:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.BackColor = System.Drawing.Color.Transparent;
            lblSubject.Location = new System.Drawing.Point(66, 96);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new System.Drawing.Size(47, 13);
            lblSubject.TabIndex = 4;
            lblSubject.Text = "Subject:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new System.Drawing.Point(-3, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(53, 13);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Message:";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new System.Drawing.Point(-3, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new System.Drawing.Size(75, 13);
            lblCode.TabIndex = 0;
            lblCode.Text = "Code Snippet:";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            splitContainer1.BackColor = System.Drawing.Color.Transparent;
            splitContainer1.Location = new System.Drawing.Point(49, 120);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            splitContainer1.Panel1.Controls.Add(lblMessage);
            splitContainer1.Panel1.Controls.Add(this.txtMessage);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblCode);
            splitContainer1.Panel2.Controls.Add(this.txtCode);
            splitContainer1.Size = new System.Drawing.Size(503, 316);
            splitContainer1.SplitterDistance = 157;
            splitContainer1.TabIndex = 6;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(0, 16);
            this.txtMessage.MaxLength = 1000;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(503, 138);
            this.txtMessage.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(0, 16);
            this.txtCode.MaxLength = 4000;
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(506, 138);
            this.txtCode.TabIndex = 1;
            this.txtCode.WordWrap = false;
            this.txtCode.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(119, 40);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(433, 21);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(119, 66);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(433, 21);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(119, 93);
            this.txtSubject.MaxLength = 100;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(433, 21);
            this.txtSubject.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(480, 457);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chkDoNotPublish
            // 
            this.chkDoNotPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDoNotPublish.AutoSize = true;
            this.chkDoNotPublish.BackColor = System.Drawing.Color.Transparent;
            this.chkDoNotPublish.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoNotPublish.Location = new System.Drawing.Point(49, 442);
            this.chkDoNotPublish.Name = "chkDoNotPublish";
            this.chkDoNotPublish.Size = new System.Drawing.Size(142, 17);
            this.chkDoNotPublish.TabIndex = 6;
            this.chkDoNotPublish.Text = "Please Don’t Publish.";
            this.chkDoNotPublish.UseVisualStyleBackColor = false;
            // 
            // bgwSubmit
            // 
            this.bgwSubmit.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSubmit_DoWork);
            this.bgwSubmit.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSubmit_RunWorkerCompleted);
            // 
            // lblSubmitting
            // 
            this.lblSubmitting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubmitting.AutoSize = true;
            this.lblSubmitting.BackColor = System.Drawing.Color.Transparent;
            this.lblSubmitting.Location = new System.Drawing.Point(405, 462);
            this.lblSubmitting.Name = "lblSubmitting";
            this.lblSubmitting.Size = new System.Drawing.Size(69, 13);
            this.lblSubmitting.TabIndex = 8;
            this.lblSubmitting.Text = "Submitting...";
            this.lblSubmitting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblSubmitting.Visible = false;
            // 
            // lblDoNotPublish
            // 
            lblDoNotPublish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            lblDoNotPublish.BackColor = System.Drawing.Color.Transparent;
            lblDoNotPublish.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDoNotPublish.Location = new System.Drawing.Point(66, 457);
            lblDoNotPublish.Name = "lblDoNotPublish";
            lblDoNotPublish.Size = new System.Drawing.Size(310, 39);
            lblDoNotPublish.TabIndex = 9;
            lblDoNotPublish.Text = resources.GetString("lblDoNotPublish.Text");
            // 
            // SubmitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SubmitToWTF.Properties.Resources.WoodenTable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(596, 526);
            this.Controls.Add(lblDoNotPublish);
            this.Controls.Add(this.lblSubmitting);
            this.Controls.Add(splitContainer1);
            this.Controls.Add(this.chkDoNotPublish);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(lblSubject);
            this.Controls.Add(lblEmail);
            this.Controls.Add(lblName);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "SubmitForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Submit CodeSOD...";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox chkDoNotPublish;
        private System.Windows.Forms.TextBox txtCode;
        private System.ComponentModel.BackgroundWorker bgwSubmit;
        private System.Windows.Forms.Label lblSubmitting;

    }
}