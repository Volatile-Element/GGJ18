﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        OfficeGenerator.Instance.Generate(4, 7);

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
        Replacer.Instance.Replace<ComputerSpawnPoint>("Computers");
        Replacer.Instance.Replace<MouseSpawnPoint>("Mice");
        Replacer.Instance.Replace<KeyboardSpawnPoint>("Keyboards");

        var lilPrinterPrefab = Resources.Load<GameObject>("CubicalFurniture/Lil Printer");
        new RandomPicker<LilPrinterSpawnPoint>(lilPrinterPrefab, 50).CallMe();

        var radioPrefab = Resources.Load<GameObject>("CubicalFurniture/Radio");
        new RandomPicker<RadioSpawnPoint>(radioPrefab, 25).CallMe();

        var alegraPrefab = Resources.Load<GameObject>("CubicalFurniture/Alegra");
        new RandomPicker<RadioSpawnPoint>(alegraPrefab, 25).CallMe();

        var deskPhonePrefab = Resources.Load<GameObject>("CubicalFurniture/Telephone");
        new RandomPicker<DeskPhoneSpawnPoint>(deskPhonePrefab, 50).CallMe();

        var mobilePhonePrefab = Resources.Load<GameObject>("CubicalFurniture/Mobile Phone");
        new RandomPicker<MobileSpawnPoint>(mobilePhonePrefab, 50, true).CallMe();

        var plantPrefab = Resources.Load<GameObject>("CubicalFurniture/Plant");
        new RandomPicker<PlantSpawner>(plantPrefab, 50, true).CallMe();

        var chairPrefab = Resources.Load<GameObject>("CubicalFurniture/Chair");
        new RandomPicker<ChairSpawnPoint>(chairPrefab, 1000, true).CallMe();

        var waterCoolerPrefab = Resources.Load<GameObject>("Encounters/Water Cooler Encounter");
        new RandomPicker<ExternalEncounterSpawnPoint>(waterCoolerPrefab, 6).CallMe();

        var phoneGuyPrefab = Resources.Load<GameObject>("Encounters/Phone Guy Encounter");
        new RandomPicker<ExternalEncounterSpawnPoint>(phoneGuyPrefab, 8).CallMe();

        var echoEncounterPrefab = Resources.Load<GameObject>("Encounters/Echo Encounter");
        new RandomPicker<ExternalEncounterSpawnPoint>(echoEncounterPrefab, 5).CallMe();

        var largePrinterPrefab = Resources.Load<GameObject>("Encounters/Large Printer");
        new RandomPicker<ExternalEncounterSpawnPoint>(largePrinterPrefab, 10).CallMe();

        //Internal
        new RandomPicker<InternalEncounterSpawnPoint>(waterCoolerPrefab, 5).CallMe();
        new RandomPicker<InternalEncounterSpawnPoint>(phoneGuyPrefab, 5).CallMe();
        new RandomPicker<InternalEncounterSpawnPoint>(echoEncounterPrefab, 5).CallMe();
        new RandomPicker<InternalEncounterSpawnPoint>(largePrinterPrefab, 5).CallMe();
    }
}