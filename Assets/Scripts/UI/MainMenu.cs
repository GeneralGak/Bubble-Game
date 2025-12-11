using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<GameModeData> gameData = new List<GameModeData>();

    private VisualElement visualElement;
    private Button GameMode1;
    private Button GameMode2;
    private Button GameMode3;
    private GameMode choosenGameMode;
    private GameDifficulty choosenDifficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		visualElement = GetComponent<UIDocument>().rootVisualElement;
        GameMode1 = visualElement.Q<Button>("Gamemode1");
        GameMode1.clicked += StartGameMode1;
		GameMode2 = visualElement.Q<Button>("Gamemode2");
		GameMode3 = visualElement.Q<Button>("Gamemode3");

        if(!SceneManager.GetSceneByName("Managers").isLoaded) SceneManager.LoadScene("Managers", LoadSceneMode.Additive);
        if(!SceneManager.GetSceneByName("GameHUD").isLoaded) SceneManager.LoadScene("GameHUD", LoadSceneMode.Additive);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGameMode1()
    {
        SceneManager.LoadScene("Bubble pop", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SetActiveScene;

        choosenGameMode = GameMode.Pop;
        choosenDifficulty = GameDifficulty.Easy;

        SceneManager.UnloadSceneAsync("MainMenu");
    }

    private void SetActiveScene(Scene _loadedScene, LoadSceneMode _loadMode)
    {
		SceneManager.sceneLoaded -= SetActiveScene;
		SceneManager.SetActiveScene(_loadedScene);

        GameManager.Instance.GameModeSettingEvent.Invoke(gameData[0]);
	}
}
