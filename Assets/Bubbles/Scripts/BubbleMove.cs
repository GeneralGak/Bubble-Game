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
            //moveSpeedY *= -1f;
			GetComponent<Animation>().Play("bubbleBounceTopNBottom");
			ChangeDirection(new Vector2(1f, -1f));
		}

        //left & right edge
        if (viewPos.x > 0.975f && moveSpeedX > 0 || viewPos.x < 0.025f && moveSpeedX < 0)
        {
            //moveSpeedX *= -1f;
			GetComponent<Animation>().Play("bubbleBounceSide");
            ChangeDirection(new Vector2(-1f, 1f));
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != LayerMask.NameToLayer("Bubble")) return;

		Vector2 collisionDirection = (other.transform.position - transform.position).normalized;

		//top & bottom edge
		if (collisionDirection.y > 1f || collisionDirection.y < 0f)
		{
			ChangeDirection(new Vector2(1f, -1f));
		}

		//left & right edge
		if (collisionDirection.x > 1f || collisionDirection.x < 0f)
		{
			ChangeDirection(new Vector2(-1f, 1f));
		}
	}

    private void ChangeDirection(Vector2 _newDirection)
    {
        moveSpeedX *= _newDirection.x;
        moveSpeedY *= _newDirection.y;
	}
}
