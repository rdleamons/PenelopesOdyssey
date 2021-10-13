using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climable : MonoBehaviour
{
    /*
    [SerializeField, Range(90, 180)]
    float maxClimbAngle = 140f;
    float minGroundDotProduct, minStairsDotProduct, minClimbDotProduct;
    Vector3 contactNormal, steepNormal, climbNormal;
    int groundContactCount, steepContactCount, climbContactCount;
    bool Climbing => climbContactCount > 0;
    [SerializeField]
    LayerMask probeMask = -1, stairsMask = -1, climbMask = -1;
    int layer = collision.gameObject.layer;
    float minDot = GetMinDot(layer);
    [SerializeField]
    Material normalMaterial = default, climbingMaterial = default;
    MeshRenderer meshRenderer;
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f, maxClimbSpeed = 2f;
    [SerializeField, Range(0f, 100f)]
    float
    maxAcceleration = 10f,
    maxAirAcceleration = 1f,
    maxClimbAcceleration = 20f;
    Vector2 playerInput;
    //Vector3 velocity, desiredVelocity, connectionVelocity;
    Vector3 velocity, connectionVelocity;



    void OnValidate()
    {
        minGroundDotProduct = Mathf.Cos(maxGroundAngle * Mathf.Deg2Rad);
        minStairsDotProduct = Mathf.Cos(maxStairsAngle * Mathf.Deg2Rad);
        minClimbDotProduct = Mathf.Cos(maxClimbAngle * Mathf.Deg2Rad);
    }

    void ClearState()
    {
        groundContactCount = steepContactCount = climbContactCount = 0;
        contactNormal = steepNormal = climbNormal = Vector3.zero;
        connectionVelocity = Vector3.zero;
        previousConnectedBody = connectedBody;
        connectedBody = null;
    }


    if (upDot >= minDot)
    {
        groundContactCount += 1;
        contactNormal += normal;
        connectedBody = collision.rigidbody;
    }
 //else if (upDot > -0.01f) {
    else
    {
        if (upDot > -0.01f)
        {
            steepContactCount += 1;
            steepNormal += normal;
        if (groundContactCount == 0)
        {
            connectedBody = collision.rigidbody;
        }
    }
         if (upDot >= minClimbDotProduct)
         {
            climbContactCount += 1;
            climbNormal += normal;
            connectedBody = collision.rigidbody;
         }
    }

    if (upDot >= minClimbDotProduct && (climbMask & (1 << layer)) != 0)
    {
        climbContactCount += 1;
        climbNormal += normal;
        connectedBody = collision.rigidbody;
    }

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
        meshRenderer = GetComponent<MeshRenderer>();
        OnValidate();
    }

    void Update()
    {
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        desiredJump |= Input.GetButtonDown("Jump");
        meshRenderer.material = Climbing ? climbingMaterial : normalMaterial;

        meshRenderer.material = Climbing ? climbingMaterial : normalMaterial;
    }

    bool CheckClimbing()
    {
        if (Climbing)
        {
            groundContactCount = climbContactCount;
            contactNormal = climbNormal;
            return true;
        }
        return false;
    }

    if (CheckClimbing() || OnGround || SnapToGround() || CheckSteepContacts())
    {
 
    }

    if (!Climbing)
    {
        velocity += gravity * Time.deltaTime;
    }

    void AdjustVelocity()
    {
        float acceleration, speed;
   
        Vector3 xAxis, zAxis;
        if (Climbing)
        {
            acceleration = maxClimbAcceleration;
            speed = maxClimbSpeed;
            xAxis = Vector3.Cross(contactNormal, upAxis);
            zAxis = upAxis;
        }
        else
        {
            acceleration = OnGround ? maxAcceleration : maxAirAcceleration;
            speed = maxSpeed;
            xAxis = rightAxis;
            zAxis = forwardAxis;
        }
            xAxis = ProjectDirectionOnPlane(xAxis, playerInput.x * speed, contactNormal);
            zAxis = ProjectDirectionOnPlane(zAxis, playerInput.y * speed, contactNormal);
    
    
    }
    */
}


