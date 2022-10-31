using UnityEngine;
public class SceneStartState : SceneBaseState
{
    public override void Enter()
    {
        Time.timeScale = 0;
        PopupsManager.ShowPopupEvent("StartGamePopup");
    }

    public override void Exit()
    {
        Debug.Log("Смена статуса");
    }

}
