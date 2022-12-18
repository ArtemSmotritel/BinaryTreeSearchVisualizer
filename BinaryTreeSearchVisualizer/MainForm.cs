using BinaryTreeSearchVisualizer.src;
using BinaryTreeSearchVisualizer.src.ApplicationTree;

namespace BinaryTreeSearchVisualizer
{
    public partial class MainForm : Form
    {
        private BinaryTree binaryTree;
        private FormEventHandler formEventHandler;

        public MainForm()
        {
            InitializeComponent();
            binaryTree = new BinaryTree();
            formEventHandler = new FormEventHandler(
                drawBox, insertTextBox, removeTextBox, findTextBox,
                findKElementTextBox, messageLabel, binaryTree
            );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            HandleInsert();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            HandleRemove();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            HandleFind();
        }

        private void findKElementButton_Click(object sender, EventArgs e)
        {
            HandleFindKElement();
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
            textBox.Focus();
        }

        private void drawBox_Paint(object sender, PaintEventArgs e)
        {
            drawBox.DrawTree(binaryTree, e.Graphics);
        }

        private void insertTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                HandleInsert();
            }
        }

        private void HandleInsert()
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

        private void HandleRemove()
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

        private void HandleFind()
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(findTextBox);
            if (okay)
            {

            }
            RefreshTextBox(findTextBox);
        }

        private void HandleFindKElement()
        {
            ResetAndHideMessageLabel();
            var okay = ValidateInput(findKElementTextBox);
            if (okay)
            {

            }
            RefreshTextBox(findKElementTextBox);
        }

        private void removeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                HandleRemove();
            }
        }

        private void findTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                HandleFind();
            }
        }

        private void findKElementTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                HandleFindKElement();
            }
        }
    }
}
