namespace PrintShop
{
    partial class FAddProductToCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddProductToCart));
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rtxtCharacter = new System.Windows.Forms.RichTextBox();
            this.cbAdditionalProduct = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbMaterial = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnUpdateAdditionalProductPrice = new System.Windows.Forms.Button();
            this.btnUpdateMaterialPrice = new System.Windows.Forms.Button();
            this.btnCalculatePrice = new System.Windows.Forms.Button();
            this.txtProductPricePerEach = new System.Windows.Forms.TextBox();
            this.txtAdditionalProductPrice = new System.Windows.Forms.TextBox();
            this.txtMaterialPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProductName.Location = new System.Drawing.Point(55, 73);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(389, 30);
            this.txtProductName.TabIndex = 0;
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCategory.Location = new System.Drawing.Point(55, 132);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(389, 30);
            this.txtCategory.TabIndex = 1;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotalPrice.Location = new System.Drawing.Point(55, 736);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(389, 30);
            this.txtTotalPrice.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(60, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название услуги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(60, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(60, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Описание товара";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(60, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Стоимость товара за ед.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(60, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Кол-во товара";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(60, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Доп. услуга";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(60, 472);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Цена доп. услуги";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(60, 532);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Цветность";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(60, 592);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 23);
            this.label9.TabIndex = 11;
            this.label9.Text = "Материал";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(60, 651);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 23);
            this.label10.TabIndex = 12;
            this.label10.Text = "Цена материала";
            // 
            // rtxtCharacter
            // 
            this.rtxtCharacter.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtxtCharacter.Location = new System.Drawing.Point(55, 191);
            this.rtxtCharacter.Name = "rtxtCharacter";
            this.rtxtCharacter.ReadOnly = true;
            this.rtxtCharacter.Size = new System.Drawing.Size(389, 96);
            this.rtxtCharacter.TabIndex = 13;
            this.rtxtCharacter.Text = "";
            // 
            // cbAdditionalProduct
            // 
            this.cbAdditionalProduct.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAdditionalProduct.FormattingEnabled = true;
            this.cbAdditionalProduct.Location = new System.Drawing.Point(55, 438);
            this.cbAdditionalProduct.Name = "cbAdditionalProduct";
            this.cbAdditionalProduct.Size = new System.Drawing.Size(389, 31);
            this.cbAdditionalProduct.TabIndex = 15;
            // 
            // cbColor
            // 
            this.cbColor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(55, 558);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(389, 31);
            this.cbColor.TabIndex = 17;
            // 
            // cbMaterial
            // 
            this.cbMaterial.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMaterial.FormattingEnabled = true;
            this.cbMaterial.Location = new System.Drawing.Point(55, 617);
            this.cbMaterial.Name = "cbMaterial";
            this.cbMaterial.Size = new System.Drawing.Size(389, 31);
            this.cbMaterial.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(60, 710);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "Итоговая цена";
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numQuantity.Location = new System.Drawing.Point(55, 380);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(389, 30);
            this.numQuantity.TabIndex = 21;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToCart.Location = new System.Drawing.Point(257, 786);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(187, 49);
            this.btnAddToCart.TabIndex = 22;
            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // btnUpdateAdditionalProductPrice
            // 
            this.btnUpdateAdditionalProductPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateAdditionalProductPrice.Image")));
            this.btnUpdateAdditionalProductPrice.Location = new System.Drawing.Point(459, 438);
            this.btnUpdateAdditionalProductPrice.Name = "btnUpdateAdditionalProductPrice";
            this.btnUpdateAdditionalProductPrice.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateAdditionalProductPrice.TabIndex = 23;
            this.btnUpdateAdditionalProductPrice.UseVisualStyleBackColor = true;
            this.btnUpdateAdditionalProductPrice.Click += new System.EventHandler(this.btnUpdateAdditionalProductPrice_Click);
            // 
            // btnUpdateMaterialPrice
            // 
            this.btnUpdateMaterialPrice.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateMaterialPrice.Image")));
            this.btnUpdateMaterialPrice.Location = new System.Drawing.Point(459, 616);
            this.btnUpdateMaterialPrice.Name = "btnUpdateMaterialPrice";
            this.btnUpdateMaterialPrice.Size = new System.Drawing.Size(32, 32);
            this.btnUpdateMaterialPrice.TabIndex = 24;
            this.btnUpdateMaterialPrice.UseVisualStyleBackColor = true;
            this.btnUpdateMaterialPrice.Click += new System.EventHandler(this.btnUpdateMaterialPrice_Click);
            // 
            // btnCalculatePrice
            // 
            this.btnCalculatePrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculatePrice.Location = new System.Drawing.Point(55, 786);
            this.btnCalculatePrice.Name = "btnCalculatePrice";
            this.btnCalculatePrice.Size = new System.Drawing.Size(187, 49);
            this.btnCalculatePrice.TabIndex = 25;
            this.btnCalculatePrice.Text = "Рассчитать цену";
            this.btnCalculatePrice.UseVisualStyleBackColor = true;
            this.btnCalculatePrice.Click += new System.EventHandler(this.btnCalculatePrice_Click);
            // 
            // txtProductPricePerEach
            // 
            this.txtProductPricePerEach.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtProductPricePerEach.Location = new System.Drawing.Point(55, 320);
            this.txtProductPricePerEach.Name = "txtProductPricePerEach";
            this.txtProductPricePerEach.ReadOnly = true;
            this.txtProductPricePerEach.Size = new System.Drawing.Size(389, 30);
            this.txtProductPricePerEach.TabIndex = 26;
            // 
            // txtAdditionalProductPrice
            // 
            this.txtAdditionalProductPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAdditionalProductPrice.Location = new System.Drawing.Point(55, 498);
            this.txtAdditionalProductPrice.Name = "txtAdditionalProductPrice";
            this.txtAdditionalProductPrice.ReadOnly = true;
            this.txtAdditionalProductPrice.Size = new System.Drawing.Size(389, 30);
            this.txtAdditionalProductPrice.TabIndex = 27;
            // 
            // txtMaterialPrice
            // 
            this.txtMaterialPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMaterialPrice.Location = new System.Drawing.Point(55, 677);
            this.txtMaterialPrice.Name = "txtMaterialPrice";
            this.txtMaterialPrice.ReadOnly = true;
            this.txtMaterialPrice.Size = new System.Drawing.Size(389, 30);
            this.txtMaterialPrice.TabIndex = 28;
            // 
            // FAddProductToCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 847);
            this.Controls.Add(this.txtMaterialPrice);
            this.Controls.Add(this.txtAdditionalProductPrice);
            this.Controls.Add(this.txtProductPricePerEach);
            this.Controls.Add(this.btnCalculatePrice);
            this.Controls.Add(this.btnUpdateMaterialPrice);
            this.Controls.Add(this.btnUpdateAdditionalProductPrice);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbMaterial);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.cbAdditionalProduct);
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
            this.Name = "FAddProductToCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAddProductToCart";
            this.Load += new System.EventHandler(this.FAddProductToCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtxtCharacter;
        private System.Windows.Forms.ComboBox cbAdditionalProduct;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbMaterial;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnUpdateAdditionalProductPrice;
        private System.Windows.Forms.Button btnUpdateMaterialPrice;
        private System.Windows.Forms.Button btnCalculatePrice;
        private System.Windows.Forms.TextBox txtProductPricePerEach;
        private System.Windows.Forms.TextBox txtAdditionalProductPrice;
        private System.Windows.Forms.TextBox txtMaterialPrice;
    }
}