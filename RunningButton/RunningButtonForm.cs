// <copyright file="RunningButtonForm.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunningButton
{
    /// <summary>
    /// Form with running button.
    /// </summary>
    public partial class RunningButtonForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunningButtonForm"/> class.
        /// Running button form.
        /// </summary>
        public RunningButtonForm()
        {
            this.InitializeComponent();
        }

        private void RunningButton_MouseMove(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            int x = 0;
            int y = 0;
            while (!((x + this.RunningButton.Size.Width < e.X || x > e.X) && (y + this.RunningButton.Size.Height < e.Y || y > e.Y))) // condition in which button can not be pressed.
            {
                x = (int)random.Next(0, this.Size.Width - this.RunningButton.Size.Width - 20);
                y = (int)random.Next(0, this.Size.Height - this.RunningButton.Size.Height - 20);
            }

            this.RunningButton.Location = new Point(x, y);
        }

        private void RunningButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
