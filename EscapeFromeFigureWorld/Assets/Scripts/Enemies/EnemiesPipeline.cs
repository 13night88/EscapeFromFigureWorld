using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPipeline : MonoBehaviour
{

    [SerializeField] GameObject enemiesPool;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onStepStackTriggerEnter += OnStackEnded;
    }

    private void OnStackEnded(int obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
