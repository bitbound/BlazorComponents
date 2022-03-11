using BlazorComponents.Client.Components.TreeView;

namespace BlazorComponents.Client.Models
{
    public class TreeNode
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public TreeNodeType NodeType { get; set; }
        public string Name { get; init; } = "";
        public List<TreeNode> ChildItems { get; } = new();
    }
}
