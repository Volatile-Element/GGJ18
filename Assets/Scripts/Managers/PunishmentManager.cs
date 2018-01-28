using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunishmentManager : MonoBehaviour
{
    private MigraineTracker migraineTracker;

    private bool sprinting = false;

    private void Awake()
    {
        migraineTracker = FindObjectOfType<MigraineTracker>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            migraineTracker.IncreaseMigraine(10);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            migraineTracker.IncreaseMigraine(5);

            sprinting = true;
            StartCoroutine(IncreaseMigraine());
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
            StopCoroutine(IncreaseMigraine());
        }
    }

    private IEnumerator IncreaseMigraine()
    {
        while (sprinting)
        {
            yield return new WaitForSeconds(1);

            if (!sprinting)
            {
                break;
            }

            migraineTracker.IncreaseMigraine(2.5f);
        }
    }
}
