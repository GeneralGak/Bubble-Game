using UnityEngine;
using UnityEngine.Events;

public enum GameMode
{
    Pop,
    Expand
}

public enum GameDifficulty
{
	Easy,
	Hard
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameMode setGameMode;

    public static GameManager Instance { get { return instance; } }
    public GameMode CurrentGameMode { get { return setGameMode; } }
    public UnityEvent<GameModeData> GameModeSettingEvent { get; private set; } = new UnityEvent<GameModeData>();


	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
	}
}
