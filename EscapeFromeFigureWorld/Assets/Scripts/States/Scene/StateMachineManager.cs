using UnityEngine;
[DefaultExecutionOrder(-3)]
public class StateMachineManager : MonoBehaviour
{

    public SceneStateMachine stateMachine;

    void Start()
    {
        stateMachine = new SceneStateMachine();
        stateMachine.Initialize(new SceneStartState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
