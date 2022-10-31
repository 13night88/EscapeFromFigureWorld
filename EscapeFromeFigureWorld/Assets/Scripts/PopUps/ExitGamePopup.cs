using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGamePopup : PopupBase
{
    // Start is called before the first frame update
    public bool isShowed;

    public override void HidePopup(GameObject popup)
    {
        popup.SetActive(false);
    }

    public override void ShowPopup(GameObject popup)
    {
        popup.SetActive(true);
    }
}
