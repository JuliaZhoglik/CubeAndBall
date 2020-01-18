using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{


    void Awake()
    {
        Messenger<Transform>.AddListener(GameEvent.LOOK_AT_FIGURE, LookAtFigure);
        Messenger.AddListener(GameEvent.BACK, LookAtAll);
    }

    void OnDestroy()
    {
        Messenger<Transform>.RemoveListener(GameEvent.LOOK_AT_FIGURE, LookAtFigure);
        Messenger.RemoveListener(GameEvent.BACK, LookAtAll);
    }

    // будет вызван при получении события LOOK_AT_FIGURE
    void LookAtFigure(Transform target)
    {
        transform.LookAt(target);
    }

    // будет вызван при получении события BACK
    void LookAtAll()
    {
        transform.LookAt( Vector3.zero );
    }

 
}
