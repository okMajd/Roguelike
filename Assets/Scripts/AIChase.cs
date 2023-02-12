using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public float damage = 5f;
    public float health = 85f;
    public GameObject apple, lootbox;

    public enemyTracker enemyTracker;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyTracker = GameObject.Find("EnemyHolder").GetComponent<enemyTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
        if(health <= 0)
            die();
    }

    public void die()
    {
        float chance = Random.Range(0, 100);
        Debug.Log(chance);
        if(chance <= 10)
            Instantiate(lootbox, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        if(chance > 10 && chance <= 45)
            Instantiate(apple, transform.position, Quaternion.identity);
        enemyTracker.enemies.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player"){
            player playerScript = collider.GetComponent<player>();
            playerScript.health -= damage;
        }
    }
}
