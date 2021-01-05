// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}

public List<int> Preorder(Node root) {
    var result = new List<int>();
    if(root == null)
    {
        return result;
    }
    Stack<Node> stack = new Stack<Node>();
    stack.Push(root);
    while(stack.Count != 0)
    {
        var tempPop = stack.Pop();
        result.Add(tempPop.val);
        for(int i=tempPop.children.Count-1; i>=0; i--)
        {
            stack.Push(tempPop.children[i]);
        }           
    }
    return result;      
}