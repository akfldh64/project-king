using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : Page
{
    public void LoadManage()
    {
        var controller = caller.GetComponent<SceneController>();
        controller.LoadPage("Manage Page");
        controller.HideUI();
    }
}
