using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    private UIFade uiFade;

    private void Awake()
    {
        uiFade = FindObjectOfType<UIFade>();
    }

    private void Start ()
    {
        SetupIntroText();
    }

    public void SetupIntroText()
    {
        DoActionIn.Create(() => { uiFade.FadeTextInAndOut("It's a Monday.."); }, 0);
        DoActionIn.Create(() => { uiFade.FadeTextInAndOut("You have a migraine.."); }, 4);
        DoActionIn.Create(() => { uiFade.FadeTextInAndOut("You need a glass, some water and some pain killers."); }, 8);
        DoActionIn.Create(() => { uiFade.SetText(""); }, 12);
        DoActionIn.Create(() => { uiFade.FadeToTransparent(); }, 12);

        DoActionIn.Create(() =>
        {
            var animator = FindObjectOfType<MigraineTracker>().GetComponent<Animator>();
            animator.enabled = true;
            animator.SetTrigger("Start");

            DoActionIn.Create(() => { animator.enabled = false; }, 14);
        }, 12);
    }
}