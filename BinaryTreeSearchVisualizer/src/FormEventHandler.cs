using BinaryTreeSearchVisualizer.src.ApplicationTree;

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
                drawBox.HideLastHighlight();
                drawBox.DrawPath(binaryTree, value, Color.Green, Color.Green);
                binaryTree.Insert(value);
                TriggerTreePaint();
            }
            catch (Exception)
            {

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
                drawBox.HideLastHighlight();
                drawBox.DrawPath(binaryTree, value, Color.Red, Color.Green);
                binaryTree.Remove(value);
                drawBox.lastHighlightedNode= null;
                TriggerTreePaint();
            }
            catch (Exception)
            {

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
                drawBox.HideLastHighlight();
                drawBox.DrawPath(binaryTree, value, Color.Green, Color.Red);
            }
            catch (Exception)
            {

            }
            RefreshTextBox(findTextBox);
        }

        public void HandleFindKElement()
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(findKElementTextBox);
            }
            catch (Exception)
            {

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
                messageLabel.Text = "Input cannot be empty";
                messageLabel.BackColor = Color.IndianRed;
                textBox.BackColor = Color.IndianRed;
                messageLabel.Show();
                throw new Exception("");
            }
            if (!long.TryParse(textBox.Text.Trim(), out long result))
            {
                messageLabel.Text = "Input cannot contain non-numeric symbols";
                messageLabel.BackColor = Color.IndianRed;
                textBox.BackColor = Color.IndianRed;
                messageLabel.Show();
                throw new Exception("");
            }
        }
    }
}
