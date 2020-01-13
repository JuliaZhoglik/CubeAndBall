using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private SettingsPopup PanelMain;
    [SerializeField] private SettingsPopup PanelColor;
    void Start()
    {
        OnCloseSettings();
    }

    public void OnOpenSettings()
    {
        PanelMain.Close();
        PanelColor.Open();
    }

    public void OnCloseSettings()
    {
        PanelMain.Open();
        PanelColor.Close();
    }
}
