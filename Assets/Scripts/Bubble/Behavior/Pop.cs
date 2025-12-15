using System.Collections;
using UnityEngine;


public class Pop : BubbleBehavior
{
    public override void RunOnPointerDown()
	{
        StartCoroutine(popDelay());
        GetComponent<Animation>().Play("bubbleBurst");
    }

    //IEnumerator required for delay between animation start and removal of object
	IEnumerator popDelay()
    {
        yield return new WaitForSeconds(0.13f);
        PoolableComponent.RemoveToPool();
    }
}
