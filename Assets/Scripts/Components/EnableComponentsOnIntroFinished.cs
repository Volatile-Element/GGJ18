using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComponentsOnIntroFinished : MonoBehaviour
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void Start()
    {
        FindObjectOfType<IntroController>().OnIntroFinished.AddListener(OnIntroFinished);
    }

    public void OnIntroFinished()
    {
        canvas.enabled = true;
    }
}