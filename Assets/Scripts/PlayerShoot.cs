using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target; 
    [SerializeField] Rigidbody2D bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //shoot raycast to detect mouse clicked position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            //get click point
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            //if hit object with collider
            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("hit " + hit.collider.name);

                //calculate projectile velocity
                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                //shoot bullet prefab using rigidbody2d
                Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

                //add projectile velocity vector to the bullet rigidbody
                shootBullet.linearVelocity = projectileVelocity;
            }
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        //find velocity of x and y axis
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        //get projectile vector
        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }
}
