using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Item
{
    public string name;
    public int itemId;
    public int buff;
}
public class LINQ : MonoBehaviour
{

    public List<Item> items;
    int[] numbers = { 12, 1234, 16, 2, 6, 4, 3, 9, 284, 3, 6, 23, 68, 49, 86, 29, 59, 75, 37, 86, 39, 22, 50 };

    private void Start()
    {
        var filteredArray = numbers.Where(num => num > 50).OrderBy(num => num);
        foreach (var grade in filteredArray)
        {
            Debug.Log(grade);
        }

        var result = items.Where(item => item.buff > 15);
        foreach (var item in result)
        {
            Debug.Log($"Name:{item.name}");
        }
        Debug.Log($"Avarage = {result.Average(item => item.buff)}");
    }
}
