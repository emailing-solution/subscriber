namespace subscribe
{
    partial class Subscriber
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            emails = new RichTextBox();
            label1 = new Label();
            subscribe = new Button();
            SuspendLayout();
            // 
            // emails
            // 
            emails.Location = new Point(65, 12);
            emails.Name = "emails";
            emails.Size = new Size(341, 297);
            emails.TabIndex = 0;
            emails.Text = "test@test.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Emails :";
            // 
            // subscribe
            // 
            subscribe.Location = new Point(65, 315);
            subscribe.Name = "subscribe";
            subscribe.Size = new Size(341, 30);
            subscribe.TabIndex = 2;
            subscribe.Text = "SUBSCRIBE";
            subscribe.UseVisualStyleBackColor = true;
            subscribe.Click += Subscribe_Click;
            // 
            // Subscriber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 359);
            Controls.Add(subscribe);
            Controls.Add(label1);
            Controls.Add(emails);
            Name = "Subscriber";
            Text = "Subscriber";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox emails;
        private Label label1;
        private Button subscribe;
    }
}
