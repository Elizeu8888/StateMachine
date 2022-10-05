using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPop : MonoBehaviour
{
    public LayerMask lyMask;
    public GameObject popEffect;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.tag == "ground")
        {
            
            
            GameObject ball = Instantiate(popEffect, transform.position, Quaternion.identity);


            Destroy(ball, 1f);


            Destroy(gameObject);
        
        }

    }


}
