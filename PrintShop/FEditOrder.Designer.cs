namespace PrintShop
{
    partial class FEditOrder
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateOrderStart = new System.Windows.Forms.DateTimePicker();
            this.dateOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cbStaffFIO = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserFIO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderTotalPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 76;
            this.label2.Text = "Дата заказа";
            // 
            // dateOrderStart
            // 
            this.dateOrderStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateOrderStart.Enabled = false;
            this.dateOrderStart.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateOrderStart.Location = new System.Drawing.Point(22, 103);
            this.dateOrderStart.Name = "dateOrderStart";
            this.dateOrderStart.Size = new System.Drawing.Size(389, 30);
            this.dateOrderStart.TabIndex = 77;
            // 
            // dateOrderEnd
            // 
            this.dateOrderEnd.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateOrderEnd.Location = new System.Drawing.Point(417, 103);
            this.dateOrderEnd.Name = "dateOrderEnd";
            this.dateOrderEnd.Size = new System.Drawing.Size(389, 30);
            this.dateOrderEnd.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(422, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 23);
            this.label12.TabIndex = 79;
            this.label12.Text = "Дата завершнения заказа";
            // 
            // cbStaffFIO
            // 
            this.cbStaffFIO.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStaffFIO.FormattingEnabled = true;
            this.cbStaffFIO.Location = new System.Drawing.Point(417, 162);
            this.cbStaffFIO.Name = "cbStaffFIO";
            this.cbStaffFIO.Size = new System.Drawing.Size(389, 31);
            this.cbStaffFIO.TabIndex = 80;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(422, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 23);
            this.label13.TabIndex = 81;
            this.label13.Text = "Исполнитель";
            // 
            // cbOrderStatus
            // 
            this.cbOrderStatus.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbOrderStatus.FormattingEnabled = true;
            this.cbOrderStatus.Items.AddRange(new object[] {
            "Создан",
            "В производстве",
            "Готов к выдаче",
            "Завершен"});
            this.cbOrderStatus.Location = new System.Drawing.Point(22, 162);
            this.cbOrderStatus.Name = "cbOrderStatus";
            this.cbOrderStatus.Size = new System.Drawing.Size(389, 31);
            this.cbOrderStatus.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 83;
            this.label3.Text = "Статус";
            // 
            // txtUserFIO
            // 
            this.txtUserFIO.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUserFIO.Location = new System.Drawing.Point(22, 42);
            this.txtUserFIO.Name = "txtUserFIO";
            this.txtUserFIO.ReadOnly = true;
            this.txtUserFIO.Size = new System.Drawing.Size(389, 30);
            this.txtUserFIO.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(27, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 85;
            this.label4.Text = "ФИО заказчика";
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveOrder.Location = new System.Drawing.Point(298, 202);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(230, 79);
            this.btnSaveOrder.TabIndex = 88;
            this.btnSaveOrder.Text = "Сохранить изменения";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(422, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 90;
            this.label1.Text = "Цена заказа";
            // 
            // txtOrderTotalPrice
            // 
            this.txtOrderTotalPrice.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtOrderTotalPrice.Location = new System.Drawing.Point(417, 42);
            this.txtOrderTotalPrice.Name = "txtOrderTotalPrice";
            this.txtOrderTotalPrice.ReadOnly = true;
            this.txtOrderTotalPrice.Size = new System.Drawing.Size(389, 30);
            this.txtOrderTotalPrice.TabIndex = 89;
            // 
            // FEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderTotalPrice);
            this.Controls.Add(this.btnSaveOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserFIO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbOrderStatus);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbStaffFIO);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateOrderEnd);
            this.Controls.Add(this.dateOrderStart);
            this.Controls.Add(this.label2);
            this.Name = "FEditOrder";
            this.Text = "FEditOrderPosition";
            this.Load += new System.EventHandler(this.FEditOrderPosition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateOrderStart;
        private System.Windows.Forms.DateTimePicker dateOrderEnd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbStaffFIO;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbOrderStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserFIO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderTotalPrice;
    }
}