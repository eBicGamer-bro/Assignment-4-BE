namespace Assignment_4
{
    internal class Program
    {

        static public int[] TwoSum(int[] nums, int target)
        {
            var temp = new Dictionary<int, int>();
            int value;
            for (int i = 0; i < nums.Length; i++)
            {
                value = target - nums[i];
                if (temp.ContainsKey(value))
                    return new int[] { temp.GetValueOrDefault(value), i };
                else if (!temp.ContainsKey(nums[i]))
                    temp.Add(nums[i], i);

            }
            return new int[0];
        }
        static void Main(string[] args)
        {
            var result = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            Console.WriteLine($"[{result[0]}, {result[1]}]");
        }
    }
}

    

