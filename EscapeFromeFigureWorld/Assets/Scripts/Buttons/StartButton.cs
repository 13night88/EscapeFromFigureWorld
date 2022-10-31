using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    StateMachineManager statesManager;

    private void OnEnable()
    {
        statesManager = GameObject.Find("Managers").GetComponent<StateMachineManager>();
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        Time.timeScale = 1;
        PopupsManager.HidePopupEvent("StartGamePopup");

        //statesManager.stateMachine.ChangeState(new SceneRunnigState());
    }

}
