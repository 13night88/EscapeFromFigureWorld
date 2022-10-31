using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public static void CloseGame()
    {
        PopupsManager.HidePopupEvent("EndGamePopUp");
        Application.Quit();
    }
}
