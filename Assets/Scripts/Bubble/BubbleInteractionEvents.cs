using UnityEngine.EventSystems;


public class BubbleInteractionEvents : Poolable, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	private BubbleBehavior[] behaviors;

	public BubbleBehavior ActiveBehavior { get; private set; }


	private void Awake()
	{
		behaviors = GetComponents<BubbleBehavior>();
	}

	//private void Start()
	//{
	//	SetActiveBehavior();
	//}

	//private void OnEnable()
	//{
	//	if (GameManager.Instance == null) return;

	//	SetActiveBehavior();
	//}

	public void SetActiveBehavior(GameMode _choosenGameMode)
	{
		string modeName = _choosenGameMode.ToString();

		foreach (BubbleBehavior behavior in behaviors)
		{
			if (modeName == behavior.BehaviorName())
			{
				ActiveBehavior = behavior;
				ActiveBehavior.PoolableComponent = this;
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

	public override void ResetObject()
	{
	}
}
