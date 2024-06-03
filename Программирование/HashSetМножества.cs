using System;

public class Program
{
    public static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> set2 = new HashSet<int> { 1, 5, 6, 7, 6 };
        HashSet<int> set3 = new HashSet<int> { 1, 7, 8, 9, 10 };


        HashSet<int> intersection = Intersection(set1, set2, set3);
        HashSet<int> union = Union(set1, set2, set3);
        HashSet<int> complement1 = Complement(set1, union);
        HashSet<int> complement2 = Complement(set2, union);
        HashSet<int> complement3 = Complement(set3, union);

        Console.WriteLine("Множество_1: " + string.Join(", ", set1));
        Console.WriteLine("Множество_2: " + string.Join(", ", set2));
        Console.WriteLine("Множество_3: " + string.Join(", ", set3));
        Console.WriteLine("Пересечение множеств: " + string.Join(", ", intersection));
        Console.WriteLine("Объединение множеств: " + string.Join(", ", union));
        Console.WriteLine("Дополнение для set1: " + string.Join(", ", complement1));
        Console.WriteLine("Дополнение для set2: " + string.Join(", ", complement2));
        Console.WriteLine("Дополнение для set3: " + string.Join(", ", complement3));
    }

    public static HashSet<int> Intersection(HashSet<int> set1, HashSet<int> set2, HashSet<int> set3)
    {
        HashSet<int> intersection = new HashSet<int>(set1);
        intersection.IntersectWith(set2);
        intersection.IntersectWith(set3);
        return intersection;
    }

    public static HashSet<int> Union(HashSet<int> set1, HashSet<int> set2, HashSet<int> set3)
    {
        HashSet<int> union = new HashSet<int>(set1);
        union.UnionWith(set2);
        union.UnionWith(set3);
        return union;
    }
    public static HashSet<int> Complement(HashSet<int> set, HashSet<int> unionSet)
    {
        HashSet<int> complement = new HashSet<int>(unionSet);
        complement.ExceptWith(set);
        return complement;
    }
}
