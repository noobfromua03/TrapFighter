using System;
using System.Collections.Generic;
using System.Linq;

namespace FVN.Helpers
{
    public static class ListExtensions
    {
        public static List<T> With<T>(this List<T> list, List<T> range)
        {
            list.AddRange(range);
            return list;
        }

        public static bool IsNullOrEmpty<T>(this IList<T> value)
        {
            if (value != null)
            {
                return value.Count == 0;
            }

            return true;
        }

        public static T FirstOrNull<T>(this IEnumerable<T> values, Func<T, bool> predicate) where T : class
        {
            return values.DefaultIfEmpty(null).FirstOrDefault(predicate);
        }
        public static T LastOrNull<T>(this IEnumerable<T> values, Func<T, bool> predicate) where T : class
        {
            return values.DefaultIfEmpty(null).LastOrDefault(predicate);
        }

        public static T[] Shuffle<T>(this T[] array)
        {
            if (array.IsNullOrEmpty() || array.Length == 1) return array;
            for (int i = 0; i < array.Length; i++)
            {
                int indexRand = UnityEngine.Random.Range(0, array.Length);
                (array[i], array[indexRand]) = (array[indexRand], array[i]);
            }
            return array;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty() || list.Count == 1) return list;
            for (int i = 0; i < list.Count; i++)
            {
                int indexRand = UnityEngine.Random.Range(0, list.Count);
                (list[i], list[indexRand]) = (list[indexRand], list[i]);
            }
            return list;
        }

        public static T GetRandomElement<T>(this List<T> value)
        {
            return value[UnityEngine.Random.Range(0, value.Count)];
        }

        public static T Peek<T>(this List<T> list)
        {
            if (list.Count > 0)
            {
                return list[list.Count - 1];
            }
            else
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }

        public static T Pop<T>(this List<T> list)
        {
            if (list.Count > 0)
            {
                int lastIndex = list.Count - 1;
                T item = list[lastIndex];
                list.RemoveAt(lastIndex);
                return item;
            }
            else
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }

        public static void MoveIndex<T>(this List<T> list, int oldIndex, int newIndex)
        {
            if (oldIndex < 0 || oldIndex >= list.Count)
            {
                throw new IndexOutOfRangeException("Old index is out of range.");
            }
            if (newIndex < 0 || newIndex >= list.Count)
            {
                throw new IndexOutOfRangeException("New index is out of range.");
            }

            T item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }
    }
}
