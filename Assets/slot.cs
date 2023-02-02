using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    public Vector2 slotLocation;
    public Vector3 slotRotation;

    public void setItem(GameObject item)
    {
        iconSettings iconSettings = item.GetComponent<iconSettings>(); 
        GameObject slottedItem = Instantiate(iconSettings.icon);
        slottedItem.transform.SetParent(this.transform);
        slottedItem.transform.localScale = iconSettings.dimensions;
        slottedItem.GetComponent<RectTransform>().anchoredPosition = slotLocation;
        slottedItem.transform.localRotation = Quaternion.Euler(slotRotation);
        
    }
}
