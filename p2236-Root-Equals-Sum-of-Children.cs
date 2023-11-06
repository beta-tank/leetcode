namespace Leetcode;

/// <summary>
/// https://leetcode.com/problems/root-equals-sum-of-children/description/
/// </summary>
public class p2236_Root_Equals_Sum_of_Children
{
    public bool CheckTree(TreeNode root) =>
        root.val == root.left!.val + root.right!.val;

    [TestCase("[10,4,6]", true)]
    [TestCase("[5,3,1]", false)]
    public void Test(string input, bool result)
    {
        var tree = input.ToTree();
        CheckTree(tree!).Should().Be(result);
    }
}