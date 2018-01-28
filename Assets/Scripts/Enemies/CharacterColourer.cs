using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterColourer : MonoBehaviour
{
    private void Start()
    {
        var renderers = transform.GetComponentsInChildren<SkinnedMeshRenderer>();

        var materialsAndColours = new Dictionary<string, Color[]>()
        {
            { "Guy_Coat (Instance)", new [] { Color.black } },
            { "Guy_Cuffs (Instance)", new [] { Color.white } },
            { "Guy_Fluff_Coat (Instance)", new [] { Color.white } },
            { "Guy_Hair (Instance)", GetHairColours() },
            { "Guy_Shirt (Instance)", new [] { Color.white } },
            { "Guy_Shoes (Instance)", new [] { Color.black } },
            { "Guy_Skin (Instance)", GetSkinColours() },
            { "Guy_Trousers (Instance)", new [] { Color.black } }
        };

        //Coat, Cuffs,Fluff_Coat, Hair, Shirt, Shoes, Skin, Trousers
        foreach (var renderer in renderers)
        {
            var rendererMaterials = renderer.materials;
            var newMaterials = new List<Material>();

            for (int m = 0; m < rendererMaterials.Length; m++)
            {

                if (!materialsAndColours.ContainsKey(rendererMaterials[m].name))
                {
                    newMaterials.Add(rendererMaterials[m]);
                    continue;
                }

                var color = materialsAndColours[rendererMaterials[m].name].Skip(Random.Range(0, materialsAndColours[rendererMaterials[m].name].Length - 1)).FirstOrDefault();
                newMaterials.Add(new Material(rendererMaterials[m]) { color = color });
            }

            renderer.materials = newMaterials.ToArray();
        }
    }

    private Color[] GetSkinColours()
    {
        //http://www.collectedwebs.com/art/colors/skin_tones/
        var colors = new[]
        {
            new Color32(255,223,196, 255),
            new Color32(240,213,190, 255),
            new Color32(238,206,179, 255),
            new Color32(225,184,153, 255),
            new Color32(229,194,152, 255),
            new Color32(255,220,178, 255),
            new Color32(229,184,143, 255),
            new Color32(229,160,115, 255),
            new Color32(231,158,109, 255),
            new Color32(219,144,101, 255),
            new Color32(206,150,124, 255),
            new Color32(198,120,86, 255),
            new Color32(186,108,73, 255),
            new Color32(165,114,87, 255),
            new Color32(240,200,201, 255),
            new Color32(221,168,160, 255),
            new Color32(185,124,109, 255),
            new Color32(168,117,108, 255),
            new Color32(173,100,82, 255),
            new Color32(92,56,54, 255),
            new Color32(203,132,66, 255),
            new Color32(189,114,60, 255),
            new Color32(112,65,57, 255),
            new Color32(163,134,106, 255)
        };

        return colors.Select(x => new Color(CalculateColor(x.r), CalculateColor(x.g), CalculateColor(x.b), CalculateColor(x.a))).ToArray();
    }

    private Color[] GetHairColours()
    {
        var colors = new[]
        {
            new Color32(009,008,006,255),
            new Color32(044,034,043,255),
            new Color32(113,099,090,255),
            new Color32(183,166,158,255),
            new Color32(214,196,194,255),
            new Color32(202,191,177,255),
            new Color32(220,208,186,255),
            new Color32(255,245,225,255),
            new Color32(230,206,168,255),
            new Color32(229,200,168,255),
            new Color32(222,188,153,255),
            new Color32(184,151,120,255),
            new Color32(165,107,070,255),
            new Color32(181,082,057,255),
            new Color32(141,074,067,255),
            new Color32(145,085,061,255),
            new Color32(083,061,050,255),
            new Color32(059,048,036,255),
            new Color32(085,072,056,255),
            new Color32(078,067,063,255),
            new Color32(080,068,068,255),
            new Color32(106,078,066,255),
            new Color32(167,133,106,255),
            new Color32(151,121,097,255)
        };

        return colors.Select(x => new Color(CalculateColor(x.r), CalculateColor(x.g), CalculateColor(x.b), CalculateColor(x.a))).ToArray();
    }

    private float CalculateColor(float colour)
    {
        return ((100f / 255f) * colour) / 100f;
    }
}