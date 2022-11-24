using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float InitialVelocity;
    [SerializeField] float StartAngle;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip jumpClip, swipeClip;

    [SerializeField] float minDistanceToGround = .15f;

    private ParticleSystem ballHalo;
    private bool isHaloPlayed;
    public bool isGrounded;
    private void Awake()
    {
        ballHalo = transform.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        GroundCheck();
    }

    public void MoveFoward()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x - 1f, transform.position.y + 2f, transform.position.z);
        //transform.position = destinationPosition;
        float currentY = transform.position.y;

        StartCoroutine(Foward());
    }

    IEnumerator Foward()
    {
        audioSource.PlayOneShot(jumpClip);

        transform.GetComponent<Rigidbody>().AddForce(transform.up * 100);

        yield return new WaitForSeconds(0.2f);

        transform.GetComponent<Rigidbody>().AddForce(-transform.right * 40);
    }

    public void MoveLeft()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 1f );
        //transform.position = destinationPosition;

        audioSource.PlayOneShot(swipeClip);

        transform.GetComponent<Rigidbody>().AddForce(transform.up * 60);
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * 40);
    }

    public void MoveRight()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z - 1f);
        //transform.position = destinationPosition;
        audioSource.PlayOneShot(swipeClip);

        transform.GetComponent<Rigidbody>().AddForce(transform.up * 60);
        transform.GetComponent<Rigidbody>().AddForce(-transform.forward * 40);
    }

    private void GroundCheck()
    {
       RaycastHit hit;
       if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.4f + minDistanceToGround)){
            if(hit.collider.gameObject.tag != "StepStack") isGrounded = true;
            if (!isHaloPlayed)
            {
                ballHalo.Play();
                isHaloPlayed = true;               
            }
        }
        else
        {
            isGrounded = false;
            isHaloPlayed = false;
        }
    }

}
