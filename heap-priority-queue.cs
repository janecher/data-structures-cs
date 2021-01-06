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

public class PriorityNode {
    public int val;
    public int priority;
    public left;
    public TreeNode right;
    public TreeNode(int val=0, int priority, TreeNode left=null, TreeNode right=null) {
        this.priority = priority;
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

2n+1 - left child
2n+2 - right child
(n-1)/2 - parent
*/

//in case of priority queue- dequeue and enqueue and comparing by priority!
public class MaxBinaryHeap {
    public List<Node> values;
    public MaxBinaryHeap() {
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

    public int ExtractMax()
    {
        int max = values[0];
        Swap(values, 0, values.Count-1);
        values.RemoveAt(rows.Count - 1);
        if(values.Count == 0)
        {
            return max;
        }
        int index = 0;
        while(index != -1 && index < values.Count)
        {
            int swap = -1;
            int left = index * 2 + 1;
            int right = index * 2 + 1;
            if(left < values.Count && values[index] < values[left])
            {
                swap = left;
            }
            if(right < values.Count && ((swap == -1 && values[index] < values[right]) 
                || (swap!= -1 && values[left] < values[right]))
            {
                swap = right;
            }
            if(swap == -1)
            {
                break;
            }
            Swap(values, swap, index);
            index = swap;
        }
        return max;
    }

    public void Swap(List<Node> list, int i, int j)
    {
        Node temp = list[j];
        list[j] = list[i];
        list[i] = temp;
    }
}
