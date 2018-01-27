using System.Collections;
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
    }
}