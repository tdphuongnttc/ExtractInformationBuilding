using System.Collections.Generic;

namespace CityModel
{
    partial class Form3dmRead
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
            this.btnBrowse3dm = new System.Windows.Forms.Button();
            this.rtb3dmReport = new System.Windows.Forms.RichTextBox();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowse3dm
            // 
            this.btnBrowse3dm.Location = new System.Drawing.Point(20, 30);
            this.btnBrowse3dm.Name = "btnBrowse3dm";
            this.btnBrowse3dm.Size = new System.Drawing.Size(190, 50);
            this.btnBrowse3dm.TabIndex = 0;
            this.btnBrowse3dm.Text = "Browse >>";
            this.btnBrowse3dm.UseVisualStyleBackColor = true;
            this.btnBrowse3dm.Click += new System.EventHandler(this.btnBrowse3dm_Click);
            // 
            // rtb3dmReport
            // 
            this.rtb3dmReport.Location = new System.Drawing.Point(20, 170);
            this.rtb3dmReport.Name = "rtb3dmReport";
            this.rtb3dmReport.Size = new System.Drawing.Size(960, 730);
            this.rtb3dmReport.TabIndex = 1;
            this.rtb3dmReport.Text = "";
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(20, 100);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(190, 50);
            this.btnDump.TabIndex = 2;
            this.btnDump.Text = "Dump";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(460, 100);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(190, 50);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(240, 100);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 50);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(240, 40);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(1240, 31);
            this.tbFilename.TabIndex = 5;
            // 
            // rtbStatus
            // 
            this.rtbStatus.Location = new System.Drawing.Point(1000, 170);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(480, 730);
            this.rtbStatus.TabIndex = 6;
            this.rtbStatus.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(900, 100);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(190, 50);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(680, 100);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(190, 50);
            this.btnParse.TabIndex = 8;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // Form3dmRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 933);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.rtb3dmReport);
            this.Controls.Add(this.btnBrowse3dm);
            this.Name = "Form3dmRead";
            this.Text = "3dm Reader (c) Hoang-Giang Bui, 2018, Ruhr University Bochum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse3dm;
        private System.Windows.Forms.RichTextBox rtb3dmReport;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnClear;

        private Rhino.FileIO.File3dm m_f3dm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnParse;

        private List<ModelGeometry> mModelGeometryList;
    }
}

