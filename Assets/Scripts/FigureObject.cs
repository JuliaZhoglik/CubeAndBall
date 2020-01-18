using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FigureObject : MonoBehaviour
{
    private bool FigureSelect = false;

    // будет вызван при получении события COLOR
    void OnColorChanged(Color value)
    {
        if (FigureSelect)
        {
            GetComponent<Renderer>().material.color = value;
            PlayerPrefs.SetFloat(name + "r", value.r);
            PlayerPrefs.SetFloat(name + "g", value.g);
            PlayerPrefs.SetFloat(name + "b", value.b);
            PlayerPrefs.SetFloat(name + "a", value.a);
            Messenger<Color>.Broadcast(GameEvent.SELECT_BUTTON, value);
        }
    }


    void Awake()
    {
        Color DefaultColor = new Color32(255, 255, 255, 255);
        if (name == "Cube")
        {
            DefaultColor = new Color32(0, 0, 0, 255);
        }
        Color FigureColor;
        FigureColor.r = PlayerPrefs.GetFloat(name + "r", DefaultColor.r);
        FigureColor.g = PlayerPrefs.GetFloat(name + "g", DefaultColor.g);
        FigureColor.b = PlayerPrefs.GetFloat(name + "b", DefaultColor.b);
        FigureColor.a = PlayerPrefs.GetFloat(name + "a", DefaultColor.a);
        GetComponent<Renderer>().material.color = FigureColor;

        Messenger<Color>.AddListener(GameEvent.COLOR, OnColorChanged);
        Messenger<string>.AddListener(GameEvent.SELECT_FIGURE, OnSelect);
        Messenger.AddListener(GameEvent.BACK, OnUnselect);
    }

    void OnDestroy()
    {
        Messenger<Color>.RemoveListener(GameEvent.COLOR, OnColorChanged);
        Messenger<string>.RemoveListener(GameEvent.SELECT_FIGURE, OnSelect);
        Messenger.RemoveListener(GameEvent.BACK, OnUnselect);
    }

    // будет вызван при получении события SELECT_FIGURE
    void OnSelect(string figure)
    {
        gameObject.SetActive(false);
        FigureSelect = false;
        if (name == figure)
        {
            gameObject.SetActive(true);
            FigureSelect = true;
            Messenger<Color>.Broadcast(GameEvent.SELECT_BUTTON, GetComponent<Renderer>().material.color);
            Messenger<Transform>.Broadcast(GameEvent.LOOK_AT_FIGURE, transform);
        }
    }

    // будет вызван при получении события BACK
    void OnUnselect()
    {
        gameObject.SetActive(true);
        FigureSelect = false;
    }
}
