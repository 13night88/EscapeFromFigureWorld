using UnityEngine;
using System.Linq;
using System;

public class StairPipleline : MonoBehaviour
{
    private GameObject[] stepStacks;

    [SerializeField] GameObject enemyPool;

    private int previousId;

    void Start()
    {
        stepStacks = GameObject.FindGameObjectsWithTag("StepStack");

        stepStacks = stepStacks.OrderByDescending(x => x.name).ToArray();

        GameEvents.current.onStepStackTriggerEnter += OnLastStepTriggered;
    }

    private void OnLastStepTriggered(int id)
    {

        if (previousId != id)
        {
            stepStacks[stepStacks.Length - 1].transform.position = new Vector3(stepStacks[0].transform.position.x - 3, stepStacks[0].transform.position.y + 3, stepStacks[0].transform.position.z);

            var temp = stepStacks[stepStacks.Length - 1];

            Array.Copy(stepStacks, 0, stepStacks, 1, stepStacks.Length - 1);

            stepStacks[0] = temp;

            enemyPool.transform.position = stepStacks[0].transform.position;

            previousId = id;


        }
    }
}
