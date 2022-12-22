using BinaryTreeSearchVisualizer.src.ApplicationTree;
using BinaryTreeSearchVisualizer.src.Components;

namespace BinaryTreeSearchVisualizer.src
{
    internal class FormEventHandler
    {
        private DrawBox drawBox;
        private TextBox insertTextBox;
        private TextBox removeTextBox;
        private TextBox findTextBox;
        private TextBox findKElementTextBox;
        private Label messageLabel;
        public BinaryTree binaryTree;

        public FormEventHandler(
            DrawBox drawBox,
            TextBox insertTextBox,
            TextBox removeTextBox,
            TextBox findTextBox,
            TextBox findKElementTextBox,
            Label messageLabel,
            BinaryTree binaryTree
            )
        {
            this.drawBox = drawBox;
            this.insertTextBox = insertTextBox;
            this.removeTextBox = removeTextBox;
            this.findTextBox = findTextBox;
            this.findKElementTextBox = findKElementTextBox;
            this.messageLabel = messageLabel;
            this.binaryTree = binaryTree;
        }

        public void HandleInsert()
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(insertTextBox);
                var value = long.Parse(insertTextBox.Text);
                drawBox.DrawInsertPath(binaryTree, value);
                binaryTree.Insert(value);
                TriggerTreePaint();
            }
            catch (Exception e)
            {
                HandleException(e, insertTextBox);
            }
            RefreshTextBox(insertTextBox);
        }

        public void HandleRemove()
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(removeTextBox);
                var value = long.Parse(removeTextBox.Text);
                drawBox.DrawRemovePath(binaryTree, value);
                binaryTree.Remove(value);
                TriggerTreePaint();
            }
            catch (Exception e)
            {
                HandleException(e, removeTextBox);
            }
            RefreshTextBox(removeTextBox);
        }

        public void HandleFind()
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(findTextBox);
                var value = long.Parse(findTextBox.Text);
                drawBox.DrawFindPath(binaryTree, value);
            }
            catch (Exception e) 
            { 
                HandleException(e, findTextBox); 
            }
            RefreshTextBox(findTextBox);
        }

        public void HandleFindKElement()
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(findKElementTextBox);
                var value = long.Parse(findKElementTextBox.Text);
                drawBox.DrawFindKthElementPath(binaryTree, value);
            }
            catch (Exception e)
            {
                HandleException(e, findKElementTextBox);
            }
            RefreshTextBox(findKElementTextBox);
        }

        public void TriggerTreePaint() => drawBox.Invalidate(true);
        private void ResetAndHideMessageLabel()
        {
            messageLabel.Text = "";
            messageLabel.BackColor = Color.White;
            messageLabel.Hide();
        }
        private static void RefreshTextBox(TextBox textBox)
        {
            textBox.Text = "";
            textBox.BackColor = Color.White;
            textBox.Focus();
        }
        private void ValidateInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                throw new Exception($"The {textBox.Name.Split('T')[0]} input cannot be empty");
            }
            if (!long.TryParse(textBox.Text.Trim(), out long result))
            {
                throw new Exception($"The {textBox.Name.Split('T')[0]} input cannot containt non-digit characters");
            }
        }
        private void HandleException(Exception exception, TextBox textBox)
        {
            var message = exception.Message;
            messageLabel.Text = message;
            messageLabel.BackColor = Color.IndianRed;
            textBox.BackColor = Color.IndianRed;
            messageLabel.Show();
        }
    }
}
