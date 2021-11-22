using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using System;
using UnityEngine;
static class helper {
    private static System.Random random = new System.Random();
    public static void mixBag<T>(this IList<T> list) {
        int n = list.Count;
        while (n> 1){
            n--;
            int k = random.Next(n+1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
public class Spawner : MonoBehaviour
{
    public List<GameObject> groups = new List<GameObject>();
    public Transform parent;
    public int count=0;
    public int next;
    public void spawnNext() 
    {
        if (count >= groups.Count){
            groups.mixBag();
            count = 0;
        }
        Instantiate(groups[count], transform.position, Quaternion.identity, parent);
        count++;
        next = count +1;
    }

    void Start()
    {
        groups.mixBag();
        spawnNext();
    }

}
