namespace Leetcode;

public static class Extensions
{
    public static TreeNode? ToTree(this string? input)
    {
        if (input == null)
            return null;

        if (input[0] == '[')
            input = input.Substring(1, input.Length - 2);
        var vals = input
            .Split(',')
            .Select(val => val == "null" ? (int?)null : int.Parse(val))
            .ToArray();
        return vals.ToTree();
    }

    public static TreeNode? ToTree(this int?[]? input)
    {
        if (input == null || input.Length == 0 || input[0] == null)
            return null;
        var levelQueue = new Queue<TreeNode>();
        var nextLevelQueue = new Queue<TreeNode>();
        var current = new TreeNode(input[0]!.Value);
        var tree = current;
        for (var i = 1; i < input.Length;)
        {
            for (var leaf = 0; leaf < 2 && i < input.Length; leaf++)
            {
                var node = input[i] switch
                {
                    null => null,
                    _ => new TreeNode(input[i]!.Value)
                };
                i++;
                if (node == null)
                {
                    continue;
                }

                switch (leaf)
                {
                    case 0:
                        current.left = node;
                        break;
                    case 1:
                        current.right = node;
                        break;
                }

                nextLevelQueue.Enqueue(node);
            }

            if (!levelQueue.Any())
            {
                levelQueue = nextLevelQueue;
                nextLevelQueue = new Queue<TreeNode>();
            }

            current = levelQueue.Dequeue();
        }

        return tree;
    }
}