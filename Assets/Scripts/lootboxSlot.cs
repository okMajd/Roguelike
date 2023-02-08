using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootboxSlot : MonoBehaviour
{
    public GameObject designatedItem;
    public Vector3 slotRotation;
    public inventory playerInv;
    public lootbox lootboxController;

    public void giveItem()
    {
        lootboxController.disableUI();
        
        playerInv.addItem(designatedItem);
    }

    public void skip()
    {
        lootboxController.disableUI();
    }
}
