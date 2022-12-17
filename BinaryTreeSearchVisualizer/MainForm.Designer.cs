using BinaryTreeSearchVisualizer.src;

namespace BinaryTreeSearchVisualizer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.insertButton = new System.Windows.Forms.Button();
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.removeTextBox = new System.Windows.Forms.TextBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new System.Windows.Forms.Button();
            this.findKElementTextBox = new System.Windows.Forms.TextBox();
            this.findKElementButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.drawBox = new BinaryTreeSearchVisualizer.src.DrawBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertButton.Location = new System.Drawing.Point(103, 11);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(95, 29);
            this.insertButton.TabIndex = 0;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // insertTextBox
            // 
            this.insertTextBox.Location = new System.Drawing.Point(12, 12);
            this.insertTextBox.Name = "insertTextBox";
            this.insertTextBox.Size = new System.Drawing.Size(85, 27);
            this.insertTextBox.TabIndex = 1;
            // 
            // removeTextBox
            // 
            this.removeTextBox.Location = new System.Drawing.Point(228, 12);
            this.removeTextBox.Name = "removeTextBox";
            this.removeTextBox.Size = new System.Drawing.Size(85, 27);
            this.removeTextBox.TabIndex = 3;
            // 
            // removeButton
            // 
            this.removeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeButton.Location = new System.Drawing.Point(319, 11);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(95, 29);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(444, 12);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(85, 27);
            this.findTextBox.TabIndex = 5;
            // 
            // findButton
            // 
            this.findButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findButton.Location = new System.Drawing.Point(535, 11);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(95, 29);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // findKElementTextBox
            // 
            this.findKElementTextBox.Location = new System.Drawing.Point(660, 12);
            this.findKElementTextBox.Name = "findKElementTextBox";
            this.findKElementTextBox.Size = new System.Drawing.Size(85, 27);
            this.findKElementTextBox.TabIndex = 7;
            // 
            // findKElementButton
            // 
            this.findKElementButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findKElementButton.Location = new System.Drawing.Point(751, 11);
            this.findKElementButton.Name = "findKElementButton";
            this.findKElementButton.Size = new System.Drawing.Size(152, 29);
            this.findKElementButton.TabIndex = 6;
            this.findKElementButton.Text = "Find k-th smallest";
            this.findKElementButton.UseVisualStyleBackColor = true;
            this.findKElementButton.Click += new System.EventHandler(this.findKElementButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetButton.Location = new System.Drawing.Point(1156, 11);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(94, 29);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.messageLabel.Location = new System.Drawing.Point(12, 644);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(67, 20);
            this.messageLabel.TabIndex = 10;
            this.messageLabel.Text = "Message";
            // 
            // drawBox
            // 
            this.drawBox.BackColor = System.Drawing.SystemColors.Menu;
            this.drawBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawBox.Location = new System.Drawing.Point(12, 55);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(1238, 586);
            this.drawBox.TabIndex = 9;
            this.drawBox.TabStop = false;
            this.drawBox.Paint += new System.Windows.Forms.PaintEventHandler(this.drawBox_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.drawBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.findKElementTextBox);
            this.Controls.Add(this.findKElementButton);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.removeTextBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.insertTextBox);
            this.Controls.Add(this.insertButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Binary Tree Search Visualizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawBox drawBox;
        private Button insertButton;
        private TextBox insertTextBox;
        private TextBox removeTextBox;
        private Button removeButton;
        private TextBox findTextBox;
        private Button findButton;
        private TextBox findKElementTextBox;
        private Button findKElementButton;
        private Button resetButton;
        private Label messageLabel;
    }
}