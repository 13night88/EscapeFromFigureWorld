using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = 0.001f;
    [SerializeField]
    private float maximimTime = 1f;
    [SerializeField]
    private float directionThreshold = .1f;
    [SerializeField]
    private Transform controlledOdject;
    private BallMovement movementController;
    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        movementController = controlledOdject.GetComponent<BallMovement>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += StartSwipe;
        inputManager.OnEndTouch += EndSwipe;

       // inputManager.OnTouchPress += TouchPressed;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= StartSwipe;
        inputManager.OnEndTouch -= EndSwipe;

        //inputManager.OnTouchPress += TouchPressed;
    }

    private void StartSwipe(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    private void EndSwipe(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition,endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximimTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            //controlledOdject.GetComponent<BallMovement>().MoveFoward();
            DetectDirection(direction2D);
        }
        else
        {
           TouchPressed();
        }
    }

    private void DetectDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold && movementController.isGrounded)
        {
            movementController.MoveLeft();
        }else
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold && movementController.isGrounded)
        {
           movementController.MoveRight();
        }

    }

    private void TouchPressed()
    {
       if(movementController.isGrounded) movementController.MoveFoward();
    }
}
