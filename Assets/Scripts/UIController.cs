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

    private ButtonColor myDataClass;

    void Awake()
    {
        // подписываемся на события и указываем методы, которые будут вызваны при возникновение этого события
        Messenger.AddListener(GameEvent.GAME_STARTED, OnGameStarted);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_STARTED, OnGameStarted);
    }

    // будет вызван при получении события GAME_STARTED
    private void OnGameStarted()
    {
        Debug.Log("Start"); // create
    }


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
