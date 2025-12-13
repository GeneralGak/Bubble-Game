using UnityEngine;

[CreateAssetMenu(fileName = "GameModeData", menuName = "Scriptable Objects/GameModeData")]
public class GameModeData : ScriptableObject
{
    [Header("Game Settings")]
    public GameMode gameMode;
    [Space(5)]

    [Header("Bubbles")]
    public float spawnInterval;
    public float bubbleMoveSpeed;
    public int maxBubbles;

}
