using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPre;

    public float bulletForce = 20f;
    // Start is called before the first frame 
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    
    
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.AddForce(firePoint.up*bulletForce, ForceMode2D.Impulse);
    }

}
