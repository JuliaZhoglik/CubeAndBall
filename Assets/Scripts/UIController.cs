using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

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

    public void OnBack()
    {
        OnCloseSettings();
        // Уведомляем о выходе из меню
        Messenger.Broadcast(GameEvent.BACK);
    }

}
