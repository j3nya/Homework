namespace RunningButton
{
    partial class RunningButtonForm
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
            RunningButton = new Button();
            SuspendLayout();
            // 
            // RunningButton
            // 
            RunningButton.Location = new Point(73, 30);
            RunningButton.Name = "RunningButton";
            RunningButton.Size = new Size(70, 70);
            RunningButton.TabIndex = 0;
            RunningButton.Text = "Click on me";
            RunningButton.UseVisualStyleBackColor = true;
            RunningButton.Click += RunningButton_Click;
            RunningButton.MouseMove += RunningButton_MouseMove;
            RunningButton.MouseUp += RunningButton_MouseMove;
            // 
            // RunningButtonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 361);
            Controls.Add(RunningButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RunningButtonForm";
            Text = "Running button";
            ResumeLayout(false);
        }

        #endregion

        private Button RunningButton;
    }
}
