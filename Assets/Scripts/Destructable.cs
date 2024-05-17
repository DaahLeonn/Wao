using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.GetComponent<Bullet>()) 
        {
            Destroy(gameObject);
        }

    }
}
