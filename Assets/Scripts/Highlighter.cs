using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private List<Renderer> renderers = new List<Renderer>();

    [Header("Highlight Appearance")]
    [SerializeField] private Color hoverColor = new Color(0.1f, 0.45f, 1.0f);
    [SerializeField] private float emissionIntensity = 2.5f;

    private List<Material> materials = new List<Material>();
    private List<Color> originalBaseColors = new List<Color>();
    private List<Color> originalEmissionColors = new List<Color>();
    private List<bool> hadEmissionEnabled = new List<bool>();

    private void Awake()
    {
        foreach (Renderer renderer in renderers)
        {
            if (renderer == null)
                continue;

            Material material = renderer.material;

            materials.Add(material);

            if (material.HasProperty("_BaseColor"))
                originalBaseColors.Add(material.GetColor("_BaseColor"));
            else
                originalBaseColors.Add(Color.white);

            if (material.HasProperty("_EmissionColor"))
                originalEmissionColors.Add(material.GetColor("_EmissionColor"));
            else
                originalEmissionColors.Add(Color.black);

            hadEmissionEnabled.Add(material.IsKeywordEnabled("_EMISSION"));
        }
    }

    public void HighlightOn()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            Material material = materials[i];

            if (material.HasProperty("_BaseColor"))
                material.SetColor("_BaseColor", hoverColor);

            if (material.HasProperty("_EmissionColor"))
            {
                material.EnableKeyword("_EMISSION");
                material.SetColor(
                    "_EmissionColor",
                    hoverColor * emissionIntensity
                );
            }
        }
    }

    public void HighlightOff()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            Material material = materials[i];

            if (material.HasProperty("_BaseColor"))
                material.SetColor("_BaseColor", originalBaseColors[i]);

            if (material.HasProperty("_EmissionColor"))
                material.SetColor("_EmissionColor", originalEmissionColors[i]);

            if (!hadEmissionEnabled[i])
                material.DisableKeyword("_EMISSION");
        }
    }
}