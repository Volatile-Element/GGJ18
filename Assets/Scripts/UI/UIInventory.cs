using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private void Start()
    {
        var inventory = FindObjectOfType<InventoryManager>();

        inventory.OnCollectedGlass += OnCollectedGlass;
        inventory.OnCollectedPainKiller += OnCollectedPainKiller;
        inventory.OnCollectedWater += OnCollectedWater;
        inventory.OnConsumedWater += OnConsumedWater;
    }

    public void OnCollectedGlass(bool value)
    {
        UITool.Get<Image>(transform, "imgGlass").color = new Color(1, 1, 1, 1);
    }

    public void OnCollectedPainKiller(bool value)
    {
        UITool.Get<Image>(transform, "imgPainKillers").color = new Color(1, 1, 1, 1);
    }

    public void OnCollectedWater(bool value)
    {
        UITool.Get<Image>(transform, "imgWater").color = new Color(0.521568627451f, 0.760784313725f, 1, 1);
    }

    public void OnConsumedWater(bool value)
    {
        UITool.Get<Image>(transform, "imgWater").color = new Color(0.521568627451f, 0.760784313725f, 1, 0.0588235294118f);
    }
}