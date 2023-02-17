using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public string gunName = "Gun Name";
    public enemyTracker enemyHolder;
    public GameObject closestEnemy;

    public float shotDelay = 0.25f;
    public float damage = 5f;
    public float bulletForce = 20f;
    public GameObject bulletPre;
    public Transform firePoint;
    public float range = 5f;


    bool canShoot = true;
    private void Start()
    {
        enemyHolder = GameObject.Find("EnemyHolder").GetComponent<enemyTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        findClosest();
        if(closestEnemy != null)
        {
            findClosest();
            Vector2 dir = closestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            if(Vector2.Distance(firePoint.position, closestEnemy.transform.position) < range){
                if(canShoot)
                    StartCoroutine("shoot");
            }
        }else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        
        if(canShoot)
            shoot();

    }


    IEnumerator shoot()
    {
            canShoot = false;
            GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
            bullet.GetComponent<bullet>().gun = this.gameObject.GetComponent<weapon>();
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.AddForce(firePoint.up*bulletForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(shotDelay);
            canShoot = true;
    }

    void findClosest()
    {
        if(enemyHolder.enemies.Count > 1){
            float closestDistance = Vector2.Distance(enemyHolder.enemies[0].transform.position, transform.position);
            for (int i = 0; i < enemyHolder.enemies.Count; i++)
            {
                float dis = Vector2.Distance(transform.position, enemyHolder.enemies[i].transform.position);
                if(dis < closestDistance)
                {
                    closestDistance = dis;
                    closestEnemy = enemyHolder.enemies[i];
                }
            }
        }

    }
}
