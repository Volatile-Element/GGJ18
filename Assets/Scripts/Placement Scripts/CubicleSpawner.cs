using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicleSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one * 2.5f);
    }
}
