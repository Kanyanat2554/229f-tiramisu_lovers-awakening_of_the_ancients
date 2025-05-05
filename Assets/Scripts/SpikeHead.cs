using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    private float forceMagnitude = 50f;      
    private float maxDistance = 1f;        

    private ConstantForce2D constantForce2D;
    private Vector2 startPosition;
    private int direction = 1;

    void Start()
    {
        constantForce2D = GetComponent<ConstantForce2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        float currentDistance = transform.position.y - startPosition.y;

        
        if ((direction == 1 && currentDistance >= maxDistance) ||
            (direction == -1 && currentDistance <= -maxDistance))
        {
            direction *= -1; 
            startPosition = transform.position; 
        }

        constantForce2D.force = new Vector2(0f, forceMagnitude * direction);
    }
}
