using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGamePopup : PopupBase
{
    [SerializeField]
    Text scoreText;
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

    private void OnEnable()
    {
        Debug.Log("Activated");
        scoreText.text = Constants.SCORE_TEXT + Stats.score.ToString();
    }
}
