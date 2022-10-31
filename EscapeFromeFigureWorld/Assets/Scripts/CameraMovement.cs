using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform targetTransform;

    [Range(0.1f,1f)]
    [SerializeField] float oncomingSpeed;
    void Update()
    {
        CameraFollowing();
    }

    private void CameraFollowing()
    {
       transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetTransform.position.x+7, Time.deltaTime * oncomingSpeed),
           Mathf.Lerp(transform.position.y, targetTransform.position.y + 3, Time.deltaTime * oncomingSpeed), 
           transform.position.z);
    }
}
