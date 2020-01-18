using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonColor : MonoBehaviour
{

    void Awake()
    {
        // подписываемся на события и указываем методы, которые будут вызваны при возникновение этого события
        Messenger<Color>.AddListener(GameEvent.SELECT_BUTTON, OnSelectButtonColor);
        Color32 ColorButton = GetComponent<Image>().color;
        float SumColor = ColorButton.r + ColorButton.g + ColorButton.b;
        Debug.Log(name + "SumColor = " + SumColor);
        if (SumColor  > ((255 + 255 + 255) / 2))
        {
            Debug.Log(name + "Black");
            GetComponentInChildren<Text>(true).color = new Color32(0, 0, 0, 255); // black
        }
        else
        {
            Debug.Log(name + "White");
            GetComponentInChildren<Text>(true).color = new Color32(255, 255, 255, 255); // white
        }
    }

    void OnDestroy()
    {
        Messenger<Color>.RemoveListener(GameEvent.SELECT_BUTTON, OnSelectButtonColor);
    }

    private void OnSelectButtonColor(Color value)
    {
        GetComponentInChildren<Text>(true).text = "";
        if (value == GetComponent<Image>().color)
        {
            GetComponentInChildren<Text>(true).text = "Этот цвет выбран";
        }
    }

    // будет вызван при получении события SELECT_BUTTON
    public void OnClickButtonColor()
    {
        Messenger<Color>.Broadcast(GameEvent.COLOR, GetComponent<Image>().color);
    }



}
