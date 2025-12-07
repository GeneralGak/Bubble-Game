using UnityEngine;

public class BackgroundBirds : BackgroundEvent
{
    [SerializeField] private float flySpeed = 0.4f;
    [SerializeField] private Vector2 endPosition;

    private Vector2 startPosition;
    private bool isTriggered = false;
    private float elapsedFlightProgress;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move object from start to end via linear interpolation
        if(isTriggered)
        {
            elapsedFlightProgress += flySpeed * Time.deltaTime;

            Vector2 newPosition = startPosition + (endPosition - startPosition) * elapsedFlightProgress;

            gameObject.transform.position = newPosition;

            if(elapsedFlightProgress >= 1)
            {
                isTriggered = false;
                gameObject.transform.position = startPosition;
                elapsedFlightProgress = 0;
			}
        }
    }

	public override void Trigger()
	{
        isTriggered = true;
	}
}
