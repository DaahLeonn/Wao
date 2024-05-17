using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SliderTerrain : MonoBehaviour
{
     [SerializeField] Rigidbody2D rb;
     bool doneMoving;
     Vector3 currentPosition;
     Vector3 startPosition;

     [SerializeField] float target;
     


    void Start() 
    {
        

        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        rb.velocity = new Vector2(3,0);
    }
    void FixedUpdate()
    {   
        currentPosition = transform.position;

        
        if(Mathf.Abs(startPosition.x - currentPosition.x) > target)
        {
           
          if(startPosition.x - currentPosition.x < 0)
          {
            rb.velocity = new Vector2(0,0);
            rb.AddForce(-transform.right *100 );
          }
            
          else
          {
            rb.velocity = new Vector2(0,0);
            rb.AddForce(transform.right*100);
          }
        }
        
    }

}
