namespace PlaceInstances
{
  partial class PlaceInstancesForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btnBrowseXyz = new System.Windows.Forms.Button();
      this.txtFilename = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cmbType = new System.Windows.Forms.ComboBox();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.cmbFamily = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point( 17, 13 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 39, 13 );
      this.label1.TabIndex = 0;
      this.label1.Text = "Family:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point( 17, 39 );
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size( 34, 13 );
      this.label2.TabIndex = 3;
      this.label2.Text = "Type:";
      // 
      // btnBrowseXyz
      // 
      this.btnBrowseXyz.Location = new System.Drawing.Point( 20, 81 );
      this.btnBrowseXyz.Name = "btnBrowseXyz";
      this.btnBrowseXyz.Size = new System.Drawing.Size( 71, 21 );
      this.btnBrowseXyz.TabIndex = 8;
      this.btnBrowseXyz.Text = "Browse...";
      this.btnBrowseXyz.UseVisualStyleBackColor = true;
      this.btnBrowseXyz.Click += new System.EventHandler( this.btnBrowseXyz_Click );
      // 
      // txtFilename
      // 
      this.txtFilename.Location = new System.Drawing.Point( 109, 65 );
      this.txtFilename.Name = "txtFilename";
      this.txtFilename.Size = new System.Drawing.Size( 172, 20 );
      this.txtFilename.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point( 17, 65 );
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size( 74, 13 );
      this.label3.TabIndex = 6;
      this.label3.Text = "XYZ Text File:";
      // 
      // cmbType
      // 
      this.cmbType.FormattingEnabled = true;
      this.cmbType.Location = new System.Drawing.Point( 109, 36 );
      this.cmbType.Name = "cmbType";
      this.cmbType.Size = new System.Drawing.Size( 172, 21 );
      this.cmbType.TabIndex = 9;
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point( 109, 94 );
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size( 83, 21 );
      this.btnOk.TabIndex = 10;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler( this.btnOk_Click );
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point( 198, 94 );
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size( 83, 21 );
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // cmbFamily
      // 
      this.cmbFamily.FormattingEnabled = true;
      this.cmbFamily.Location = new System.Drawing.Point( 109, 10 );
      this.cmbFamily.Name = "cmbFamily";
      this.cmbFamily.Size = new System.Drawing.Size( 172, 21 );
      this.cmbFamily.TabIndex = 12;
      this.cmbFamily.SelectedIndexChanged += new System.EventHandler( this.cmbFamily_SelectedIndexChanged );
      // 
      // PlaceInstancesForm
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size( 306, 127 );
      this.Controls.Add( this.cmbFamily );
      this.Controls.Add( this.btnCancel );
      this.Controls.Add( this.btnOk );
      this.Controls.Add( this.cmbType );
      this.Controls.Add( this.btnBrowseXyz );
      this.Controls.Add( this.txtFilename );
      this.Controls.Add( this.label3 );
      this.Controls.Add( this.label2 );
      this.Controls.Add( this.label1 );
      this.Name = "PlaceInstancesForm";
      this.Text = "Place Family Instances";
      this.Load += new System.EventHandler( this.PlaceInstancesForm_Load );
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnBrowseXyz;
    private System.Windows.Forms.TextBox txtFilename;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cmbType;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ComboBox cmbFamily;
  }
}