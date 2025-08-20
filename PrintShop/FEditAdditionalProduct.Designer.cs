namespace PrintShop
{
    partial class FEditAdditionalProduct
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
            this.txtAdditioanlProductName = new System.Windows.Forms.TextBox();
            this.numAdditionalProductPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalProductPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAdditioanlProductName
            // 
            this.txtAdditioanlProductName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAdditioanlProductName.Location = new System.Drawing.Point(52, 63);
            this.txtAdditioanlProductName.Name = "txtAdditioanlProductName";
            this.txtAdditioanlProductName.Size = new System.Drawing.Size(222, 30);
            this.txtAdditioanlProductName.TabIndex = 0;
            // 
            // numAdditionalProductPrice
            // 
            this.numAdditionalProductPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numAdditionalProductPrice.Location = new System.Drawing.Point(52, 135);
            this.numAdditionalProductPrice.Name = "numAdditionalProductPrice";
            this.numAdditionalProductPrice.Size = new System.Drawing.Size(222, 30);
            this.numAdditionalProductPrice.TabIndex = 1;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveChanges.Location = new System.Drawing.Point(52, 228);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(222, 38);
            this.btnSaveChanges.TabIndex = 2;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(62, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цена";
            // 
            // FEditAdditionalProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.numAdditionalProductPrice);
            this.Controls.Add(this.txtAdditioanlProductName);
            this.Name = "FEditAdditionalProduct";
            this.Text = "FEditAdditionalProduct";
            this.Load += new System.EventHandler(this.FEditAdditionalProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalProductPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdditioanlProductName;
        private System.Windows.Forms.NumericUpDown numAdditionalProductPrice;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}