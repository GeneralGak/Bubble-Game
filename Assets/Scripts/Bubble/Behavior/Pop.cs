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
