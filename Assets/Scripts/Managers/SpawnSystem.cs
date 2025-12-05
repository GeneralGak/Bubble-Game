using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject bubble;
    Camera cam;

    public void SpawnBubble()
    {
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        float spawnPointX = Random.Range(-width, width);
        float spawnPointY = Random.Range(-height, height);

        Debug.Log($"Screen Width in World Units: {width}");

        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);

        Instantiate(bubble, spawnPosition, Quaternion.identity);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        InvokeRepeating(nameof(SpawnBubble), 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
