using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] float launchSpeed;
    int bulletHealth = 1;
    int bulletBounceHealth = 3;
    Rigidbody2D rb;
    Vector2 direction;
    SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(0,0,255);

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * launchSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.GetComponent<Destructable>())
        {
            bulletHealth --;
            
            if(bulletHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        else{
            bulletBounceHealth --;

        if(bulletBounceHealth <= 3)
        {
            sprite.color = new Color(0,0,255);    
        }

         Debug.Log(bulletBounceHealth);
        }
         if(bulletBounceHealth <= 0)
        {
            Destroy(gameObject);    
        }      

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<HealthBoost>())
        {
            bulletBounceHealth ++;   
            if(bulletBounceHealth >= 4)
            {
                sprite.color = new Color(0,255,0);
            }              
            
        }
    }


    

}
