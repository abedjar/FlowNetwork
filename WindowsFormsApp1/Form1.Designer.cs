namespace WindowsFormsApp1
{
    partial class Form1
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
            this.btnFindMaxFlow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNodes = new System.Windows.Forms.TextBox();
            this.rtbEdges = new System.Windows.Forms.RichTextBox();
            this.tbMaxFlow = new System.Windows.Forms.TextBox();
            this.btnMinCut = new System.Windows.Forms.Button();
            this.rtbMinCut = new System.Windows.Forms.RichTextBox();
            this.rbtAugPaths = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAvgTime = new System.Windows.Forms.TextBox();
            this.do1000 = new System.Windows.Forms.Button();
            this.btnGlobal = new System.Windows.Forms.Button();
            this.btnAllPaths = new System.Windows.Forms.Button();
            this.tbNoOfAugPaths = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFindMaxFlow
            // 
            this.btnFindMaxFlow.Location = new System.Drawing.Point(416, 89);
            this.btnFindMaxFlow.Name = "btnFindMaxFlow";
            this.btnFindMaxFlow.Size = new System.Drawing.Size(108, 23);
            this.btnFindMaxFlow.TabIndex = 0;
            this.btnFindMaxFlow.Text = "Find Max Flow";
            this.btnFindMaxFlow.UseVisualStyleBackColor = true;
            this.btnFindMaxFlow.Click += new System.EventHandler(this.btnFindMaxFlow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "edges";
            // 
            // tbNodes
            // 
            this.tbNodes.Location = new System.Drawing.Point(12, 26);
            this.tbNodes.Name = "tbNodes";
            this.tbNodes.Size = new System.Drawing.Size(398, 20);
            this.tbNodes.TabIndex = 3;
            this.tbNodes.Text = "0,1,2,3,4,5";
            // 
            // rtbEdges
            // 
            this.rtbEdges.Location = new System.Drawing.Point(12, 89);
            this.rtbEdges.Name = "rtbEdges";
            this.rtbEdges.Size = new System.Drawing.Size(398, 208);
            this.rtbEdges.TabIndex = 4;
            this.rtbEdges.Text = "0 1 10\n0 2 3\n0 4 1\n1 2 1\n1 3 2\n1 5 5\n2 3 6\n3 5 5\n4 2 3\n4 3 3\n4 5 10";
            // 
            // tbMaxFlow
            // 
            this.tbMaxFlow.Enabled = false;
            this.tbMaxFlow.Location = new System.Drawing.Point(527, 91);
            this.tbMaxFlow.Name = "tbMaxFlow";
            this.tbMaxFlow.Size = new System.Drawing.Size(173, 20);
            this.tbMaxFlow.TabIndex = 5;
            // 
            // btnMinCut
            // 
            this.btnMinCut.Location = new System.Drawing.Point(416, 119);
            this.btnMinCut.Name = "btnMinCut";
            this.btnMinCut.Size = new System.Drawing.Size(108, 23);
            this.btnMinCut.TabIndex = 6;
            this.btnMinCut.Text = "min-cut";
            this.btnMinCut.UseVisualStyleBackColor = true;
            this.btnMinCut.Click += new System.EventHandler(this.btnMinCut_Click);
            // 
            // rtbMinCut
            // 
            this.rtbMinCut.Location = new System.Drawing.Point(527, 119);
            this.rtbMinCut.Name = "rtbMinCut";
            this.rtbMinCut.Size = new System.Drawing.Size(173, 56);
            this.rtbMinCut.TabIndex = 7;
            this.rtbMinCut.Text = "";
            // 
            // rbtAugPaths
            // 
            this.rbtAugPaths.Location = new System.Drawing.Point(527, 181);
            this.rbtAugPaths.Name = "rbtAugPaths";
            this.rbtAugPaths.Size = new System.Drawing.Size(268, 137);
            this.rbtAugPaths.TabIndex = 7;
            this.rbtAugPaths.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Augmenting paths";
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "BFS",
            "DFS",
            "Fatest",
            "Thinnest"});
            this.cbMethod.Location = new System.Drawing.Point(527, 25);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(121, 21);
            this.cbMethod.TabIndex = 9;
            this.cbMethod.SelectedIndexChanged += new System.EventHandler(this.cbMethod_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Avg Time";
            // 
            // tbAvgTime
            // 
            this.tbAvgTime.Enabled = false;
            this.tbAvgTime.Location = new System.Drawing.Point(527, 65);
            this.tbAvgTime.Name = "tbAvgTime";
            this.tbAvgTime.Size = new System.Drawing.Size(173, 20);
            this.tbAvgTime.TabIndex = 10;
            // 
            // do1000
            // 
            this.do1000.Location = new System.Drawing.Point(416, 65);
            this.do1000.Name = "do1000";
            this.do1000.Size = new System.Drawing.Size(75, 23);
            this.do1000.TabIndex = 11;
            this.do1000.Text = "do 1000";
            this.do1000.UseVisualStyleBackColor = true;
            this.do1000.Click += new System.EventHandler(this.do1000_Click);
            // 
            // btnGlobal
            // 
            this.btnGlobal.Location = new System.Drawing.Point(416, 326);
            this.btnGlobal.Name = "btnGlobal";
            this.btnGlobal.Size = new System.Drawing.Size(108, 23);
            this.btnGlobal.TabIndex = 12;
            this.btnGlobal.Text = "Global";
            this.btnGlobal.UseVisualStyleBackColor = true;
            this.btnGlobal.Click += new System.EventHandler(this.btnGlobal_Click);
            // 
            // btnAllPaths
            // 
            this.btnAllPaths.Location = new System.Drawing.Point(416, 372);
            this.btnAllPaths.Name = "btnAllPaths";
            this.btnAllPaths.Size = new System.Drawing.Size(108, 23);
            this.btnAllPaths.TabIndex = 13;
            this.btnAllPaths.Text = "All Paths";
            this.btnAllPaths.UseVisualStyleBackColor = true;
            this.btnAllPaths.Click += new System.EventHandler(this.btnAllPaths_Click);
            // 
            // tbNoOfAugPaths
            // 
            this.tbNoOfAugPaths.Enabled = false;
            this.tbNoOfAugPaths.Location = new System.Drawing.Point(471, 206);
            this.tbNoOfAugPaths.Name = "tbNoOfAugPaths";
            this.tbNoOfAugPaths.Size = new System.Drawing.Size(50, 20);
            this.tbNoOfAugPaths.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 573);
            this.Controls.Add(this.btnAllPaths);
            this.Controls.Add(this.btnGlobal);
            this.Controls.Add(this.do1000);
            this.Controls.Add(this.tbNoOfAugPaths);
            this.Controls.Add(this.tbAvgTime);
            this.Controls.Add(this.cbMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbtAugPaths);
            this.Controls.Add(this.rtbMinCut);
            this.Controls.Add(this.btnMinCut);
            this.Controls.Add(this.tbMaxFlow);
            this.Controls.Add(this.rtbEdges);
            this.Controls.Add(this.tbNodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindMaxFlow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindMaxFlow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNodes;
        private System.Windows.Forms.RichTextBox rtbEdges;
        private System.Windows.Forms.TextBox tbMaxFlow;
        private System.Windows.Forms.Button btnMinCut;
        private System.Windows.Forms.RichTextBox rtbMinCut;
        private System.Windows.Forms.RichTextBox rbtAugPaths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAvgTime;
        private System.Windows.Forms.Button do1000;
        private System.Windows.Forms.Button btnGlobal;
        private System.Windows.Forms.Button btnAllPaths;
        private System.Windows.Forms.TextBox tbNoOfAugPaths;
    }
}

