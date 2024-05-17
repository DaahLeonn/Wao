using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.GetComponent<Bullet>())
        {
            Destroy(gameObject);
        }
    }

}
