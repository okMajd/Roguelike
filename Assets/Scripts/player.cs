using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public GameObject deathCanvas;
    public GameObject gameCanvas;
    float maxHealth = 100f;
    public float health = 100f;
    public float defaultMoveSpeed = 5f;
    public float currentSpeed = 5f;
    public Rigidbody2D rb;
    public RawImage healthBar;
    public TextMeshProUGUI healthText;
    Vector2 movement;
    Vector2 mousePos;
    public enemyTracker enemyTracker;
    public GameObject weaponHolder;
    public Camera cam;

    private void Update()
    {
        healthBar.rectTransform.localScale = new Vector3(health/maxHealth, 1, 1);
        healthText.text = $"{health}/{maxHealth}";
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(health <= 0)
        {
            die();
        }

    }

    void die()
    {
        for (int i = 0; i < enemyTracker.enemies.Count; i++)
        {
            enemyTracker.enemies[i].GetComponent<AIChase>().enabled = false;
        }
        weaponHolder.SetActive(false);
        gameCanvas.SetActive(false);
        deathCanvas.SetActive(true);
        this.gameObject.GetComponent<player>().enabled = false;
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);

        // Vector2 dir = mousePos - rb.position;
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }
}