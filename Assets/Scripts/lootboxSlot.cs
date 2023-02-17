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
    public itemFunctions itemCntrl;
    public lootbox lootboxController;


    public GameObject textbox;
    public TextMeshProUGUI gunName, damage, delay, range, force, desc;

    public sfxHolder sfx;

    public void giveItem()
    {
        sfx.click.Play();
        lootboxController.disableUI();
        if(designatedItem.GetComponent<weapon>() != null)
        {
            playerInv.addItem(designatedItem);
        }else{
            itemCntrl.bringItem(designatedItem.GetComponent<item>().itemDevCode);
        }
        
    }

    public void skip()
    {
        sfx.click.Play();
        lootboxController.disableUI();
    }

    public void setText()
    {
        textbox.SetActive(true);
        if(designatedItem.GetComponent<weapon>() != null)
        {
            weapon gun = designatedItem.GetComponent<weapon>();
            gunName.text = gun.gunName;
            damage.gameObject.SetActive(true);
            delay.gameObject.SetActive(true);
            range.gameObject.SetActive(true);
            force.gameObject.SetActive(true);
            damage.text = $"Damage: {gun.damage}";
            delay.text = $"Delay: {gun.shotDelay}";
            range.text = $"Range: {gun.range}";
            force.text = $"Force: {gun.bulletForce}";
            desc.gameObject.SetActive(false);
        }else{
            item item = designatedItem.GetComponent<item>();
            gunName.text = item.itemName;
            damage.gameObject.SetActive(false);
            delay.gameObject.SetActive(false);
            range.gameObject.SetActive(false);
            force.gameObject.SetActive(false);
            desc.gameObject.SetActive(true);
            desc.text = item.description;
        }

    }

    public void disableTextBox()
    {
        textbox.SetActive(false);
    }
}
