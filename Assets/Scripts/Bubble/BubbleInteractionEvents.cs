using UnityEngine;
using UnityEngine.EventSystems;


public class BubbleInteractionEvents : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	private BubbleBehavior[] behaviors;

	public BubbleBehavior ActiveBehavior { get; private set; }


	private void Awake()
	{
		behaviors = GetComponents<BubbleBehavior>();
	}

	private void Start()
	{
		SetActiveBehavior();
	}

	private void OnEnable()
	{
		if (GameManager.Instance == null) return;

		SetActiveBehavior();
	}

	private void SetActiveBehavior()
	{
		string modeName = GameManager.Instance.CurrentGameMode.ToString();

		foreach (BubbleBehavior behavior in behaviors)
		{
			if (modeName == behavior.BehaviorName())
			{
				ActiveBehavior = behavior;
				break;
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		ActiveBehavior.RunOnPointerClick();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		ActiveBehavior.RunOnPointerDown();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		ActiveBehavior.RunOnPointerUp();
	}
}
