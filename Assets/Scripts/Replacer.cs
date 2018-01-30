using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Replacer : Singleton<Replacer>
{
    public void Replace<T>(string resourceDirectory) where T : MonoBehaviour
    {
        var replacements = Resources.LoadAll<GameObject>(resourceDirectory);

        Replace<T>(replacements);
    }

    public void Replace<T>(GameObject[] replacements) where T : MonoBehaviour
    {
        var objects = FindObjectsOfType<T>();

        foreach (var obj in objects)
        {
            var replacement = replacements.Skip(replacements.Length - 1).FirstOrDefault();

            Instantiate(replacement, obj.transform.position, obj.transform.rotation);
        }
    }
}