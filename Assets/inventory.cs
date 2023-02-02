using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public GameObject[] startingItems;
    public holder weaponHolder;

    public GameObject[] slots;
    public bool[] isFull;

    private void Start()
    {
        foreach (GameObject item in startingItems)
        {
            addItem(item);
        }
    }
    public void addItem(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(!isFull[i])
            {
                
                isFull[i] = true;
                weaponHolder.items.Add(item);
                item.transform.parent = weaponHolder.transform;
                slots[i].GetComponent<slot>().setItem(item);
                break;
            }
        }
    }
}
