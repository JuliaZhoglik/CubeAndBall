using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonFigure : MonoBehaviour
{

    public void OnClickButtonFigure(string figure)
    {
        Messenger<string>.Broadcast(GameEvent.SELECT_FIGURE, figure);
    }

}
