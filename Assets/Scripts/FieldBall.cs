
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FieldBall : UdonSharpBehaviour
{
    public Env Env;
    private string objName;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider other)
    {

        objName = other.gameObject.name;
        if (objName == Env.Goal1 || objName == Env.Goal2)
        {

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Vector3 BallPosition = Env.FieldBallPoint.transform.position;
            this.transform.position = BallPosition;


        }

        /* if (this.gameObject.Tag == "Ball")
        {
            Destroy(other);
        } */

    }
    public void OnCollisionEnter(Collision other)
    {

        objName = other.gameObject.name;
        if (objName == Env.FloorName)
        {

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Vector3 BallPosition = Env.FieldBallPoint.transform.position;
            this.transform.position = BallPosition;


        }

    }
}
