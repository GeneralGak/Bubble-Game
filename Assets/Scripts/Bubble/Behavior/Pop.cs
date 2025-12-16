using System.Collections;
using UnityEngine;

public class Pop : BubbleBehavior
{
    public AudioSource popSfx;
    
    public override void RunOnPointerDown()
	{
		StartCoroutine(popDelay());
        GetComponent<Animation>().Play("bubbleBurst");
        popSfx.Play();
	}

	private void RemoveObject()
	{
		PoolableComponent.RemoveToPool();
    }

    //IEnumerator required for delay between animation start and removal of object
	IEnumerator popDelay()
    {
        yield return new WaitForSeconds(0.135f);
        SetBubbleMesh(false);
		popParticles.Play();
		Invoke(nameof(RemoveObject),  popParticles.main.startLifetime.constant);
    }
}
