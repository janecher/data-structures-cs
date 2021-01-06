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

public bool HasPathSum(TreeNode root, int sum) {
    if (root == null) {
        return false;
    }
    else 
    {
        int result = root.val;
        bool answer = false;
        if(result == sum && root.left == null && root.right == null)
        {
            return true;
        }
        if(root.left != null)
        {
            answer = answer || HasPathSum(root.left, sum - result);
        }
        if(root.right != null)
        {
            answer =  answer || HasPathSum(root.right, sum - result);;
        }
        return answer;
    }
}

public bool IsSymmetric(TreeNode root) {
    return isMirror(root, root);
}

public bool isMirror(TreeNode left, TreeNode right)
{
    if(left == null && right == null)
    {
        return true;
    }
    if(left == null || right == null)
    {
        return false;
    }
    return (left.val == right.val) && isMirror(left.right, right.left) && isMirror(left.left, right.right);
}

public int Depth(TreeNode root) {
    if(root == null)
    {
        return 0;
    }
    return 1 + Math.Max(Depth(root.left), Depth(root.right));
}

public List<int> InorderTraversal(TreeNode root) {
    List<int> result = new List<int>();
    if(root == null)
    {
        return result;
    }
    result.AddRange(InorderTraversal(root.left));
    result.Add(root.val);
    result.AddRange(InorderTraversal(root.right));
    return result;      
}