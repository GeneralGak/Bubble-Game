
public class Pop : BubbleBehavior
{
	public override void RunOnPointerDown()
	{
		SetBubbleMesh(false);
		popParticles.Play();
		Invoke(nameof(RemoveObject),  popParticles.main.startLifetime.constant);
	}

	private void RemoveObject()
	{
		PoolableComponent.RemoveToPool();
	}
}
