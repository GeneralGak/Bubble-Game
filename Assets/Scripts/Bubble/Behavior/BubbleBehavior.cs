using UnityEngine;

public abstract class BubbleBehavior : MonoBehaviour
{
	protected MeshRenderer bubbleMesh;
	protected ParticleSystem popParticles;

	public Poolable PoolableComponent { protected get; set; }


	private void Start()
	{
		bubbleMesh = GetComponent<MeshRenderer>();
		popParticles = GetComponentInChildren<ParticleSystem>();
	}

	public virtual void RunOnPointerDown()
    {
    }

	public virtual void RunOnPointerClick()
	{
	}

	public virtual void RunOnPointerUp()
	{
	}

	public void SetBubbleMesh(bool _setEnabled)
	{
		bubbleMesh.enabled = _setEnabled;
	}

	public string BehaviorName()
	{
		return GetType().Name;
	}
}
