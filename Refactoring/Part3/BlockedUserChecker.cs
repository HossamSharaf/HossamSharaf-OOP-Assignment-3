using System.Diagnostics;


namespace RefactoringLab.Part03.BlockedUsers;

public static class BlockedUserChecker
{
    public static int CountBlocked(List<int> blockedIds, int[] requestIds)
    {
        // حولنا الـ List لـ HashSet عشان البحث يبقى O(1) بدل O(N)
        var blockedSet = new HashSet<int>(blockedIds);

        var blocked = 0;
        foreach (var id in requestIds)
        {
            if (blockedSet.Contains(id))
                blocked++;
        }
        return blocked;
    }

    // باقي دوال الكلاس تفضل زي ما هي بدون تغيير
    public static List<int> BuildBlockedIds(int count)
    {
        var list = new List<int>(count);
        for (var i = 0; i < count; i++)
            list.Add(i);
        return list;
    }

    public static int[] BuildRequestIds(int count, int maxId, int seed = 42)
    {
        var rnd = new Random(seed);
        var ids = new int[count];
        for (var i = 0; i < count; i++)
            ids[i] = rnd.Next(maxId);
        return ids;
    }

    public static long MeasureMs(List<int> blockedIds, int[] requestIds, out int found)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        found = CountBlocked(blockedIds, requestIds);
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
}
