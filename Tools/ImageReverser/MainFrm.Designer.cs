﻿namespace UAlbion.Tools.ImageReverser
{
    partial class MainFrm
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
            this.fileTree = new System.Windows.Forms.TreeView();
            this.trackWidth = new System.Windows.Forms.TrackBar();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.scrollBar = new System.Windows.Forms.VScrollBar();
            this.trackOffset = new System.Windows.Forms.TrackBar();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.listPalettes = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // fileTree
            // 
            this.fileTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileTree.Location = new System.Drawing.Point(181, 13);
            this.fileTree.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(236, 740);
            this.fileTree.TabIndex = 0;
            this.fileTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileTree_AfterSelect);
            // 
            // trackWidth
            // 
            this.trackWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackWidth.Location = new System.Drawing.Point(421, 650);
            this.trackWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackWidth.Maximum = 1024;
            this.trackWidth.Minimum = 1;
            this.trackWidth.Name = "trackWidth";
            this.trackWidth.Size = new System.Drawing.Size(520, 56);
            this.trackWidth.TabIndex = 1;
            this.trackWidth.Value = 32;
            this.trackWidth.ValueChanged += new System.EventHandler(this.TrackWidth_ValueChanged);
            this.trackWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrackWidth_KeyDown);
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.Location = new System.Drawing.Point(945, 650);
            this.numWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numWidth.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(75, 22);
            this.numWidth.TabIndex = 2;
            this.numWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.NumWidth_ValueChanged);
            this.numWidth.Enter += new System.EventHandler(this.NumWidth_Enter);
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(421, 564);
            this.textName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(599, 22);
            this.textName.TabIndex = 3;
            this.textName.TextChanged += new System.EventHandler(this.TextName_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(876, 715);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(421, 13);
            this.canvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(563, 547);
            this.canvas.TabIndex = 5;
            this.canvas.TabStop = false;
            // 
            // scrollBar
            // 
            this.scrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollBar.Location = new System.Drawing.Point(986, 2);
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(34, 558);
            this.scrollBar.TabIndex = 6;
            // 
            // trackOffset
            // 
            this.trackOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackOffset.Location = new System.Drawing.Point(421, 590);
            this.trackOffset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackOffset.Maximum = 1024;
            this.trackOffset.Name = "trackOffset";
            this.trackOffset.Size = new System.Drawing.Size(520, 56);
            this.trackOffset.TabIndex = 7;
            this.trackOffset.ValueChanged += new System.EventHandler(this.TrackOffset_ValueChanged);
            // 
            // numOffset
            // 
            this.numOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numOffset.Location = new System.Drawing.Point(945, 590);
            this.numOffset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numOffset.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(75, 22);
            this.numOffset.TabIndex = 8;
            this.numOffset.ValueChanged += new System.EventHandler(this.NumOffset_ValueChanged);
            // 
            // listPalettes
            // 
            this.listPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listPalettes.FormattingEnabled = true;
            this.listPalettes.ItemHeight = 16;
            this.listPalettes.Location = new System.Drawing.Point(13, 13);
            this.listPalettes.Name = "listPalettes";
            this.listPalettes.Size = new System.Drawing.Size(163, 740);
            this.listPalettes.TabIndex = 11;
            this.listPalettes.SelectedIndexChanged += new System.EventHandler(this.ListPalettes_SelectedIndexChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1031, 768);
            this.Controls.Add(this.listPalettes);
            this.Controls.Add(this.numOffset);
            this.Controls.Add(this.trackOffset);
            this.Controls.Add(this.scrollBar);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.trackWidth);
            this.Controls.Add(this.fileTree);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainFrm";
            this.Text = "Image Reverser";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.TrackBar trackWidth;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.VScrollBar scrollBar;
        private System.Windows.Forms.TrackBar trackOffset;
        private System.Windows.Forms.NumericUpDown numOffset;
        private System.Windows.Forms.ListBox listPalettes;
    }
}

