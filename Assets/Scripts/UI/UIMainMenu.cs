﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public Canvas HowToPlay;

    private void Start()
    {
        SoundManager.Instance.PlayLoop("Audio/Main Menu/Main Menu");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        OfficeGenerator.Instance.Generate(4, 7);

        Replacer.Instance.Replace<CubicleSpawner>("Cubicles");
        Replacer.Instance.Replace<ComputerSpawnPoint>("Computers");
        Replacer.Instance.Replace<MouseSpawnPoint>("Mice");
        Replacer.Instance.Replace<KeyboardSpawnPoint>("Keyboards");

        var plantPrefab = Resources.Load<GameObject>("CubicalFurniture/Plant");
        new RandomPicker<PlantSpawner>(plantPrefab, 50, true).CallMe();

        var chairPrefab = Resources.Load<GameObject>("CubicalFurniture/Chair");
        new RandomPicker<ChairSpawnPoint>(chairPrefab, 1000, true).CallMe();

        var decWaterCool = Resources.Load<GameObject>("Decorations/Water Cooler");
        new RandomPicker<InternalEncounterSpawnPoint>(decWaterCool, 5).CallMe();

        var decPlant = Resources.Load<GameObject>("Decorations/Plant");
        new RandomPicker<InternalEncounterSpawnPoint>(decPlant, 5).CallMe();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Game View");
    }

    public void OpenHowToPlay()
    {
        HowToPlay.enabled = true;
    }

    public void CloseHowToPlay()
    {
        HowToPlay.enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}