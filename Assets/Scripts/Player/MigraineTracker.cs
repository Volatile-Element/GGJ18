using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigraineTracker : MonoBehaviour
{
    public float CurrentMigraineLevelPercentage = 0;

    private float migraineIncreaseTick = 0.1f;

    public UnityEventFor<float> OnCurrentMigraineLevelPercentageChange = new UnityEventFor<float>();

    private void Start()
    {
        StartCoroutine(MigraineTicker());
    }

    public void IncreaseMigraine(float amount)
    {
        CurrentMigraineLevelPercentage += amount;

        OnCurrentMigraineLevelPercentageChange.Invoke(CurrentMigraineLevelPercentage);
    }

    public void DecreaseMigraine(float amount)
    {
        if (CurrentMigraineLevelPercentage - amount < 0)
        {
            CurrentMigraineLevelPercentage = 0;
        }
        else
        {
            CurrentMigraineLevelPercentage -= amount;
        }

        OnCurrentMigraineLevelPercentageChange.Invoke(CurrentMigraineLevelPercentage);
    }

    private IEnumerator MigraineTicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
        }
    }
}