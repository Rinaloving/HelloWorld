namespace TestPaging
{
    partial class PagerControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkNext = new System.Windows.Forms.Button();
            this.linkPrevious = new System.Windows.Forms.Button();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.linkLast = new System.Windows.Forms.Button();
            this.linkFirst = new System.Windows.Forms.Button();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPageCount1 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(-161, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "条";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.lblTotalCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkNext);
            this.panel1.Controls.Add(this.linkPrevious);
            this.panel1.Controls.Add(this.txtPageNum);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.linkLast);
            this.panel1.Controls.Add(this.linkFirst);
            this.panel1.Controls.Add(this.lblPageCount);
            this.panel1.Controls.Add(this.lblCurrentPage);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblPageCount1);
            this.panel1.Controls.Add(this.txtPageSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 49);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "每页";
            // 
            // linkNext
            // 
            this.linkNext.Location = new System.Drawing.Point(514, 14);
            this.linkNext.Name = "linkNext";
            this.linkNext.Size = new System.Drawing.Size(23, 23);
            this.linkNext.TabIndex = 10;
            this.linkNext.Text = ">";
            this.linkNext.UseVisualStyleBackColor = true;
            this.linkNext.Click += new System.EventHandler(this.linkNext_Click);
            // 
            // linkPrevious
            // 
            this.linkPrevious.Location = new System.Drawing.Point(476, 14);
            this.linkPrevious.Name = "linkPrevious";
            this.linkPrevious.Size = new System.Drawing.Size(23, 23);
            this.linkPrevious.TabIndex = 9;
            this.linkPrevious.Text = "<";
            this.linkPrevious.UseVisualStyleBackColor = true;
            this.linkPrevious.Click += new System.EventHandler(this.linkPrevious_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(630, 14);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(44, 21);
            this.txtPageNum.TabIndex = 8;
            this.txtPageNum.TextChanged += new System.EventHandler(this.txtPageNum_TextChanged);
            this.txtPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNum_KeyPress);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(689, 14);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(38, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "跳转";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // linkLast
            // 
            this.linkLast.Location = new System.Drawing.Point(553, 14);
            this.linkLast.Name = "linkLast";
            this.linkLast.Size = new System.Drawing.Size(42, 23);
            this.linkLast.TabIndex = 6;
            this.linkLast.Text = ">>|";
            this.linkLast.UseVisualStyleBackColor = true;
            this.linkLast.Click += new System.EventHandler(this.linkLast_Click);
            // 
            // linkFirst
            // 
            this.linkFirst.Location = new System.Drawing.Point(418, 14);
            this.linkFirst.Name = "linkFirst";
            this.linkFirst.Size = new System.Drawing.Size(42, 23);
            this.linkFirst.TabIndex = 5;
            this.linkFirst.Text = "|<<";
            this.linkFirst.UseVisualStyleBackColor = true;
            this.linkFirst.Click += new System.EventHandler(this.linkFirst_Click);
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPageCount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPageCount.Location = new System.Drawing.Point(258, 19);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(64, 16);
            this.lblPageCount.TabIndex = 4;
            this.lblPageCount.Text = "共   页";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCurrentPage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblCurrentPage.Location = new System.Drawing.Point(144, 19);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(72, 16);
            this.lblCurrentPage.TabIndex = 3;
            this.lblCurrentPage.Text = "当前页：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(99, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "条";
            // 
            // lblPageCount1
            // 
            this.lblPageCount1.AutoSize = true;
            this.lblPageCount1.Font = new System.Drawing.Font("宋体", 12F);
            this.lblPageCount1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPageCount1.Location = new System.Drawing.Point(3, 18);
            this.lblPageCount1.Name = "lblPageCount1";
            this.lblPageCount1.Size = new System.Drawing.Size(0, 16);
            this.lblPageCount1.TabIndex = 1;
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(49, 16);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(44, 21);
            this.txtPageSize.TabIndex = 0;
            this.txtPageSize.SizeChanged += new System.EventHandler(this.txtPageSize1_SizeChanged);
            this.txtPageSize.TextChanged += new System.EventHandler(this.txtPageSize1_TextChanged);
            this.txtPageSize.Leave += new System.EventHandler(this.txtPageSize1_Leave);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("宋体", 12F);
            this.lblTotalCount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalCount.Location = new System.Drawing.Point(328, 19);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(64, 16);
            this.lblTotalCount.TabIndex = 12;
            this.lblTotalCount.Text = "共   条";
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(765, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button linkNext;
        private System.Windows.Forms.Button linkPrevious;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button linkLast;
        private System.Windows.Forms.Button linkFirst;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPageCount1;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCount;
    }
}
