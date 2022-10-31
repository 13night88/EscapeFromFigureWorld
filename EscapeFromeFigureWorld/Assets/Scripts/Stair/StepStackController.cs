using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepStackController : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sphere")
        GameEvents.current.StepStackTriggerEnter(id);
    }
}
