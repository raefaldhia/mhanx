namespace Mhanxx
{
    partial class TreeView
    {
        private static class Event
        {
            private static TreeView treeView;

            public static void Register(TreeView view)
            {
                treeView = view;
            }

        }
    }
}
