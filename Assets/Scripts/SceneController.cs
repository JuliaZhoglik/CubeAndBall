using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Уведомляем, что игра началась
        Messenger.Broadcast(GameEvent.GAME_STARTED);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
