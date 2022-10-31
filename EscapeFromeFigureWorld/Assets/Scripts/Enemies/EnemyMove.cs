using System;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class EnemyMove : MonoBehaviour
{
    StateMachineManager statesManager;

    Transform enemyPool;
    private void Start()
    {
        enemyPool = GameObject.Find("EnemyPool").transform;
        //if (managers == null) throw new NullReferenceException();
        statesManager = GameObject.Find("Managers").GetComponent<StateMachineManager>();
    }

    void Update()
    {
       transform.Translate(-1 * Time.deltaTime, 0, 0 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Sphere")
        {
            Debug.Log("Game Over");
            statesManager?.stateMachine.ChangeState(new SceneExitState());
        }
    }

    private void OnBecameInvisible()
    {
        
        this.transform.position = new Vector3(enemyPool.position.x-0.2f, enemyPool.position.y + 1, enemyPool.transform.position.z);
    }
}
