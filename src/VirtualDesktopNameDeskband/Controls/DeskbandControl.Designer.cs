
namespace VirtualDesktopNameDeskband
{
    partial class DeskbandControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDesktopName = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblDesktopName
            // 
            this.lblDesktopName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDesktopName.AutoEllipsis = true;
            this.lblDesktopName.BackColor = System.Drawing.Color.Transparent;
            this.lblDesktopName.ForeColor = System.Drawing.Color.White;
            this.lblDesktopName.Location = new System.Drawing.Point(0, 0);
            this.lblDesktopName.Margin = new System.Windows.Forms.Padding(0);
            this.lblDesktopName.Name = "lblDesktopName";
            this.lblDesktopName.Size = new System.Drawing.Size(100, 23);
            this.lblDesktopName.TabIndex = 0;
            this.lblDesktopName.Text = "Desktop 1";
            this.lblDesktopName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // DeskbandControl
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lblDesktopName);
            this.Name = "DeskbandControl";
            this.Size = new System.Drawing.Size(100, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDesktopName;
        private System.Windows.Forms.Timer timer;
    }
}
