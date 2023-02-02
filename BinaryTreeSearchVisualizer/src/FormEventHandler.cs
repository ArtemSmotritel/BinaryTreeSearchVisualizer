using BinaryTreeSearchVisualizer.properties;
using BinaryTreeSearchVisualizer.src.ApplicationTree;
using BinaryTreeSearchVisualizer.src.Components;

namespace BinaryTreeSearchVisualizer.src
{
    internal class FormEventHandler
    {
        private DrawBox drawBox;
        private Label messageLabel;
        public BinarySearchTree tree;

        public FormEventHandler(
            DrawBox drawBox,
            Label messageLabel,
            BinarySearchTree tree
            )
        {
            this.drawBox = drawBox;
            this.messageLabel = messageLabel;
            this.tree = tree;
        }

        public static void ScrollCenter(Panel p)
        {
            using (Control c = new Control() { Parent = p, Height = 0, Left = VisualizerProperty.rootCenter.X + p.Parent.Width / 2 - p.HorizontalScroll.Value })
            {
                p.ScrollControlIntoView(c);
            }
        }

        public void HandleInsert(TextBox insertTextBox)
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(insertTextBox);
                var value = long.Parse(insertTextBox.Text);
                drawBox.DrawPath(tree, value, VisualizerProperty.findInsertColor, VisualizerProperty.missingInsertColor);
                tree.Insert(value);
                Thread.Sleep(VisualizerProperty.timeGap);
                TriggerTreePaint();
            }
            catch (Exception e)
            {
                HandleException(e, insertTextBox);
            }
            RefreshTextBox(insertTextBox);
        }

        public void HandleRemove(TextBox removeTextBox)
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(removeTextBox);
                var value = long.Parse(removeTextBox.Text);
                drawBox.DrawPath(tree, value, VisualizerProperty.findRemoveColor, VisualizerProperty.missingRemoveColor);
                tree.Remove(value);
                Thread.Sleep(VisualizerProperty.timeGap);
                TriggerTreePaint();
            }
            catch (Exception e)
            {
                HandleException(e, removeTextBox);
            }
            RefreshTextBox(removeTextBox);
        }

        public void HandleFind(TextBox findTextBox)
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(findTextBox);
                var value = long.Parse(findTextBox.Text);
                drawBox.DrawPath(tree, value, VisualizerProperty.findFindColor, VisualizerProperty.missingFindColor);
            }
            catch (Exception e) 
            { 
                HandleException(e, findTextBox); 
            }
            RefreshTextBox(findTextBox);
        }

        public void HandleFindKElement(TextBox findKElementTextBox)
        {
            ResetAndHideMessageLabel();
            try
            {
                ValidateInput(findKElementTextBox);
                var value = long.Parse(findKElementTextBox.Text);
                drawBox.DrawFindKthElementPath(tree, value);
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
        private void HandleException(Exception exception, TextBox textBox)
        {
            var message = exception.Message;
            messageLabel.Text = message;
            messageLabel.BackColor = Color.IndianRed;
            textBox.BackColor = Color.IndianRed;
            messageLabel.Show();
        }

        private static void RefreshTextBox(TextBox textBox)
        {
            textBox.Text = "";
            textBox.BackColor = Color.White;
            textBox.Focus();
        }
        private static void ValidateInput(TextBox textBox)
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
    }
}
