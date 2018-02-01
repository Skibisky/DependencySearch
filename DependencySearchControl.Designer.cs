namespace DependencySearch {
	partial class DependencySearchControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tbGuid = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbRequest = new System.Windows.Forms.ComboBox();
			this.btnExecute = new System.Windows.Forms.Button();
			this.rtbResponse = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// tbGuid
			// 
			this.tbGuid.Location = new System.Drawing.Point(56, 3);
			this.tbGuid.Name = "tbGuid";
			this.tbGuid.Size = new System.Drawing.Size(227, 20);
			this.tbGuid.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Guid";
			// 
			// cbRequest
			// 
			this.cbRequest.FormattingEnabled = true;
			this.cbRequest.Location = new System.Drawing.Point(56, 29);
			this.cbRequest.Name = "cbRequest";
			this.cbRequest.Size = new System.Drawing.Size(227, 21);
			this.cbRequest.TabIndex = 2;
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(289, 27);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(75, 23);
			this.btnExecute.TabIndex = 3;
			this.btnExecute.Text = "Execute";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// rtbResponse
			// 
			this.rtbResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbResponse.Location = new System.Drawing.Point(3, 56);
			this.rtbResponse.Name = "rtbResponse";
			this.rtbResponse.Size = new System.Drawing.Size(718, 324);
			this.rtbResponse.TabIndex = 4;
			this.rtbResponse.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Request";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(289, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Component Type";
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(383, 3);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(180, 21);
			this.cbType.TabIndex = 7;
			// 
			// DependencySearchControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.rtbResponse);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.cbRequest);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbGuid);
			this.Name = "DependencySearchControl";
			this.Size = new System.Drawing.Size(724, 383);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbGuid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbRequest;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.RichTextBox rtbResponse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbType;
	}
}
