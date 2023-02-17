using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFunctions : MonoBehaviour
{

    public player player;
    public float healthAddition = 5f;
    public float speedAddition = 1f;

    public bool timestopEnabled;
    public enemyTracker enemyHolder;
    public Animator timestopFx;
    public GameObject gamecontrol;
    public float timeInTimestop;

    public GameObject solver;
    public holder inv;

    private void Update()
    {
        if(timestopEnabled && Input.GetKeyDown(KeyCode.E))
        {
            timestop();
        }
    }

    void timestop()
    {
        timestopFx.Play("timestop");
        for (int i = 0; i < enemyHolder.enemies.Count; i++)
        {
            enemyHolder.enemies[i].GetComponent<AIChase>().enabled = false;
        }

        gamecontrol.SetActive(false);
        StartCoroutine("resumeTime");
    }

    IEnumerator resumeTime()
    {
        yield return new WaitForSeconds(timeInTimestop);
        timestopFx.Play("resume time");
        for (int i = 0; i < enemyHolder.enemies.Count; i++)
        {
            enemyHolder.enemies[i].GetComponent<AIChase>().enabled = true;
        }

        gamecontrol.SetActive(true);
        enemyHolder.enemies.Add(solver);
        yield return new WaitForSeconds(0.5f);
        enemyHolder.enemies.Remove(solver);
    }

    public void bringItem(string code)
    {
        switch (code)
        {
            case "zawarudo":
                timestopEnabled = true;
                break;
            case "health":
                player.maxHealth += healthAddition;
                break;
            case "speed":
                player.currentSpeed += speedAddition;
                break;
            case "damage":
                dmgMult();
                break;
        }
    }

    void dmgMult()
    {
        foreach(GameObject weapon in inv.items)
        {
            weapon.GetComponent<weapon>().damage *= 1.15f;
        }
    }
}
