using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverTracker : MonoBehaviour
{
    public UnityEvent OnGameOver = new UnityEvent();

    private void Start()
    {
        GetComponent<MigraineTracker>().OnCurrentMigraineLevelPercentageChange.AddListener(OnCurrentMigraineLevelPercentageChange);
    }

    public void OnCurrentMigraineLevelPercentageChange(float percentage)
    {
        if (percentage >= 100)
        {
            OnGameOver.Invoke();
        }
    }
}