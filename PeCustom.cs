using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace csProjectEuler
{
    /// <summary>
    /// Custom templates and functions.
    /// </summary>
    public class PeCustom
    {
        /// <summary>
        /// Returns List of List T denoting the value and it's frequency.
        /// </summary>
        public static List<List<T>> GetItemFrequencyList<T>(List<T> items) where T : IComparable<T>
        {
            List<List<T>> frequencyList = new();
            for (int i = 0; i < items.Count; i++)
            {
                bool addedExisting = false;
                T c = items[i];
                for (int j = 0; j < frequencyList.Count; j++)
                {
                    if (frequencyList[j].Count > 0)
                    {
                        if (frequencyList[j][0].CompareTo(c) == 0)
                        {
                            frequencyList[j].Add(c);
                            addedExisting = true;
                        }
                    }
                }
                if (!addedExisting)
                    frequencyList.Add(new List<T>() { c });
            }
            return frequencyList;
        }
    }
}