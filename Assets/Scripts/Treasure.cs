using UnityEngine;

public class Treasure : MonoBehaviour
{
    public static int collectedTreasures = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectedTreasures++;
            Debug.Log($"Treasure collected: {collectedTreasures}");

            Destroy(gameObject);

            if (collectedTreasures >= 6)
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
