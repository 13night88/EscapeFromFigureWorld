using System;
using UnityEngine;

[DefaultExecutionOrder(100)]
public class SceneExitState : SceneBaseState
{
    public override void Enter()
    {
        PopupsManager.ShowPopupEvent("EndGamePopUp");
        Time.timeScale = 0;
    }

    public override void Exit()
    {
        PopupsManager.HidePopupEvent("EndGamePopUp");
    }
}
