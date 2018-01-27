using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMigraineProgress : MonoBehaviour
{
    public float LastMigraineValue = 0;

    private Image redMask;

    private void Awake()
    {
        redMask = UITool.Get<Image>(transform, "Red Mask");
    }

    void Start ()
    {
        FindObjectOfType<MigraineTracker>().OnCurrentMigraineLevelPercentageChange.AddListener(OnCurrentMigraineLevelPercentageChange);
	}

    public void OnCurrentMigraineLevelPercentageChange(float percentage)
    {
        var percentageChange = percentage - LastMigraineValue; //TODO: Show this for juice.

        redMask.rectTransform.offsetMax = new Vector2(redMask.rectTransform.offsetMax.x, -(100 - percentage));
    }
}