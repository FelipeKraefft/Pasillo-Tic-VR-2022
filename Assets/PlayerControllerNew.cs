using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerControllerNew : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    public Transform visorTR;
    public float visorY;
    public float offsetAngle;
    public float rotationSpeed;
    public bool rotateByTracking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateByTracking)
        {
            Quaternion Angles = InputTracking.GetLocalRotation(XRNode.Head);
            transform.rotation = Quaternion.Euler(0, Angles.eulerAngles.y * offsetAngle, 0);
        }
        else
        {
            transform.Rotate(0f, Input.GetAxis("Horizontal"), 0f);
        }        

        rb.velocity = transform.forward * Input.GetAxis("Vertical") * speed;
        //transform.localEulerAngles = new Vector3(0f,visorTR.eulerAngles.y,0f);
        //visorY = visorTR.rotation.y;
    }
}
