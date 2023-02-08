using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    public GameObject designatedItem;
    public int itemIndex;
    public GameObject realItem;
    public Vector2 slotLocation;
    public Vector3 slotRotation;
    public inventory inventory;
    public int index;
    public holder weaponHolder;
    public void setItem(GameObject item)
    {
        designatedItem = item;
        iconSettings iconSettings = item.GetComponent<iconSettings>(); 
        GameObject slottedItem = Instantiate(iconSettings.icon);
        realItem = slottedItem;
        slottedItem.transform.SetParent(this.transform);
        slottedItem.transform.localScale = iconSettings.hotbarDimensions;
        slottedItem.GetComponent<RectTransform>().anchoredPosition = slotLocation;
        Vector3 newRotation = new Vector3(0, 0, slotRotation.z+iconSettings.addedRotationHotbar.z);
        slottedItem.transform.localRotation = Quaternion.Euler(newRotation);
        
    }

    public void destroyItem()
    {
        weaponHolder.items.Remove(designatedItem);
        Destroy(designatedItem);
        designatedItem = null;
        Destroy(realItem);
        realItem = null;
        inventory.isFull[index] = false;
    }
}
