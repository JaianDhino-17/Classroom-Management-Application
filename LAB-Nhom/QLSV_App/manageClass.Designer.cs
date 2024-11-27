namespace QLSV_App
{
    partial class manageClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ClassID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ClassName = new System.Windows.Forms.TextBox();
            this.txt_employeeID = new System.Windows.Forms.TextBox();
            this.btn_insertClass = new System.Windows.Forms.Button();
            this.btn_updateClass = new System.Windows.Forms.Button();
            this.btn_deleteClass = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Thông Tin Của Lớp Cần Chỉnh Sửa";
            // 
            // txt_ClassID
            // 
            this.txt_ClassID.Location = new System.Drawing.Point(207, 98);
            this.txt_ClassID.Multiline = true;
            this.txt_ClassID.Name = "txt_ClassID";
            this.txt_ClassID.Size = new System.Drawing.Size(333, 31);
            this.txt_ClassID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Lớp : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên Lớp : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã NV : ";
            // 
            // txt_ClassName
            // 
            this.txt_ClassName.Location = new System.Drawing.Point(207, 155);
            this.txt_ClassName.Multiline = true;
            this.txt_ClassName.Name = "txt_ClassName";
            this.txt_ClassName.Size = new System.Drawing.Size(333, 31);
            this.txt_ClassName.TabIndex = 5;
            // 
            // txt_employeeID
            // 
            this.txt_employeeID.Location = new System.Drawing.Point(207, 203);
            this.txt_employeeID.Multiline = true;
            this.txt_employeeID.Name = "txt_employeeID";
            this.txt_employeeID.Size = new System.Drawing.Size(333, 31);
            this.txt_employeeID.TabIndex = 6;
            // 
            // btn_insertClass
            // 
            this.btn_insertClass.Location = new System.Drawing.Point(38, 301);
            this.btn_insertClass.Name = "btn_insertClass";
            this.btn_insertClass.Size = new System.Drawing.Size(113, 31);
            this.btn_insertClass.TabIndex = 8;
            this.btn_insertClass.Text = "Thêm";
            this.btn_insertClass.UseVisualStyleBackColor = true;
            this.btn_insertClass.Click += new System.EventHandler(this.btn_insertClass_Click);
            // 
            // btn_updateClass
            // 
            this.btn_updateClass.Location = new System.Drawing.Point(157, 301);
            this.btn_updateClass.Name = "btn_updateClass";
            this.btn_updateClass.Size = new System.Drawing.Size(113, 31);
            this.btn_updateClass.TabIndex = 9;
            this.btn_updateClass.Text = "Sửa";
            this.btn_updateClass.UseVisualStyleBackColor = true;
            this.btn_updateClass.Click += new System.EventHandler(this.btn_updateClass_Click);
            // 
            // btn_deleteClass
            // 
            this.btn_deleteClass.Location = new System.Drawing.Point(276, 301);
            this.btn_deleteClass.Name = "btn_deleteClass";
            this.btn_deleteClass.Size = new System.Drawing.Size(113, 31);
            this.btn_deleteClass.TabIndex = 10;
            this.btn_deleteClass.Text = "Xóa";
            this.btn_deleteClass.UseVisualStyleBackColor = true;
            this.btn_deleteClass.Click += new System.EventHandler(this.btn_deleteClass_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(427, 301);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(113, 31);
            this.btn_Exit.TabIndex = 11;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // manageClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 366);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_deleteClass);
            this.Controls.Add(this.btn_updateClass);
            this.Controls.Add(this.btn_insertClass);
            this.Controls.Add(this.txt_employeeID);
            this.Controls.Add(this.txt_ClassName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ClassID);
            this.Controls.Add(this.label1);
            this.Name = "manageClass";
            this.Text = "manageClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ClassID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ClassName;
        private System.Windows.Forms.TextBox txt_employeeID;
        private System.Windows.Forms.Button btn_insertClass;
        private System.Windows.Forms.Button btn_updateClass;
        private System.Windows.Forms.Button btn_deleteClass;
        private System.Windows.Forms.Button btn_Exit;
    }
}