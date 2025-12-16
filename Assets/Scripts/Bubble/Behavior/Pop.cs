using System.Collections;
using UnityEngine;


public class Pop : BubbleBehavior
{
    public AudioSource popSfx1;
    public AudioSource popSfx2;
    public AudioSource popSfx3;

    int sfxPicker;
    
    public override void RunOnPointerDown()
	{
        StartCoroutine(popDelay());
        GetComponent<Animation>().Play("bubbleBurst");

        sfxPicker = Random.Range(0, 3);
        
        if(sfxPicker == 0)
        {
            popSfx1.Play();
        }
        else if(sfxPicker == 1)
        {
            popSfx2.Play();
        }
        else
        {
            popSfx3.Play();
        }
    }

    //IEnumerator required for delay between animation start and removal of object
	IEnumerator popDelay()
    {
        yield return new WaitForSeconds(0.135f);
        PoolableComponent.RemoveToPool();
    }
}
