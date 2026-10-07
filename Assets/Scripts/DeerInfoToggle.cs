using UnityEngine;

public class DeerInfoToggle : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;

    private void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    public void ToggleInfo()
    {
        if (infoPanel == null)
            return;

        infoPanel.SetActive(!infoPanel.activeSelf);
    }

    public void ShowInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}