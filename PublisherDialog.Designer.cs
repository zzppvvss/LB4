namespace LB4
{
  partial class PublisherDialog
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
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.applyPublisher = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(12, 12);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(181, 23);
      this.comboBox1.TabIndex = 0;
      // 
      // applyPublisher
      // 
      this.applyPublisher.Location = new System.Drawing.Point(12, 41);
      this.applyPublisher.Name = "applyPublisher";
      this.applyPublisher.Size = new System.Drawing.Size(181, 23);
      this.applyPublisher.TabIndex = 1;
      this.applyPublisher.Text = "Apply";
      this.applyPublisher.UseVisualStyleBackColor = true;
      this.applyPublisher.Click += new System.EventHandler(this.applyPublisher_Click);
      // 
      // PublisherDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(204, 76);
      this.Controls.Add(this.applyPublisher);
      this.Controls.Add(this.comboBox1);
      this.Name = "PublisherDialog";
      this.Text = "PublisherDialog";
      this.ResumeLayout(false);

    }

    #endregion

    private ComboBox comboBox1;
    private Button applyPublisher;
  }
}