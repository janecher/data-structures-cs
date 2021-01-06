/*
Definition for a heap class.
public class Node {
    public int val;
    public left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

2n+1 - left child
2n+2 - right child
(n-1)/2 - parent

public class MaxHeap {
    public List<Node> values;
    public MaxHeap() {
        values = new List<Node>();
    }
}
*/

public class MaxHeap {
    public List<Node> values;
    public MaxHeap() {
        values = new List<Node>();
    }

    public void Insert(Node newnode) 
    {
        values.Add(newnode);
        int index = values.Count - 1;
        while(index >= 0)
        {
            int parent = (index - 1)/2;
            if(values[parent] > values[index])
            {
                break;
            }
            Swap(values, parent, index);
            index = parent;
        }
    }

    public void Swap(List<Node> list, int i, int j)
    {
        Node temp = list[j];
        list[j] = list[i];
        list[i] = temp;
    }
}
