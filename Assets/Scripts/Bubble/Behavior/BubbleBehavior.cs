using UnityEngine;

public abstract class BubbleBehavior : MonoBehaviour
{
    public virtual void RunOnPointerDown()
    {
    }

	public virtual void RunOnPointerClick()
	{
	}

	public virtual void RunOnPointerUp()
	{
	}

	public string BehaviorName()
	{
		return GetType().Name;
	}
}
