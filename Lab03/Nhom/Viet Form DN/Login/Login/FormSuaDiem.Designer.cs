
namespace Login
{
    partial class FormSuaDiem
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
            this.dt_GridView_EditScore = new System.Windows.Forms.DataGridView();
            this.MaSv_suadiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.lb_masv = new System.Windows.Forms.Label();
            this.lb_hoten = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaHP = new System.Windows.Forms.TextBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_GridView_EditScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_GridView_EditScore
            // 
            this.dt_GridView_EditScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_GridView_EditScore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSv_suadiem,
            this.MaHP,
            this.DiemThi});
            this.dt_GridView_EditScore.Location = new System.Drawing.Point(287, 36);
            this.dt_GridView_EditScore.Name = "dt_GridView_EditScore";
            this.dt_GridView_EditScore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dt_GridView_EditScore.RowHeadersWidth = 51;
            this.dt_GridView_EditScore.RowTemplate.Height = 24;
            this.dt_GridView_EditScore.Size = new System.Drawing.Size(347, 374);
            this.dt_GridView_EditScore.TabIndex = 0;
            this.dt_GridView_EditScore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_GridView_EditScore_CellClick);
            // 
            // MaSv_suadiem
            // 
            this.MaSv_suadiem.DataPropertyName = "MaSV";
            this.MaSv_suadiem.HeaderText = "Mã Sinh Viên";
            this.MaSv_suadiem.MinimumWidth = 6;
            this.MaSv_suadiem.Name = "MaSv_suadiem";
            this.MaSv_suadiem.Visible = false;
            this.MaSv_suadiem.Width = 125;
            // 
            // MaHP
            // 
            this.MaHP.DataPropertyName = "MaHP";
            this.MaHP.HeaderText = "Học Phần";
            this.MaHP.MinimumWidth = 6;
            this.MaHP.Name = "MaHP";
            this.MaHP.Width = 125;
            // 
            // DiemThi
            // 
            this.DiemThi.DataPropertyName = "DiemThi";
            this.DiemThi.HeaderText = "Điểm Thi";
            this.DiemThi.MinimumWidth = 6;
            this.DiemThi.Name = "DiemThi";
            this.DiemThi.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Sinh Viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Điểm";
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(127, 252);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(88, 22);
            this.txtDiem.TabIndex = 4;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(187, 337);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(77, 29);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "Sửa";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // lb_masv
            // 
            this.lb_masv.AutoSize = true;
            this.lb_masv.ForeColor = System.Drawing.Color.Red;
            this.lb_masv.Location = new System.Drawing.Point(137, 69);
            this.lb_masv.Name = "lb_masv";
            this.lb_masv.Size = new System.Drawing.Size(0, 17);
            this.lb_masv.TabIndex = 6;
            // 
            // lb_hoten
            // 
            this.lb_hoten.AutoSize = true;
            this.lb_hoten.ForeColor = System.Drawing.Color.Red;
            this.lb_hoten.Location = new System.Drawing.Point(94, 128);
            this.lb_hoten.Name = "lb_hoten";
            this.lb_hoten.Size = new System.Drawing.Size(0, 17);
            this.lb_hoten.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã HP";
            // 
            // txtMaHP
            // 
            this.txtMaHP.Location = new System.Drawing.Point(127, 190);
            this.txtMaHP.Name = "txtMaHP";
            this.txtMaHP.Size = new System.Drawing.Size(88, 22);
            this.txtMaHP.TabIndex = 9;
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(18, 337);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(77, 29);
            this.btn_insert.TabIndex = 10;
            this.btn_insert.Text = "Thêm";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(103, 337);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(77, 29);
            this.btn_delete.TabIndex = 11;
            this.btn_delete.Text = "Xoá";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // FormSuaDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 442);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.txtMaHP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_hoten);
            this.Controls.Add(this.lb_masv);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_GridView_EditScore);
            this.Name = "FormSuaDiem";
            this.Text = "FormSuaDiem";
            this.Load += new System.EventHandler(this.FormSuaDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_GridView_EditScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_GridView_EditScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label lb_masv;
        private System.Windows.Forms.Label lb_hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSv_suadiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemThi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaHP;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_delete;
    }
}