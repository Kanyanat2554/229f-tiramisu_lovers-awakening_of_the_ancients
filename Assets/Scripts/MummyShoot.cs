using UnityEngine;

public class MummyShoot : MonoBehaviour
{
    public GameObject mummyBulletPrefab;  
    public Transform shootPoint;             
    [SerializeField] public float shootInterval;    
    [SerializeField] public float projectileSpeed;  

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isPlayerInRange)
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
