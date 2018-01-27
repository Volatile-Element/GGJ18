using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour, IInteractable
{
    public GameObject ObjectToSpawnPrefab;

    public Vector3 Offset;
    public Vector3 Force;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        var spawnedItem = Instantiate(ObjectToSpawnPrefab, transform.position + Offset, Quaternion.identity);
        spawnedItem.name = ObjectToSpawnPrefab.name;

        //TODO: Add force if object has RB.
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + Offset, 0.1f);
    }
}
