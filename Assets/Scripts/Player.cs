using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletCount = 3;

    void Update()
    {
        //Rotate player to mouse
        LookAtMouse();
        //Next level load on victory
        LoadLevel();
    }
    
    void LookAtMouse()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );
        transform.up = direction;

        if(Input.GetButtonDown("Fire1") && bulletCount >= 1 && FindAnyObjectByType<Bullet>() == null)
        {
            bulletCount--;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
    
    void LoadLevel()
    {
        
        if(FindAnyObjectByType<WinCon>(FindObjectsInactive.Exclude) == null) 
        {
                int levelToLoad = SceneManager.GetActiveScene().buildIndex +1;  
                SceneManager.LoadScene(levelToLoad);  
        }   
    }
}
