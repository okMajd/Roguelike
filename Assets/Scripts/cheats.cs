using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheats : MonoBehaviour
{
    public lootbox lootboxController;
    public player player;
    public enemyTracker enemyTracker;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            lootboxController.enableUI();
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            player.maxHealth = 1000f;
            player.health = player.maxHealth;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < enemyTracker.enemies.Count; i++)
            {
                enemyTracker.enemies[i].GetComponent<AIChase>().die();
            }
        }
    }
}
