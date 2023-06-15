namespace LB4
{
  partial class AuthorDialog
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
      this.applyAuthor = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(12, 12);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(221, 23);
      this.comboBox1.TabIndex = 0;
      // 
      // applyAuthor
      // 
      this.applyAuthor.Location = new System.Drawing.Point(12, 41);
      this.applyAuthor.Name = "applyAuthor";
      this.applyAuthor.Size = new System.Drawing.Size(221, 23);
      this.applyAuthor.TabIndex = 1;
      this.applyAuthor.Text = "Apply";
      this.applyAuthor.UseVisualStyleBackColor = true;
      this.applyAuthor.Click += new System.EventHandler(this.applyAuthor_Click);
      // 
      // AuthorDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(245, 75);
      this.Controls.Add(this.applyAuthor);
      this.Controls.Add(this.comboBox1);
      this.Name = "AuthorDialog";
      this.Text = "AuthorDialog";
      this.ResumeLayout(false);

    }

    #endregion

    private ComboBox comboBox1;
    private Button applyAuthor;
  }
}