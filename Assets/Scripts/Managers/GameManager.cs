using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        OfficeGenerator.Instance.Generate(5, 5);

        Replace();

        FindObjectOfType<GameOverTracker>().OnGameOver.AddListener(OnGameOver);

    }
	
    public void OnGameOver()
    {
        FindObjectOfType<MigraineTracker>().GetComponent<Animator>().enabled = true;
        DoActionIn.Create(() => { SceneManager.LoadSceneAsync("Game Over"); }, 1.4f);
    }

    private void Replace()
    {
        Replacer.Instance.Replace<CubicleSpawner>("Cubicles");

        var peoplePrefab = Resources.Load<GameObject>("Encounters/People");
        new RandomPicker<PeopleSpawner>(peoplePrefab, 3).CallMe();
    }
}