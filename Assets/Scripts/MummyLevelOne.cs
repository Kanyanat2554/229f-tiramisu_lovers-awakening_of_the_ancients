using UnityEngine;

public class MummyLevelOne : MonoBehaviour
{
    public GameObject mummyBulletPrefab;  
    public Transform shootPoint;             
    public float shootInterval = 0.5f;    
    public float projectileSpeed = 10f;  

    private Transform target;
    private bool isPlayerInRange = false;
    private float shootTimer = 0f;

    private void Update()
    {
        if (isPlayerInRange && target != null)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                ShootPlayer();
                shootTimer = 0f;
            }
           
        }
    }

    private void ShootPlayer()
    {
        //create bullet
        GameObject projectile = Instantiate(mummyBulletPrefab, shootPoint.position, Quaternion.identity);

        //calculate direction to player
        Vector2 direction = (target.position - shootPoint.position).normalized;

        //add speed to bullet
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            target = collision.transform;
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            target = null;
            shootTimer = 0f;
        }
    }
}
