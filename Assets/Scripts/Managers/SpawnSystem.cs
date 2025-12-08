using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject bubble;
    Camera cam;

    public void SpawnBubble()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        float spawnPointX = Random.Range(-halfWidth + (halfWidth * 2 * 0.15f), halfWidth);
        float spawnPointY = Random.Range(-halfHeight, halfHeight);

        Debug.Log($"Screen Width in World Units: {halfWidth}");

        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);

        Instantiate(bubble, spawnPosition, Quaternion.identity);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        InvokeRepeating(nameof(SpawnBubble), 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
