using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetText(string text)
    {
        UITool.Get<Text>(transform, "txtText").text = text;
    }

    public void FadeToTransparent()
    {
        animator.SetTrigger("Fade to Transparent");
    }

    public void FadeTextInAndOut()
    {
        animator.SetTrigger("Fade Text");
    }

    public void FadeTextInAndOut(string text)
    {
        SetText(text);
        FadeTextInAndOut();
    }
}