using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalEncounterSpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(0, 0.5f, 0), 0.25f);
    }
}
