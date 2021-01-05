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

public List<int> PreorderRecursive(Node root) {
    var result = new List<int>();
    Helper(root, result);
    return result;
}

public void Helper(Node root, List<int> list)
{
    if(root == null)
    {
        return;
    }
    list.Add(root.val);
    if(root.children != null)
    {
        foreach(var child in root.children)
        {
            Helper(child, list);
        }
    } 
}

public List<int> Postorder(Node root) {
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
        foreach(var child in tempPop.children)
        {
            stack.Push(child);
        }           
    }
    result.Reverse();
    return result;
}