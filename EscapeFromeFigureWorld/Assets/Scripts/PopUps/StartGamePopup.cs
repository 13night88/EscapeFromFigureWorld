using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGamePopup : PopupBase
{
    // Start is called before the first frame update
    public bool isShowed;

    public override void HidePopup(GameObject popup)
    {
        if (isShowed) popup.SetActive(false);
    }

    public override void ShowPopup(GameObject popup)
    {
        if (!isShowed) popup.SetActive(true);
    }
}
