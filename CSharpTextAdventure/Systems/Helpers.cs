using System;
using System.Collections.Generic;
using System.Linq;
using CSharpTextAdventure.Core;

namespace CSharpTextAdventure.Systems
{
    public static class Helpers
    {
        public static string OxfordCommaJoin(this IEnumerable<GameObject> collection)
        {
            if (collection == null)
            {
                return string.Empty;
            }

            if (!collection.Any())
            {
                return string.Empty;
            }

            var list = collection.ToList();

            if (list.Count == 1)
            {
                return list.First().ToString();
            }

            if (list.Count == 2)
            {
                return $"{list.First().ToString()} and {list.Last().ToString()}";
            }

            var result = string.Join(", ", list.Take(list.Count - 1));
            result += $", and {list.Last().ToString()}";

            return result;
        }
    }
}
