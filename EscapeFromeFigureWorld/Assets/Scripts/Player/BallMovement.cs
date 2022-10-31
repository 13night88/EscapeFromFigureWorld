using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float InitialVelocity;
    [SerializeField] float StartAngle;
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

    //IEnumerator CMovement(float v0, float angle)
    //{
    //    float t = 0;
    //    while (t < 100)
    //    {
    //        float x = v0 * t * Mathf.Cos(angle);
    //        float y = v0 * t * Mathf.Sin(angle) - (1f / 2f) * -Physics.gravity.y * Mathf.Pow(t, 2);
    //        transform.position = new Vector3(x, y, 0);
    //        t += Time.deltaTime;
    //        yield return null;
    //    }
    //}

    public void MoveFoward()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x - 1f, transform.position.y + 2f, transform.position.z);
        //transform.position = destinationPosition;
        float currentY = transform.position.y;

        StartCoroutine(Foward());
    }

    IEnumerator Foward()
    {
        transform.GetComponent<Rigidbody>().AddForce(transform.up * 100);

        yield return new WaitForSeconds(0.2f);

        transform.GetComponent<Rigidbody>().AddForce(-transform.right * 40);
    }

    public void MoveLeft()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z + 1f );
        //transform.position = destinationPosition;

        transform.GetComponent<Rigidbody>().AddForce(transform.up * 60);
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * 40);
    }

    public void MoveRight()
    {
        //Vector3 destinationPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z - 1f);
        //transform.position = destinationPosition;
        transform.GetComponent<Rigidbody>().AddForce(transform.up * 60);
        transform.GetComponent<Rigidbody>().AddForce(-transform.forward * 40);
    }

    private void GroundCheck()
    {
       RaycastHit hit;
       if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.4f + .15f)){
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
