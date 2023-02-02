using BinaryTreeSearchVisualizer.src;
using BinaryTreeSearchVisualizer.src.ApplicationTree;

namespace BinaryTreeSearchVisualizer
{
    public partial class MainForm : Form
    {
        private BinarySearchTree tree;
        private FormEventHandler formEventHandler;

        public MainForm()
        {
            InitializeComponent();
            tree = new BinarySearchTree();
            formEventHandler = new FormEventHandler(
                drawBox, messageLabel, tree
            );
            FormEventHandler.ScrollCenter(panelForDrawBox);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ActiveControl = insertTextBox;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            formEventHandler.HandleInsert(insertTextBox);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            formEventHandler.HandleRemove(removeTextBox);
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            formEventHandler.HandleFind(findTextBox);
        }

        private void findKElementButton_Click(object sender, EventArgs e)
        {   
            formEventHandler.HandleFindKElement(findKElementTextBox);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            tree = new BinarySearchTree();
            formEventHandler.tree = tree;
            drawBox.lastHighlightedNode = null;
            formEventHandler.TriggerTreePaint();
            FormEventHandler.ScrollCenter(panelForDrawBox);
        }

        private void drawBox_Paint(object sender, PaintEventArgs e)
        {
            drawBox.DrawTree(tree, e.Graphics);
        }

        private void insertTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
                formEventHandler.HandleInsert(insertTextBox);
            }
        }

        private void removeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
                formEventHandler.HandleRemove(removeTextBox);
            }
        }

        private void findTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
                formEventHandler.HandleFind(findTextBox);
            }
        }

        private void findKElementTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                e.Handled = true;
                formEventHandler.HandleFindKElement(findKElementTextBox);
            }
        }

    }
}
