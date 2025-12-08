using UnityEngine;

public abstract class BubbleBehavior : MonoBehaviour
{
	public Poolable PoolableComponent { protected get; set; }

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
