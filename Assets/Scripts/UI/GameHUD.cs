using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameHUD : MonoBehaviour
{
	private VisualElement visualElement;
	private Button Exit;
	private Toggle disableSound;
	private Toggle disableMusic;
	private bool inGame = false;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		visualElement = GetComponent<UIDocument>().rootVisualElement;
		Exit = visualElement.Q<Button>("backButton");
		Exit.clicked += OnQuitButtonPressed;
		disableSound = visualElement.Q<Toggle>("SoundToggle");
		disableMusic = visualElement.Q<Toggle>("MusicToggle");

		GameManager.Instance.GameModeSettingEvent.AddListener(SetInGame);
	}

	private void SetInGame(GameModeData _gameData)
	{
		inGame = _gameData != null;
	}

	private void OnQuitButtonPressed()
	{
		if (inGame) QuitGameMode();
		else QuitGame();
	}

	private void QuitGameMode()
	{
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
		SceneManager.sceneLoaded += SetActiveScene;
		SceneManager.UnloadSceneAsync("Bubble pop");
		SetInGame(null);
	}

	private void QuitGame()
	{
		Application.Quit();
	}

	private void SetActiveScene(Scene _loadedScene, LoadSceneMode _loadMode)
	{
		SceneManager.sceneLoaded -= SetActiveScene;
		Exit.BringToFront();
		//SceneManager.SetActiveScene(_loadedScene);
	}
}
