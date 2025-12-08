using UnityEngine;

public class BackgroundEventTrigger : MonoBehaviour
{
    [SerializeField] private float maxTimeBetweenEvents = 7;
    [SerializeField] private float minTimeBetweenEvents = 3;

    private float elapsedTimeBeforeNextEvent;
    private BackgroundEvent[] events;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        events = GetComponentsInChildren<BackgroundEvent>();
        elapsedTimeBeforeNextEvent = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedTimeBeforeNextEvent <= 0)
        {
            // TODO: Add a percentage trigger chance to minimize chance of same event triggering
            events[Random.Range(0, events.Length)].Trigger();

            elapsedTimeBeforeNextEvent = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
		}
        else elapsedTimeBeforeNextEvent -= Time.deltaTime;
	}
}
