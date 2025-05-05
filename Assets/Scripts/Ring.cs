using UnityEngine;

public class Ring : MonoBehaviour
{
    public static int collectedRings = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectedRings++;
            Debug.Log($"Rings collected: {collectedRings}");

            Destroy(gameObject);

            if (collectedRings >= 2)
            {
                RemoveBarrier();
            }
        }
    }

    private void RemoveBarrier()
    {
        GameObject barrier = GameObject.FindGameObjectWithTag("Barrier");
        if (barrier != null)
        {
            Destroy(barrier);
            Debug.Log("Barrier Removed!");
        }
    }
}
