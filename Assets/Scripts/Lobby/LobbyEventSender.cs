using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyEventSender : MonoBehaviour
{
    const string UI_EVENT_TYPE = "UI_EVENT";

    public void LoadScene(int id)
    {
        EventDispatcher.SendEvent(UI_EVENT_TYPE, new EventData("LoadScene", id));
    }
}
