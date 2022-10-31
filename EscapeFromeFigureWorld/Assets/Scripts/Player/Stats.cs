using TMPro;
using UnityEngine;
public class Stats : MonoBehaviour
{

    public static int score;
    [SerializeField] TextMeshProUGUI scoreField;
    void Start()
    {
        GameEvents.current.onStepStackTriggerEnter += OnStackEnded;
    }

    private void OnStackEnded(int id)
    {
        score++;
        scoreField.text = score.ToString();

    }
}
