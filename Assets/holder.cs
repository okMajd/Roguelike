using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holder : MonoBehaviour
{
    public List<GameObject> itemLocations = new List<GameObject>();
    public GameObject[] items;
    private void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].transform.position = itemLocations[i].transform.position;
        }
    }
}
