using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulsLikeTutorial
{
    public static class Utils
    {
        public static List<T> GetListOfComponentsInChildren<T>(Component component)
        {
            List<T> list = new List<T>();
            T[] componentsArray = component.GetComponentsInChildren<T>();
            foreach(T item in componentsArray)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
