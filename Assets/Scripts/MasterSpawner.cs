using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSpawner : MonoBehaviour
{
    public RandomPicker<PeopleSpawner> peoplePicker;
    public GameObject PeoplePrefab;
    public int PeopleSpawnCount;

    // Use this for initialization
    void Start () {
        if (peoplePicker == null)
        {
            peoplePicker = new RandomPicker<PeopleSpawner>(PeoplePrefab, PeopleSpawnCount);
        }

        peoplePicker.CallMe();
	}
}
