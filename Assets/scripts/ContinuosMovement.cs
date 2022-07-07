using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuosMovement : MonoBehaviour
{
    public XRNode inputSource;
    public float speed = 1;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;

    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

<<<<<<< Updated upstream
=======
    public bool useVRController = false;
    public float movementSpeed = 2f;

    public Transform cameraOffset;
    public Vector3 cameraPositionOffset;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
        cameraOffset.position += cameraPositionOffset;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        bool isGrounded = CheckIfGrounded();

        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        //Gravity
        if (isGrounded)
        {
            fallingSpeed = 0;
        }

        else if (!isGrounded)
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
<<<<<<< Updated upstream
=======

        //rig.Camera.transform.position = new Vector3(rig.Camera.transform.position.x, height, rig.Camera.transform.position.z);
>>>>>>> Stashed changes
    }

    void CapsuleFollowHeadSet()
    {
<<<<<<< Updated upstream
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
=======
        //character.height = rig.cameraInRigSpaceHeight - additionalHeight;
>>>>>>> Stashed changes
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
