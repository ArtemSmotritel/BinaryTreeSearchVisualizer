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
            int xTopLeft = nodeInfo.CenterX - nodeInfo.Radius;
            int yTopLeft = nodeInfo.CenterY - nodeInfo.Radius;
            int diameter = nodeInfo.Radius * 2;
            graphics.DrawEllipse(TreeNodePen(), xTopLeft, yTopLeft, diameter, diameter);
            DrawNumber(nodeInfo, graphics);
        }

        public static void DrawNumber(NodeInfo nodeInfo, Graphics graphics)
        {
            graphics.DrawString(nodeInfo.Node.Value.ToString(), TreeNodeContentFont(), Brushes.Black,
                new Point(nodeInfo.CenterX - 12, nodeInfo.CenterY - 7));
        }

        public static void DrawConnection(NodeInfo n1, NodeInfo n2, Graphics graphics)
        {
            graphics.DrawLine(ConnectionPen(),
                n1.CenterX, n1.CenterY,
                n2.CenterX, n2.CenterY);
        }
    }
}
