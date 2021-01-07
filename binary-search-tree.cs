/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public bool IsValidBST(TreeNode root) {
    int min = Int32.MinValue;
    int max = Int32.MaxValue;
    return IsValidBSTBound(root, min, max);      
}

public bool IsValidBSTBound(TreeNode root, int min, int max)
{
    return (root == null) || 
            (min <= max && root.val >= min && root.val <= max && 
            IsValidBSTBound(root.left, min, root.val - 1) && 
            IsValidBSTBound(root.right, root.val + 1, max)); 
}

public TreeNode SearchBST(TreeNode root, int val) {
    if(root == null)
    {
        return null;
    }
    if(root!= null && root.val == val)
    {
        return root;
    }
    else if(root.val < val)
    {
        return SearchBST(root.right, val);
    }
    else
    {
        return SearchBST(root.left, val);
    }    
}

public TreeNode InsertIntoBST(TreeNode root, int val) {
    TreeNode newNode = new TreeNode(val);
    if(root == null)
    {
        root = newNode;
        return root;
    }
    else
    {
        TreeNode temp = root;
        while(true)
        {
            if(temp.val < val)
            {
                if(temp.right == null)
                {
                    temp.right = newNode;
                    return root;                   
                }
                else
                {
                    temp = temp.right;
                }
            }
            else if(temp.val > val)
            {
                if(temp.left == null)
                {
                    temp.left = newNode; 
                    return root;
                }
                else
                {
                    temp = temp.left;
                }
            }
            else
            {
                return root;
            }
        }
    }
}

public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    if(root == null)
    {
        return null;
    }
    TreeNode temp = root;
    while(temp != null)
    {
        if(temp.val < p.val && temp.val < q.val)
        {
            temp = temp.right;
        }
        else if(temp.val > p.val && temp.val > q.val)
        {
            temp = temp.left;
        }
        else
        {
            return temp;
        }
    }
    return null;
}

public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
    for(int i = 0; i < nums.Length-k; i++)
    {
        int[] temp = new int[k];
        int a = 0;
        for(int j = i; j < i+k; j++)
        {
            temp[a] = nums[j];
        }
        Array.Sort(temp);
        for(int j = 0; j < temp.Length-1; j++)
        {
            int first = temp[j];
            int secondIndex = BinarySearch(temp, Math.Abs(first-t), j+1);
            if(secondIndex != -1)
            {
                return true;
            }
        }           
    }
    return false;
}

public int BinarySearch(int[] array, int value, int start)
{
    int last = array.Length -1;
    while(start<=last)
    {
        int middle = (start + last) / 2;
        if(array[middle] == value)
        {
            return middle;
        }
        else if(array[middle] < value)
        {
            start = middle + 1;
        }
        else
        {
            last = middle -1;
        }
    }
    return -1;
}

public bool IsBalanced(TreeNode root) {
    if(root == null || (root.left == null && root.right == null))
    {
        return true;
    }
    return Math.Abs(Height(root.left) - Height(root.right)) < 2 && IsBalanced(root.left) && IsBalanced(root.right);
}
public int Height(TreeNode root)
{
    if(root == null)
    {
        return 0;
    }
    if(root.left == null && root.right == null)
    {
        return 1;
    }
    return 1 + Math.Max(Height(root.left), Height(root.right));
}