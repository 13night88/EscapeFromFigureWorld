using UnityEngine;
using UnityEngine.UI;

public class StandartSwipeControls : MonoBehaviour
{
    [SerializeField]
    private Transform controlledOdject;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isTouchStopped = false;

    public float swipeRange;
    public float tapRange;

    private BallMovement movementController;
    private void Awake()
    { 
       movementController = controlledOdject.GetComponent<BallMovement>();
    }

    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

            Debug.Log(startTouchPosition);
            //text.text = startTouchPosition.ToString();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentTouchPosition = Input.GetTouch(0).position;
            Vector2 distance = currentTouchPosition - startTouchPosition;
            DetectDirection(distance);
            
        }

        DetectTap();
    }

    public void DetectDirection(Vector2 distance)
    {
        if (!isTouchStopped && movementController.isGrounded)
        {
            if (distance.x > swipeRange)
            {
                movementController.MoveLeft();
                isTouchStopped = true;
            }else

            if (distance.x < -swipeRange)
            {
                movementController.MoveRight();
                isTouchStopped = true;
            }            
        }      
    }



    private void DetectTap()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            isTouchStopped = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(distance.x) < tapRange && Mathf.Abs(distance.y) < tapRange && movementController.isGrounded)
            {
                movementController.MoveFoward();
            }
        }
    }
}
