using Unity.Mathematics;
using UnityEngine;

public class Reflect : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 objectVelocity;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        objectVelocity = rb.velocity;
        
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        var speed = objectVelocity.magnitude;
        var direction = Vector2.Reflect(objectVelocity.normalized, other.contacts[0].normal);

        rb.velocity = direction * speed;     
        

        Quaternion newRotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.rotation = newRotation;

    }
}
