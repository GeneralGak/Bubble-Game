using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleMove : MonoBehaviour
{
    
    //Camera cam = Camera.main.WorldToViewportPoint(Component.position);

    public float moveSpeedX = 1f;
    public float moveSpeedY = 1f;

    

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(moveSpeedX * Time.deltaTime, moveSpeedY * Time.deltaTime, 0);
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        
        //top & bottom edge
        if (viewPos.y > 1f || viewPos.y < 0f)
        {
            moveSpeedY *= -1f;
        }

        //left & right edge
        if (viewPos.x > 1f || viewPos.x < 0f)
        {
            moveSpeedX *= -1f;
        }
    }
}
