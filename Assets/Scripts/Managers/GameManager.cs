﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        OfficeGenerator.Instance.Generate(5, 5);

        Replace();
	}
	
    private void Replace()
    {
        Replacer.Instance.Replace<CubicleSpawner>("Cubicles");

        var peoplePrefab = Resources.Load<GameObject>("Encounters/People");
        new RandomPicker<PeopleSpawner>(peoplePrefab, 3).CallMe();
    }
}