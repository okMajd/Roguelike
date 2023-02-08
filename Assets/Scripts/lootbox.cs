using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootbox : MonoBehaviour
{
    public List<GameObject> possibleItems = new List<GameObject>();
    public List<GameObject> slots = new List<GameObject>();
    public GameObject canvas;
    public List<GameObject> objectsToDelete = new List<GameObject>();


    public void enableUI()
    {
        Time.timeScale = 0f;
        canvas.SetActive(true);
        foreach (GameObject slot in slots)
        {
            slot.SetActive(true);   
            lootboxSlot slotCode = slot.GetComponent<lootboxSlot>();
            slotCode.designatedItem = decideItem();
            GameObject tempItem = Instantiate(slotCode.designatedItem);
            tempItem.GetComponent<weapon>().enabled = false;
            iconSettings iconSettings = tempItem.GetComponent<iconSettings>();  
            GameObject slottedItem = Instantiate(tempItem.GetComponent<iconSettings>().icon);
            objectsToDelete.Add(slottedItem);
            Destroy(tempItem);
            slottedItem.transform.SetParent(slotCode.transform);
            slottedItem.transform.localScale = iconSettings.lootDimensions;
            slottedItem.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            Vector3 newRotation = new Vector3(0, 0, slotCode.slotRotation.z+iconSettings.addedRotationLootbox.z);
            slottedItem.transform.localRotation = Quaternion.Euler(newRotation);
        }
    }


    public void disableUI()
    {
        Time.timeScale = 1f;
        canvas.SetActive(false);
        foreach (GameObject item in objectsToDelete)
        {
            Destroy(item);
        }
    }

    GameObject decideItem()
    {
        int itemIndex = Random.Range(0, possibleItems.Count);
        return possibleItems[itemIndex];
    }


}
