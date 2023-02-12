using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class lootboxSlot : MonoBehaviour
{
    public GameObject designatedItem;
    public Vector3 slotRotation;
    public inventory playerInv;
    public lootbox lootboxController;


    public GameObject textbox;
    public TextMeshProUGUI gunName, damage, delay, range, force;

    public void giveItem()
    {
        lootboxController.disableUI();
        
        playerInv.addItem(designatedItem);
    }

    public void skip()
    {
        lootboxController.disableUI();
    }

    public void setText()
    {
        textbox.SetActive(true);
        weapon gun = designatedItem.GetComponent<weapon>();
        gunName.text = gun.gunName;
        damage.text = $"Damage: {gun.damage}";
        delay.text = $"Delay: {gun.shotDelay}";
        range.text = $"Range: {gun.range}";
        force.text = $"Force: {gun.bulletForce}";
    }

    public void disableTextBox()
    {
        textbox.SetActive(false);
    }
}
