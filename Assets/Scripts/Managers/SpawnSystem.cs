using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private float spawnInterval = 1;

    public GameObject bubble;
    Camera cam;
    private GameModeData bubbleData;
    private float colliderRadius;

    public void SpawnBubble()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        float spawnPointX = Random.Range(-halfWidth + colliderRadius + (halfWidth * 2 * 0.15f), halfWidth - colliderRadius);
        float spawnPointY = Random.Range(-halfHeight + colliderRadius, halfHeight - colliderRadius);

        Debug.Log($"Screen Width in World Units: {halfWidth}");

        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);

        if(objectPooler.GetPooledObject(spawnPosition, Quaternion.identity, out GameObject pooledObject) && bubbleData != null) 
        {
            pooledObject.GetComponent<BubbleCore>().SetGameModeData(bubbleData);
		}
        //Instantiate(bubble, spawnPosition, Quaternion.identity);
    }

    private void SetBubbleData(GameModeData _gameModeData)
    {
        objectPooler.maxObjects = _gameModeData.maxBubbles;
        bubbleData = _gameModeData;
		InvokeRepeating(nameof(SpawnBubble), _gameModeData.spawnInterval, _gameModeData.spawnInterval);
	}

	private void Awake()
	{
        if(GameManager.Instance != null) GameManager.Instance.GameModeSettingEvent.AddListener(SetBubbleData);
        else InvokeRepeating(nameof(SpawnBubble), spawnInterval, spawnInterval);
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        cam = Camera.main;

        colliderRadius = bubble.GetComponent<SphereCollider>().radius;
        //InvokeRepeating(nameof(SpawnBubble), spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
