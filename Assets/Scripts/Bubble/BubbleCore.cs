using UnityEngine;

public class BubbleCore : MonoBehaviour
{
    private BubbleInteractionEvents behaviorManager;
    private BubbleMove movement;


	private void Awake()
	{
        behaviorManager = GetComponent<BubbleInteractionEvents>();
        movement = GetComponent<BubbleMove>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameModeData(GameModeData _gameModeData)
    {
        if (_gameModeData.bubbleMoveSpeed == 0) movement.enabled = false;
        else
        {
            movement.enabled = true;
            movement.moveSpeedX = _gameModeData.bubbleMoveSpeed;
            movement.moveSpeedY = _gameModeData.bubbleMoveSpeed;
        }

        behaviorManager.SetActiveBehavior(_gameModeData.gameMode);
    }
}
