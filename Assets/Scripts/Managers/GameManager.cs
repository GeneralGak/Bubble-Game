using UnityEngine;

public enum GameMode
{
    Pop,
    Expand
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameMode setGameMode;

    public static GameManager Instance { get { return instance; } }
    public GameMode CurrentGameMode { get { return setGameMode; } }


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
