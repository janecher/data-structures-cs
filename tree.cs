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

public List<int> PreorderRecursive(Node root) {
    var result = new List<int>();
    PreHelper(root, result);
    return result;
}

public void PreHelper(Node root, List<int> list)
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
            PreHelper(child, list);
        }
    } 
}

public List<int> PostorderRecursive(Node root) {
    var result = new List<int>();
    PostHelper(root, result);
    return result;
}

public void PostHelper(Node root, List<int> list)
{
    if(root == null)
    {
        return;
    }
    if(root.children != null)
    {
        foreach(var child in root.children)
        {
            PostHelper(child, list);
        }
    }
    list.Add(root.val);
}

public IList<IList<int>> LevelOrder(Node root) {
    var result = new List<IList<int>>();
    if(root == null)
    {
        return result;
    }
    Queue<Node> queue = new Queue<Node>();
    queue.Enqueue(root);
    while(queue.Any())
    {
        var size = queue.Count;

        var tempList = new List<int>();
        for (int s = 0; s < size; s++) {
            var cur = queue.Dequeue();
            tempList.Add(cur.val);

            foreach (var child in cur.children) {
                queue.Enqueue(child);
            }
        }
        result.Add(tempList);
    }
    return result;
}

public int MaxDepth(Node root) {
    if(root == null)
    {
        return 0;
    }
    int depth = 1;
    foreach(var child in root.children)
    {
        depth = Math.Max(depth, MaxDepth(child) + 1);
    }
    return depth;
}