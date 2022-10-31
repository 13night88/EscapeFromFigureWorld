using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PopupsManager : MonoBehaviour
{
    public delegate void ShowPopup(String popupName);
    public event ShowPopup OnShowPopup;
    public delegate void HidePopup(String popupName);
    public event ShowPopup OnHidePopup;

    //public static PopupsManager popupsManager;
    private static Transform _popup;
    public static GameObject popupsCanvas;

    private void OnDisable()
    {
        OnShowPopup -= ShowPopupEvent;
        OnHidePopup -= HidePopupEvent;
    }
    private void Start()
    {
        popupsCanvas = GameObject.Find("Canvas");
        OnShowPopup += ShowPopupEvent;
        OnHidePopup += HidePopupEvent;
    }

    public static void ShowPopupEvent(String popupName)
    {
        _popup = popupsCanvas.transform.Find(popupName);
        _popup.gameObject.SetActive(true);
    }

    public static void HidePopupEvent(String popupName)
    {
        _popup = popupsCanvas.transform.Find(popupName);
        _popup.gameObject.SetActive(false);
    }
}
