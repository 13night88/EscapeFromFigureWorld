using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public abstract void ShowPopup(GameObject popup);
    public abstract void HidePopup(GameObject popup);
}
