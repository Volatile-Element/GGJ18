using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableMigraineLocation : MonoBehaviour
{

    public int MinDuration = 1;
    public int MaxDuration;
    public int MinTimeBetween = 1;
    public int MaxTimeBetween;


    public float currentDuration;
    public float currentWaiting;
    public bool isActive;

    private SoundParticleSpawner ParticleSpawner;
    private MigraineWorsener MigraineWorsener;

    // Use this for initialization
    void Start ()
	{
        ParticleSpawner = GetComponentInParent<SoundParticleSpawner>();
	    ParticleSpawner.StopParticles();

	    MigraineWorsener = GetComponentInParent<MigraineWorsener>();
	    MigraineWorsener.Deactivate();

	    isActive = false;

	    currentDuration = Random.Range(MinTimeBetween, MaxTimeBetween);

        StartCoroutine(MigraineTicker());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CheckSounds(float increasedAmount)
    {
        currentWaiting += increasedAmount;

        if (currentWaiting >= currentDuration)
        {
            if (isActive)
            {
                ParticleSpawner.StopParticles();
                MigraineWorsener.Deactivate();

                isActive = false;

                currentDuration = Random.Range(MinTimeBetween, MaxTimeBetween);
                currentWaiting = 0;
            }
            else
            {
                ParticleSpawner.StartParticles();
                MigraineWorsener.Activate();

                isActive = true;

                currentDuration = Random.Range(MinDuration, MaxDuration);
                currentWaiting = 0;
            }
        }
    }

    private IEnumerator MigraineTicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            CheckSounds(0.3f);
        }
    }
}
