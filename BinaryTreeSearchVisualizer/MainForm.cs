using BinaryTreeSearchVisualizer.src;
using BinaryTreeSearchVisualizer.src.ApplicationTree;

namespace BinaryTreeSearchVisualizer
{
    public partial class MainForm : Form
    {
        private BinaryTree binaryTree;

        public MainForm()
        {
            InitializeComponent();
            binaryTree = new BinaryTree();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(insertTextBox);
            if (okay)
            {
                var value = long.Parse(insertTextBox.Text);
                binaryTree.Insert(value);
                PaintTree();
            }
            RefreshTextBox(insertTextBox);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(removeTextBox);
            if (okay)
            {
                var value = long.Parse(removeTextBox.Text);
                binaryTree.Remove(value);
                PaintTree();
            }
            RefreshTextBox(removeTextBox);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(findTextBox);
            if (okay)
            {
                textBox1.Text += " simple_found ";
            }
            RefreshTextBox(findTextBox);
        }

        private void findKElementButton_Click(object sender, EventArgs e)
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(findKElementTextBox);
            if (okay)
            {
                textBox1.Text += " foundK ";
                RefreshTextBox(findKElementTextBox);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            binaryTree = new BinaryTree();
            PaintTree();
        }

        private void PaintTree()
        {
            drawBox.Invalidate(true);
        }

        private bool ValidateInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                messageLabel.Text = "Input cannot be empty";
                messageLabel.BackColor = Color.IndianRed;
                textBox.BackColor = Color.IndianRed;
                messageLabel.Show();
                return false;
            }
            if (!long.TryParse(textBox.Text, out long result))
            {
                messageLabel.Text = "Input cannot contain non-numeric symbols";
                messageLabel.BackColor = Color.IndianRed;
                textBox.BackColor = Color.IndianRed;
                messageLabel.Show();
                return false;
            }

            return true;
        }

        private void ResetAndHideMessageLabel()
        {
            messageLabel.Text = "";
            messageLabel.BackColor = BackColor;
            messageLabel.Hide();
        }

        private void RefreshTextBox(TextBox textBox)
        {
            textBox.Text = "";
            textBox.BackColor = Color.White;
        }

        private void drawBox_Paint(object sender, PaintEventArgs e)
        {
            drawBox.DrawTree(binaryTree, e.Graphics);
        }
    }
}
