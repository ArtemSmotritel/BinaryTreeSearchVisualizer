using BinaryTreeSearchVisualizer.src.ApplicationTree;

namespace BinaryTreeSearchVisualizer.src
{
    internal static class GraphicUtils
    {
        public static Pen TreeNodePen()
        {
            return new Pen(Color.Black, 4);
        }

        public static Pen ConnectionPen()
        {   
            return new Pen(Color.Black, 2);
        }

        public static Font TreeNodeContentFont()
        {
            return SystemFonts.DefaultFont;
        }

        public static void DrawNode(NodeInfo nodeInfo, Graphics graphics)
        {
            DrawNodeCircle(nodeInfo, graphics);
            DrawNumber(nodeInfo, graphics);
        }

        public static void DrawNodeCircle(NodeInfo nodeInfo, Graphics graphics)
        {
            int xTopLeft = nodeInfo.CenterX - nodeInfo.Radius;
            int yTopLeft = nodeInfo.CenterY - nodeInfo.Radius;
            int diameter = nodeInfo.Radius * 2;
            graphics.FillEllipse(Brushes.AntiqueWhite, xTopLeft, yTopLeft, diameter, diameter);
            graphics.DrawEllipse(TreeNodePen(), xTopLeft, yTopLeft, diameter, diameter);
        }

        public static void DrawNumber(NodeInfo nodeInfo, Graphics graphics)
        {
            graphics.DrawString(nodeInfo.Node.Value.ToString() + " " + nodeInfo.Node.Size, TreeNodeContentFont(), Brushes.Black,
                new Point(nodeInfo.CenterX - 12, nodeInfo.CenterY - 7));
        }

        public static void DrawConnectionToParent(NodeInfo nodeInfo, Graphics graphics)
        {
            if (nodeInfo.ParentNodeInfo != null)
            {
                graphics.DrawLine(ConnectionPen(),
                nodeInfo.CenterX, nodeInfo.CenterY,
                nodeInfo.ParentNodeInfo.CenterX, nodeInfo.ParentNodeInfo.CenterY
                );
            }
        }
    }
}
