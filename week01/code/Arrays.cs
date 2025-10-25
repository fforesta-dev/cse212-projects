public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN FOR MultiplesOf
        // 1. Create a new array of size 'length'.
        // 2. Loop from i = 0 to i < length.
        // 3. For each i, calculate the i-th multiple: number * (i + 1).
        // 4. Store that value in the array at position i.
        // 5. After the loop, return the array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN FOR RotateListRight
        // 1. Find how many elements to move from the end to the beginning.
        // 2. Use GetRange() to copy the last 'amount' elements into a new list called 'end'.
        // 3. Remove those last 'amount' elements from the original list using RemoveRange().
        // 4. Insert the 'end' list at index 0 using InsertRange().
        // 5. The list is now rotated to the right by 'amount'.

        int count = data.Count;
        if (amount <= 0 || amount % count == 0) return;

        List<int> end = data.GetRange(count - amount, amount);
        data.RemoveRange(count - amount, amount);
        data.InsertRange(0, end);
    }
}
