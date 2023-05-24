using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    public UIModel model;
    private UIController controller;

    private void Awake()
    {
        controller = new UIController(this, model);
    }

    private void Start()
    {
        controller.SubscribeEvents();
    }

    public void RequestedSceneRestart()
    {
        if (model.isRestartRequested)
            return;

        model.isRestartRequested = true;
        controller.RestartScene();
    }
}
