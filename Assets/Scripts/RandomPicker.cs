using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomPicker<T> where T : MonoBehaviour
{
    private IList<T> spawnObjects { get; set; }
    private int SpawnCount { get; set; }
    private GameObject NewType { get; set; }

    public RandomPicker(GameObject newType, int spawnCount)
    {
        NewType = newType;
        SpawnCount = spawnCount;
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

	        GameObject newObject = PrefabUtility.InstantiatePrefab(NewType) as GameObject;

            newObject.transform.rotation = oldObject.transform.rotation;
	        newObject.transform.position = oldObject.transform.position;
	        newObject.transform.parent = oldObject.transform.parent;

            GameObject.DestroyImmediate(oldObject);
	    }
	}

    private IList<int> GetRandomNumbers(int amount, int max)
    {
        if (amount > max)
        {
            throw new Exception("Argggg");
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
