using UnityEngine;
using TMPro;

public class ToggleButton : MonoBehaviour
{
    [Header("Skyboxes")]
    [SerializeField] private Skybox skyboxComponent;
    [SerializeField] private Material skybox1;
    [SerializeField] private Material skybox2;
    [SerializeField] private Material skybox3;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI instructionText;

    private int currentSkybox = 1;

    private void Start()
    {
        SetSkybox();
    }

    private void Update()
    {
        if (GameManager.Instance.Input.RightPrimaryTriggered)
        {
            currentSkybox++;

            if (currentSkybox > 3)
                currentSkybox = 1;

            SetSkybox();
        }
    }

    private void SetSkybox()
    {
        switch (currentSkybox)
        {
            case 1:
                skyboxComponent.material = skybox1;
                instructionText.text = "View Star Names";
                break;

            case 2:
                skyboxComponent.material = skybox2;
                instructionText.text = "View Constellations";
                break;

            case 3:
                skyboxComponent.material = skybox3;
                instructionText.text = "View Stars";
                break;
        }
    }
}