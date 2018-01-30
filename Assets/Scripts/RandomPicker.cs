using System;
using System.Collections.Generic;
using UnityEngine;

public class RandomPicker<T> where T : MonoBehaviour
{
    private IList<T> spawnObjects { get; set; }
    private int SpawnCount { get; set; }
    private GameObject NewType { get; set; }
    private bool RandomRotation { get; set; }

    public RandomPicker(GameObject newType, int spawnCount, bool randomRotation = false)
    {
        NewType = newType;
        SpawnCount = spawnCount;
        RandomRotation = randomRotation;
    }

    // Use this for initialization
    public void CallMe () {

	    if (spawnObjects == null)
	    {
            spawnObjects = GameObject.FindObjectsOfType(typeof(T)) as IList<T>;
	    }

	    if (SpawnCount == 0)
	    {
	        SpawnCount = 1;
	    }

	    var randomNumbers = GetRandomNumbers(SpawnCount, spawnObjects.Count);

	    foreach (int randomNumber in randomNumbers)
	    {
	        var oldObject = spawnObjects[randomNumber].gameObject;

	        var newObject = GameObject.Instantiate(NewType, oldObject.transform.position, oldObject.transform.rotation, oldObject.transform.parent) as GameObject;

	        if (RandomRotation)
	        {
	            newObject.transform.Rotate(Vector3.up, UnityEngine.Random.Range(0, 359));
            }

            GameObject.DestroyImmediate(oldObject);
	    }
	}

    private IList<int> GetRandomNumbers(int amount, int max)
    {
        if (amount > max)
        {
            amount = max;
        }

        IList<int> numbers = new List<int>();

        UnityEngine.Random.InitState(DateTime.UtcNow.Second);

        for (int i = 0; i < amount; i++)
        {
            bool newCollection = true;

            while (newCollection)
            {
                int randomNumber = UnityEngine.Random.Range(0, max);

                if (numbers.Contains(randomNumber))
                {
                    continue;
                }

                numbers.Add(randomNumber);
                newCollection = false;
            }
        }

        return numbers;
    }
}
