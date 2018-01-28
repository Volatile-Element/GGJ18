using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public bool GameOverTriggered = false;

	// Use this for initialization
	void Start ()
    {
        OfficeGenerator.Instance.Generate(4, 7);

        Replace();

        FindObjectOfType<GameOverTracker>().OnGameOver.AddListener(OnGameOver);

    }
	
    public void OnGameOver()
    {
        if (GameOverTriggered)
        {
            return;
        }

        GameOverTriggered = true;

        var animator = FindObjectOfType<MigraineTracker>().GetComponent<Animator>();
        animator.enabled = true;
        animator.SetTrigger("Falldown");

        FindObjectOfType<FirstPersonController>().enabled = false;
        DoActionIn.Create(() => { SceneManager.LoadSceneAsync("Game Over"); }, 3);
    }

    private void Replace()
    {
        Replacer.Instance.Replace<CubicleSpawner>("Cubicles");
        Replacer.Instance.Replace<ComputerSpawnPoint>("Computers");
        Replacer.Instance.Replace<MouseSpawnPoint>("Mice");
        Replacer.Instance.Replace<KeyboardSpawnPoint>("Keyboards");

        var lilPrinterPrefab = Resources.Load<GameObject>("CubicalFurniture/Lil Printer");
        new RandomPicker<LilPrinterSpawnPoint>(lilPrinterPrefab, 50).CallMe();

        var radioPrefab = Resources.Load<GameObject>("CubicalFurniture/Radio");
        new RandomPicker<RadioSpawnPoint>(radioPrefab, 25).CallMe();

        var alegraPrefab = Resources.Load<GameObject>("CubicalFurniture/Alegra");
        new RandomPicker<RadioSpawnPoint>(alegraPrefab, 25).CallMe();

        var echoEncounterPrefab = Resources.Load<GameObject>("Encounters/Echo Encounter");
        new RandomPicker<echoGuySpawner>(echoEncounterPrefab, 5).CallMe();

        var deskPhonePrefab = Resources.Load<GameObject>("CubicalFurniture/Telephone");
        new RandomPicker<DeskPhoneSpawnPoint>(deskPhonePrefab, 50).CallMe();

        var mobilePhonePrefab = Resources.Load<GameObject>("CubicalFurniture/Mobile Phone");
        new RandomPicker<MobileSpawnPoint>(mobilePhonePrefab, 50, true).CallMe();

        var frame1Prefab = Resources.Load<GameObject>("CubicalFurniture/Photo Frame 1");
        new RandomPicker<PictureSpawnPoint>(frame1Prefab, 50).CallMe();

        var frame2Prefab = Resources.Load<GameObject>("CubicalFurniture/Photo Frame 2");
        new RandomPicker<PictureSpawnPoint>(frame2Prefab, 50).CallMe();

        var frame3Prefab = Resources.Load<GameObject>("CubicalFurniture/Photo Frame 3");
        new RandomPicker<PictureSpawnPoint>(frame3Prefab, 50).CallMe();

        var frame4Prefab = Resources.Load<GameObject>("CubicalFurniture/Photo Frame 4");
        new RandomPicker<PictureSpawnPoint>(frame4Prefab, 50).CallMe();

        var plantPrefab = Resources.Load<GameObject>("CubicalFurniture/Plant");
        new RandomPicker<PlantSpawner>(plantPrefab, 50, true).CallMe();

        var chairWithEasterEggPrefab = Resources.Load<GameObject>("Encounters/ChairWithEasterEgg");
        new RandomPicker<ChairSpawnPoint>(chairWithEasterEggPrefab, 1).CallMe();

        var chairPrefab = Resources.Load<GameObject>("CubicalFurniture/Chair");
        new RandomPicker<ChairSpawnPoint>(chairPrefab, 1000, true).CallMe();

        var waterCoolerPrefab = Resources.Load<GameObject>("Encounters/Water Cooler Encounter");
        new RandomPicker<ExternalEncounterSpawnPoint>(waterCoolerPrefab, 6).CallMe();

        var phoneGuyPrefab = Resources.Load<GameObject>("Encounters/Phone Guy Encounter");
        new RandomPicker<ExternalEncounterSpawnPoint>(phoneGuyPrefab, 8).CallMe();

        var largePrinterPrefab = Resources.Load<GameObject>("Encounters/Large Printer");
        new RandomPicker<ExternalEncounterSpawnPoint>(largePrinterPrefab, 10).CallMe();

        //Internal
        new RandomPicker<InternalEncounterSpawnPoint>(waterCoolerPrefab, 5).CallMe();
        new RandomPicker<InternalEncounterSpawnPoint>(phoneGuyPrefab, 5).CallMe();
        new RandomPicker<InternalEncounterSpawnPoint>(largePrinterPrefab, 5).CallMe();

        var decWaterCool = Resources.Load<GameObject>("Decorations/Water Cooler");
        new RandomPicker<InternalEncounterSpawnPoint>(decWaterCool, 5).CallMe();
    }
}