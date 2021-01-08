/*
Definition for a heap class.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node(int val=0, Node left=null, Node right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class PriorityNode {
    public int val;
    public int priority;
    public PriorityNode left;
    public PriorityNode right;
    public PriorityNode(int val=0, int priority, PriorityNode left=null, PriorityNode right=null) {
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

//in case of priority queue- dequeue and enqueue instead of extractMax and insert, 
//and comparing by priority!
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
            //priority queue - .priority
            if(values[parent].val > values[index].val)
            {
                break;
            }
            Swap(values, parent, index);
            index = parent;
        }
    }

    public Node ExtractMax()
    {
        if(values.Count == 0)
        {
            return null;
        }
        Node max = values[0];
        Swap(values, 0, values.Count-1);
        values.RemoveAt(values.Count - 1);
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
            //priority queue - .priority
            if(left < values.Count && values[index].val < values[left].val)
            {
                swap = left;
            }
            if(right < values.Count && ((swap == -1 && values[index].val < values[right].val) 
                || (swap!= -1 && values[left].val < values[right].val))
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
