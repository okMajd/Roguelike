using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayer : MonoBehaviour
{
    public lootbox lootboxController;
    private void Start()
    {
        lootboxController = GameObject.Find("LootboxController").GetComponent<lootbox>();
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag("Player"))
        {
            lootboxController.enableUI();
            Destroy(this.gameObject);
        }
    }
}
