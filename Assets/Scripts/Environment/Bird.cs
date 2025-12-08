using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.6f;
    [SerializeField] private float moveOffset = 2;

    private float index;
    private Vector3 defaultPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultPosition = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        index += moveSpeed * Time.deltaTime;

        gameObject.transform.localPosition = new Vector3(defaultPosition.x,
													     defaultPosition.y + moveOffset * Mathf.Sin(index),
													     defaultPosition.z);
    }
}
