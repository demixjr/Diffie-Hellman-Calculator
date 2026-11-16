namespace DiffieHellmanCalculator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblP = new Label();
            lblG = new Label();
            lblA = new Label();
            lblB = new Label();
            lblResult = new Label();
            txtP = new TextBox();
            txtG = new TextBox();
            txtA = new TextBox();
            txtB = new TextBox();
            txtResult = new TextBox();
            btnGroupOrder = new Button();
            btnGenerators = new Button();
            btnCalculateKey = new Button();
            SuspendLayout();
            // 
            // lblP
            // 
            lblP.AutoSize = true;
            lblP.Location = new Point(15, 25);
            lblP.Name = "lblP";
            lblP.Size = new Size(105, 20);
            lblP.TabIndex = 0;
            lblP.Text = "Prime mod p =";
            // 
            // lblG
            // 
            lblG.AutoSize = true;
            lblG.Location = new Point(15, 65);
            lblG.Name = "lblG";
            lblG.Size = new Size(96, 20);
            lblG.TabIndex = 2;
            lblG.Text = "Generator g =";
            // 
            // lblA
            // 
            lblA.AutoSize = true;
            lblA.Location = new Point(15, 105);
            lblA.Name = "lblA";
            lblA.Size = new Size(78, 20);
            lblA.TabIndex = 4;
            lblA.Text = "Secret A =";
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Location = new Point(15, 145);
            lblB.Name = "lblB";
            lblB.Size = new Size(77, 20);
            lblB.TabIndex = 6;
            lblB.Text = "Secret B =";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResult.Location = new Point(15, 190);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(57, 20);
            lblResult.TabIndex = 10;
            lblResult.Text = "Result:";
            // 
            // txtP
            // 
            txtP.Location = new Point(135, 22);
            txtP.Name = "txtP";
            txtP.Size = new Size(115, 27);
            txtP.TabIndex = 1;
            // 
            // txtG
            // 
            txtG.Location = new Point(135, 62);
            txtG.Name = "txtG";
            txtG.Size = new Size(115, 27);
            txtG.TabIndex = 3;
            // 
            // txtA
            // 
            txtA.Location = new Point(135, 102);
            txtA.Name = "txtA";
            txtA.Size = new Size(115, 27);
            txtA.TabIndex = 5;
            // 
            // txtB
            // 
            txtB.Location = new Point(135, 142);
            txtB.Name = "txtB";
            txtB.Size = new Size(115, 27);
            txtB.TabIndex = 7;
            // 
            // txtResult
            // 
            txtResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtResult.Location = new Point(15, 215);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(395, 75);
            txtResult.TabIndex = 11;
            // 
            // btnGroupOrder
            // 
            btnGroupOrder.Location = new Point(275, 22);
            btnGroupOrder.Name = "btnGroupOrder";
            btnGroupOrder.Size = new Size(135, 35);
            btnGroupOrder.TabIndex = 8;
            btnGroupOrder.Text = "Group Order";
            btnGroupOrder.UseVisualStyleBackColor = true;
            btnGroupOrder.Click += btnGroupOrder_Click;
            // 
            // btnGenerators
            // 
            btnGenerators.Location = new Point(275, 72);
            btnGenerators.Name = "btnGenerators";
            btnGenerators.Size = new Size(135, 35);
            btnGenerators.TabIndex = 9;
            btnGenerators.Text = "Generators (for p)";
            btnGenerators.UseVisualStyleBackColor = true;
            btnGenerators.Click += btnGenerators_Click;
            // 
            // btnCalculateKey
            // 
            btnCalculateKey.Location = new Point(275, 122);
            btnCalculateKey.Name = "btnCalculateKey";
            btnCalculateKey.Size = new Size(135, 45);
            btnCalculateKey.TabIndex = 10;
            btnCalculateKey.Text = "Calculate Key";
            btnCalculateKey.UseVisualStyleBackColor = true;
            btnCalculateKey.Click += btnCalculateKey_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(428, 308);
            Controls.Add(lblP);
            Controls.Add(txtP);
            Controls.Add(lblG);
            Controls.Add(txtG);
            Controls.Add(lblA);
            Controls.Add(txtA);
            Controls.Add(lblB);
            Controls.Add(txtB);
            Controls.Add(btnGroupOrder);
            Controls.Add(btnGenerators);
            Controls.Add(btnCalculateKey);
            Controls.Add(lblResult);
            Controls.Add(txtResult);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diffie-Hellman Key Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblP;
        private Label lblG;
        private Label lblA;
        private Label lblB;
        private Label lblResult;
        private TextBox txtP;
        private TextBox txtG;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtResult;
        private Button btnGroupOrder;
        private Button btnGenerators;
        private Button btnCalculateKey;
    }
}