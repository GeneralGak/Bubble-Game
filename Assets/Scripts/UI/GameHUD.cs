using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameHUD : MonoBehaviour
{
	private VisualElement visualElement;
	private Button Exit;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		visualElement = GetComponent<UIDocument>().rootVisualElement;
		Exit = visualElement.Q<Button>("backButton");
		Exit.clicked += QuitGameMode;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void QuitGameMode()
	{
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
		SceneManager.sceneLoaded += SetActiveScene;
		SceneManager.UnloadSceneAsync("Bubble pop");
	}

	private void SetActiveScene(Scene _loadedScene, LoadSceneMode _loadMode)
	{
		SceneManager.sceneLoaded -= SetActiveScene;
		SceneManager.SetActiveScene(_loadedScene);
	}
}
