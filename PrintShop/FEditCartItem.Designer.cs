namespace PrintShop
{
    partial class FEditCartItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEditCartItem));
            this.btnCalculatePrice = new System.Windows.Forms.Button();
            this.btnUpdateMaterialPrice = new System.Windows.Forms.Button();
            this.btnUpdateAdditionalProductPrice = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numMaterialPrice = new System.Windows.Forms.NumericUpDown();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.numAdditionalProductPrice = new System.Windows.Forms.NumericUpDown();
            this.cbAdditionalProduct = new System.Windows.Forms.ComboBox();
            this.numProductPricePerEach = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtCharacter = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaterialPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalProductPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductPricePerEach)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalculatePrice
            // 
            this.btnCalculatePrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculatePrice.Location = new System.Drawing.Point(48, 748);
            this.btnCalculatePrice.Name = "btnCalculatePrice";
            this.btnCalculatePrice.Size = new System.Drawing.Size(187, 56);
            this.btnCalculatePrice.TabIndex = 51;
            this.btnCalculatePrice.Text = "Рассчитать цену";
            this.btnCalculatePrice.UseVisualStyleBackColor = true;
            this.btnCalculatePrice.Click += new System.EventHandler(this.btnCalculatePrice_Click);
            // 
            // btnUpdateMaterialPrice
            // 
            this.btnUpdateMaterialPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMaterialPrice.Image")));
            this.btnUpdateMaterialPrice.Location = new System.Drawing.Point(443, 586);
            this.btnUpdateMaterialPrice.Name = "btnUpdateMaterialPrice";
            this.btnUpdateMaterialPrice.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateMaterialPrice.TabIndex = 50;
            this.btnUpdateMaterialPrice.UseVisualStyleBackColor = true;
            this.btnUpdateMaterialPrice.Click += new System.EventHandler(this.btnUpdateMaterialPrice_Click);
            // 
            // btnUpdateAdditionalProductPrice
            // 
            this.btnUpdateAdditionalProductPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateAdditionalProductPrice.Image")));
            this.btnUpdateAdditionalProductPrice.Location = new System.Drawing.Point(443, 407);
            this.btnUpdateAdditionalProductPrice.Name = "btnUpdateAdditionalProductPrice";
            this.btnUpdateAdditionalProductPrice.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateAdditionalProductPrice.TabIndex = 49;
            this.btnUpdateAdditionalProductPrice.UseVisualStyleBackColor = true;
            this.btnUpdateAdditionalProductPrice.Click += new System.EventHandler(this.btnUpdateAdditionalProductPrice_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveChanges.Location = new System.Drawing.Point(250, 748);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(187, 56);
            this.btnSaveChanges.TabIndex = 48;
            this.btnSaveChanges.Text = "Сохранить изменениня";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numQuantity.Location = new System.Drawing.Point(48, 349);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(389, 30);
            this.numQuantity.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(53, 679);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 23);
            this.label11.TabIndex = 46;
            this.label11.Text = "Итоговая цена";
            // 
            // numMaterialPrice
            // 
            this.numMaterialPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numMaterialPrice.Location = new System.Drawing.Point(48, 646);
            this.numMaterialPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaterialPrice.Name = "numMaterialPrice";
            this.numMaterialPrice.ReadOnly = true;
            this.numMaterialPrice.Size = new System.Drawing.Size(389, 30);
            this.numMaterialPrice.TabIndex = 45;
            // 
            // cbMaterial
            // 
            this.cbMaterial.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(48, 586);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(389, 31);
            this.cbMaterial.TabIndex = 44;
            // 
            // cbColor
            // 
            this.cbColor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(48, 527);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(389, 31);
            this.cbColor.TabIndex = 43;
            // 
            // numAdditionalProductPrice
            // 
            this.numAdditionalProductPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numAdditionalProductPrice.Location = new System.Drawing.Point(48, 467);
            this.numAdditionalProductPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAdditionalProductPrice.Name = "numAdditionalProductPrice";
            this.numAdditionalProductPrice.ReadOnly = true;
            this.numAdditionalProductPrice.Size = new System.Drawing.Size(389, 30);
            this.numAdditionalProductPrice.TabIndex = 42;
            // 
            // cbAdditionalProduct
            // 
            this.cbAdditionalProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAdditionalProduct.FormattingEnabled = true;
            this.cbAdditionalProduct.Location = new System.Drawing.Point(48, 407);
            this.cbAdditionalProduct.Name = "cbAdditionalProduct";
            this.cbAdditionalProduct.Size = new System.Drawing.Size(389, 31);
            this.cbAdditionalProduct.TabIndex = 41;
            // 
            // numProductPricePerEach
            // 
            this.numProductPricePerEach.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numProductPricePerEach.Location = new System.Drawing.Point(48, 285);
            this.numProductPricePerEach.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numProductPricePerEach.Name = "numProductPricePerEach";
            this.numProductPricePerEach.ReadOnly = true;
            this.numProductPricePerEach.Size = new System.Drawing.Size(389, 30);
            this.numProductPricePerEach.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(53, 620);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "Цена материала";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(53, 561);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Материал";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(53, 501);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "Цветность";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(53, 441);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 23);
            this.label7.TabIndex = 35;
            this.label7.Text = "Цена доп. услуги";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(53, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 34;
            this.label6.Text = "Доп. услуга";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(53, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 23);
            this.label5.TabIndex = 33;
            this.label5.Text = "Кол-во товара";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(53, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Стоимость товара за ед.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(53, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Категория";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Название услуги";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotalPrice.Location = new System.Drawing.Point(48, 705);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(389, 30);
            this.txtTotalPrice.TabIndex = 28;
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCategory.Location = new System.Drawing.Point(48, 101);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(389, 30);
            this.txtCategory.TabIndex = 27;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProductName.Location = new System.Drawing.Point(48, 42);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(389, 30);
            this.txtProductName.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(53, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Описание товара";
            // 
            // rtxtCharacter
            // 
            this.rtxtCharacter.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtCharacter.Location = new System.Drawing.Point(48, 160);
            this.rtxtCharacter.Name = "rtxtCharacter";
            this.rtxtCharacter.ReadOnly = true;
            this.rtxtCharacter.Size = new System.Drawing.Size(389, 96);
            this.rtxtCharacter.TabIndex = 39;
            this.rtxtCharacter.Text = "";
            // 
            // FEditCartItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 847);
            this.Controls.Add(this.btnCalculatePrice);
            this.Controls.Add(this.btnUpdateMaterialPrice);
            this.Controls.Add(this.btnUpdateAdditionalProductPrice);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numMaterialPrice);
            this.Controls.Add(this.cbMaterial);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.numAdditionalProductPrice);
            this.Controls.Add(this.cbAdditionalProduct);
            this.Controls.Add(this.numProductPricePerEach);
            this.Controls.Add(this.rtxtCharacter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtProductName);
            this.Name = "FEditCartItem";
            this.Text = "FEditCartItem";
            this.Load += new System.EventHandler(this.FEditCartItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaterialPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalProductPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProductPricePerEach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculatePrice;
        private System.Windows.Forms.Button btnUpdateMaterialPrice;
        private System.Windows.Forms.Button btnUpdateAdditionalProductPrice;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numMaterialPrice;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.NumericUpDown numAdditionalProductPrice;
        private System.Windows.Forms.ComboBox cbAdditionalProduct;
        private System.Windows.Forms.NumericUpDown numProductPricePerEach;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtCharacter;
    }
}