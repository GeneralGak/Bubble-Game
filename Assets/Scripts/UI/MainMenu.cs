using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameModeData easyMode;
    [SerializeField] private GameModeData hardMode;

    private VisualElement visualElement;
    private Button playGame;
    private Button easyButton;
    private Button hardButton;
    private GameModeData choosenGameData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        choosenGameData = easyMode;

		visualElement = GetComponent<UIDocument>().rootVisualElement;
        playGame = visualElement.Q<Button>("playButton");
        playGame.clicked += StartGameMode1;
        easyButton = visualElement.Q<Button>("easyButton");
        easyButton.clicked += SetEasyMode;
        hardButton = visualElement.Q<Button>("hardButton");
        hardButton.clicked += SetHardMode;

        if(!SceneManager.GetSceneByName("Managers").isLoaded) SceneManager.LoadScene("Managers", LoadSceneMode.Additive);
        if(!SceneManager.GetSceneByName("GameHUD").isLoaded) SceneManager.LoadScene("GameHUD", LoadSceneMode.Additive);
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void SetEasyMode()
    {
        choosenGameData = easyMode;
    }

    private void SetHardMode()
    {
        choosenGameData = hardMode;
    }

    private void StartGameMode1()
    {
        SceneManager.LoadScene("Bubble pop", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += SetActiveScene;

        SceneManager.UnloadSceneAsync("MainMenu");
    }

    private void SetActiveScene(Scene _loadedScene, LoadSceneMode _loadMode)
    {
		SceneManager.sceneLoaded -= SetActiveScene;
		SceneManager.SetActiveScene(_loadedScene);

        GameManager.Instance.GameModeSettingEvent.Invoke(choosenGameData);
	}
}
