using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private float spawnInterval = 1;

    private GameModeData bubbleData;

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

        objectPooler.GetPooledObject(spawnPosition, Quaternion.identity).GetComponent<BubbleCore>().SetGameModeData(bubbleData);
        //Instantiate(bubble, spawnPosition, Quaternion.identity);
    }

    private void SetBubbleData(GameModeData _gameModeData)
    {
        bubbleData = _gameModeData;
		InvokeRepeating(nameof(SpawnBubble), _gameModeData.spawnInterval, _gameModeData.spawnInterval);
	}

	private void Awake()
	{
        GameManager.Instance.GameModeSettingEvent.AddListener(SetBubbleData);
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        cam = Camera.main;
        //InvokeRepeating(nameof(SpawnBubble), spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
