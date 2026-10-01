using UnityEngine;

public class DeerHoverHighlight : MonoBehaviour
{
    [SerializeField] private Renderer deerRenderer;

    [Header("Hover Appearance")]
    [SerializeField] private Color hoverColor = new Color(0.1f, 0.45f, 1.0f);
    [SerializeField] private float emissionIntensity = 2.5f;

    private Material deerMaterial;

    private Color originalBaseColor;
    private Color originalEmissionColor;

    private bool hadEmissionEnabled;

    private void Awake()
    {
        if (deerRenderer == null)
            deerRenderer = GetComponent<Renderer>();

        if (deerRenderer == null)
            return;

        // Creates an instance so this deer can change independently.
        deerMaterial = deerRenderer.material;

        if (deerMaterial.HasProperty("_BaseColor"))
            originalBaseColor = deerMaterial.GetColor("_BaseColor");

        if (deerMaterial.HasProperty("_EmissionColor"))
            originalEmissionColor = deerMaterial.GetColor("_EmissionColor");

        hadEmissionEnabled = deerMaterial.IsKeywordEnabled("_EMISSION");
    }

    public void HighlightOn()
    {
        if (deerMaterial == null)
            return;

        if (deerMaterial.HasProperty("_BaseColor"))
            deerMaterial.SetColor("_BaseColor", hoverColor);

        if (deerMaterial.HasProperty("_EmissionColor"))
        {
            deerMaterial.EnableKeyword("_EMISSION");
            deerMaterial.SetColor(
                "_EmissionColor",
                hoverColor * emissionIntensity
            );
        }
    }

    public void HighlightOff()
    {
        if (deerMaterial == null)
            return;

        if (deerMaterial.HasProperty("_BaseColor"))
            deerMaterial.SetColor("_BaseColor", originalBaseColor);

        if (deerMaterial.HasProperty("_EmissionColor"))
            deerMaterial.SetColor("_EmissionColor", originalEmissionColor);

        if (!hadEmissionEnabled)
            deerMaterial.DisableKeyword("_EMISSION");
    }
}