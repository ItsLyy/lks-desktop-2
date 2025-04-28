namespace EsemkaVote2.View
{
    partial class EsemkaVote
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
            this.VotingHeaderCombo = new System.Windows.Forms.ComboBox();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.DescLabel = new System.Windows.Forms.Label();
            this.EmployeePicture = new System.Windows.Forms.PictureBox();
            this.EmployeeNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmployeeVotePercentLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VotingCountLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.VotingCountTotalLabel = new System.Windows.Forms.Label();
            this.VoteDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.FlowLayoutReason = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoteDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Vote Event";
            // 
            // VotingHeaderCombo
            // 
            this.VotingHeaderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VotingHeaderCombo.FormattingEnabled = true;
            this.VotingHeaderCombo.Location = new System.Drawing.Point(34, 72);
            this.VotingHeaderCombo.Name = "VotingHeaderCombo";
            this.VotingHeaderCombo.Size = new System.Drawing.Size(228, 21);
            this.VotingHeaderCombo.TabIndex = 1;
            this.VotingHeaderCombo.SelectedIndexChanged += new System.EventHandler(this.EmployeeYearComboBox_SelectedIndexChanged);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(560, 43);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(281, 31);
            this.HeaderLabel.TabIndex = 2;
            this.HeaderLabel.Text = "Best Employee 2023";
            this.HeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescLabel
            // 
            this.DescLabel.BackColor = System.Drawing.Color.Transparent;
            this.DescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescLabel.Location = new System.Drawing.Point(333, 74);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(735, 78);
            this.DescLabel.TabIndex = 3;
            this.DescLabel.Text = "Welcome to the Employee of the Year 2023 voting! Celebrate outstanding dedication" +
    " and achievement by casting your vote for the most deserving nominee.";
            this.DescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeePicture
            // 
            this.EmployeePicture.Location = new System.Drawing.Point(610, 145);
            this.EmployeePicture.Name = "EmployeePicture";
            this.EmployeePicture.Size = new System.Drawing.Size(181, 246);
            this.EmployeePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EmployeePicture.TabIndex = 4;
            this.EmployeePicture.TabStop = false;
            // 
            // EmployeeNameLabel
            // 
            this.EmployeeNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeNameLabel.AutoSize = true;
            this.EmployeeNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeNameLabel.Location = new System.Drawing.Point(644, 405);
            this.EmployeeNameLabel.Name = "EmployeeNameLabel";
            this.EmployeeNameLabel.Size = new System.Drawing.Size(112, 25);
            this.EmployeeNameLabel.TabIndex = 5;
            this.EmployeeNameLabel.Text = "John Doe";
            this.EmployeeNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(671, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "With";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeVotePercentLabel
            // 
            this.EmployeeVotePercentLabel.AutoSize = true;
            this.EmployeeVotePercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeVotePercentLabel.Location = new System.Drawing.Point(676, 469);
            this.EmployeeVotePercentLabel.Name = "EmployeeVotePercentLabel";
            this.EmployeeVotePercentLabel.Size = new System.Drawing.Size(48, 24);
            this.EmployeeVotePercentLabel.TabIndex = 7;
            this.EmployeeVotePercentLabel.Text = "62%";
            this.EmployeeVotePercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(654, 494);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "(";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VotingCountLabel
            // 
            this.VotingCountLabel.AutoSize = true;
            this.VotingCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VotingCountLabel.Location = new System.Drawing.Point(664, 496);
            this.VotingCountLabel.Name = "VotingCountLabel";
            this.VotingCountLabel.Size = new System.Drawing.Size(32, 24);
            this.VotingCountLabel.TabIndex = 9;
            this.VotingCountLabel.Text = "31";
            this.VotingCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(691, 496);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "/";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(729, 494);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = ")";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // VotingCountTotalLabel
            // 
            this.VotingCountTotalLabel.AutoSize = true;
            this.VotingCountTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VotingCountTotalLabel.Location = new System.Drawing.Point(702, 496);
            this.VotingCountTotalLabel.Name = "VotingCountTotalLabel";
            this.VotingCountTotalLabel.Size = new System.Drawing.Size(32, 24);
            this.VotingCountTotalLabel.TabIndex = 13;
            this.VotingCountTotalLabel.Text = "31";
            this.VotingCountTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VoteDataGridView
            // 
            this.VoteDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VoteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VoteDataGridView.Location = new System.Drawing.Point(20, 532);
            this.VoteDataGridView.Name = "VoteDataGridView";
            this.VoteDataGridView.Size = new System.Drawing.Size(1361, 264);
            this.VoteDataGridView.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 808);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Reason";
            // 
            // FlowLayoutReason
            // 
            this.FlowLayoutReason.AutoScroll = true;
            this.FlowLayoutReason.Location = new System.Drawing.Point(20, 836);
            this.FlowLayoutReason.Name = "FlowLayoutReason";
            this.FlowLayoutReason.Size = new System.Drawing.Size(1361, 204);
            this.FlowLayoutReason.TabIndex = 16;
            this.FlowLayoutReason.WrapContents = false;
            // 
            // EsemkaVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 1052);
            this.Controls.Add(this.FlowLayoutReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VoteDataGridView);
            this.Controls.Add(this.VotingCountTotalLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VotingCountLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EmployeeVotePercentLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmployeeNameLabel);
            this.Controls.Add(this.EmployeePicture);
            this.Controls.Add(this.DescLabel);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.VotingHeaderCombo);
            this.Controls.Add(this.label1);
            this.Name = "EsemkaVote";
            this.Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.EmployeePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoteDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox VotingHeaderCombo;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Label DescLabel;
        private System.Windows.Forms.PictureBox EmployeePicture;
        private System.Windows.Forms.Label EmployeeNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EmployeeVotePercentLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label VotingCountLabel;
        private System.Windows.Forms.Label VotingCountTotalLabel;
        private System.Windows.Forms.DataGridView VoteDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutReason;
    }
}