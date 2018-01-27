﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigraineWorsener : MonoBehaviour
{
    public float Range = 1;
    public float WorsenAmount = 1;

    private MigraineTracker migraineTracker;

    private void OnTriggerEnter(Collider other)
    {
        var tracker = other.GetComponent<MigraineTracker>();
        if (tracker == null)
        {
            return;
        }

        migraineTracker = tracker;

        StartCoroutine(WorsenMigraine());
    }

    private void OnTriggerExit(Collider other)
    {
        var tracker = other.GetComponent<MigraineTracker>();
        if (tracker == null)
        {
            return;
        }

        StopCoroutine(WorsenMigraine());

        migraineTracker = null;
    }

    private IEnumerator WorsenMigraine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (migraineTracker == null)
            {
                break;
            }

            migraineTracker.IncreaseMigraine(WorsenAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
