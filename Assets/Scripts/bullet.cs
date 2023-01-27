using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public weapon gun;
    public GameObject impact;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.tag == "Enemy")
        {
            collider.GetComponent<AIChase>().health -= gun.damage;
            GameObject effect = Instantiate(impact, collider.transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(this.gameObject);
        }
        
        
    }

    private void Start()
    {
        InevitableDeath();  
    }

    //i just wanted the cool name :)
    void InevitableDeath()
    {
        Destroy(this.gameObject, 10f);
    }
}
