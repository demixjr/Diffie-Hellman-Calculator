using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiffieHellmanCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGroupOrder_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtP.Text, out long p) || p <= 1)
            {
                MessageBox.Show("Please enter a valid integer p > 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long groupOrder = Calculator.GetGroupOrder(p);
                string result = $"Group Order φ({p}) = {groupOrder}";

                if (long.TryParse(txtG.Text, out long g) && g > 0)
                {
                    long elemOrder = Calculator.GetElementOrder(g, p);
                    result += $"\r\nOrder of g ({g}) = {elemOrder}";
                }

                txtResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerators_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtP.Text, out long p) || p <= 1)
            {
                MessageBox.Show("Please enter a valid integer p > 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<long> generators = Calculator.GetGenerators(p);
                if (generators.Count == 0)
                {
                    txtResult.Text = $"No primitive root generators exist for p = {p}.";
                }
                else
                {
                    string listStr = generators.Count > 30
                        ? string.Join(", ", generators.GetRange(0, 30)) + "..."
                        : string.Join(", ", generators);

                    txtResult.Text = $"Generators for p = {p} (total {generators.Count}):\r\n{listStr}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalculateKey_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtP.Text, out long p) ||
                !long.TryParse(txtG.Text, out long g) ||
                !long.TryParse(txtA.Text, out long a) ||
                !long.TryParse(txtB.Text, out long b))
            {
                MessageBox.Show("Please enter valid integers for p, g, A, and B.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var (publicA, publicB, sharedKey) = Calculator.CalculateDiffieHellman(p, g, a, b);
                txtResult.Text = $"Public A (g^A mod p) = {publicA}\r\n" +
                                 $"Public B (g^B mod p) = {publicB}\r\n" +
                                 $"Shared Secret Key K = {sharedKey}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}