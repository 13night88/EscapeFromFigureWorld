using TMPro;
using UnityEngine;
public class Stats : MonoBehaviour
{

    public static int score;

    private int currentId = 0;

    [SerializeField] TextMeshProUGUI scoreField;
    void Start()
    {
        GameEvents.current.onStepStackTriggerEnter += OnStackEnded;
    }

    private void OnStackEnded(int id)
    {
        if (currentId != id) score++;
        scoreField.text = score.ToString();

    }
}
