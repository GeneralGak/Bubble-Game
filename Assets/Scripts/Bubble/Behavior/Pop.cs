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

    //IEnumerator required for delay between animation start and removal of object
	IEnumerator popDelay()
    {
        yield return new WaitForSeconds(0.135f);
        PoolableComponent.RemoveToPool();
    }
}
