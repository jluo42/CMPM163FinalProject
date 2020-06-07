using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    CharacterController cc;
    PlayerMovement cm;
    GameObject player;
    Transform defaultPlayerTransform;
    bool isDriving = false;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.FindObjectOfType<CharacterController>();
        cm = GameObject.FindObjectOfType<PlayerMovement>();
        player = cm.gameObject;
        defaultPlayerTransform = player.transform.parent;
        rb = GetComponent<Rigidbody>();
        

    }

    bool IsPlayerCloseToBoat()
    {
        return Vector3.Distance(gameObject.transform.position, player.transform.position) < 10;
    }

    void SetDriving(bool isDriving)
    {
        this.isDriving = isDriving;
        cm.enabled = !isDriving;
        cc.enabled = !isDriving;

        if (isDriving)
            player.transform.parent = gameObject.transform;
        else
            player.transform.parent = defaultPlayerTransform;
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && IsPlayerCloseToBoat())
        {
            SetDriving(!isDriving);
        }
       if(isDriving)
        {
            float forwardThrust = 0;
            if (Input.GetKey(KeyCode.W))
                forwardThrust = 3;
            if (Input.GetKey(KeyCode.S))
                forwardThrust = -1;

            rb.AddForce(gameObject.transform.forward * forwardThrust);

            float turnThrust = 0;
            if (Input.GetKey(KeyCode.A))
                turnThrust = 1;
            if (Input.GetKey(KeyCode.D))
                turnThrust = -1;

            rb.AddRelativeTorque(Vector3.up * turnThrust);
        }
    }
}
