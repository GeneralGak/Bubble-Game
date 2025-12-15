using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleMove : MonoBehaviour
{
    
    //

    public float moveSpeedX = 1f;
    public float moveSpeedY = 1f;

    
    


    void Start()
    {
        int rndX = Random.Range(0, 2);
        int rndY = Random.Range(0, 2);
        if (rndX == 0)
        {
            moveSpeedX *= -1;
        }  
        if (rndY == 0)
        {
            moveSpeedY *= -1;
        }

        //Animation animation = bubble.GetComponent<Animation>();
    }

    
    void Update()
    {
        transform.Translate(moveSpeedX * Time.deltaTime, moveSpeedY * Time.deltaTime, 0);
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        
        //top & bottom edge
        if (viewPos.y > 0.955f && moveSpeedY > 0 || viewPos.y < 0.045f && moveSpeedY < 0)
        {
            GetComponent<Animation>().Play("bubbleBounceTopNBottom");
            moveSpeedY *= -1f;
        }

        //left & right edge
        if (viewPos.x > 0.975f && moveSpeedX > 0 || viewPos.x < 0.025f && moveSpeedX < 0)
        {
            GetComponent<Animation>().Play("bubbleBounceSide");
            moveSpeedX *= -1f;
        }
    }
}
