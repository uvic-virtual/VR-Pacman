using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Valve.VR;

public class ArmSwing : MonoBehaviour
{
    private GameObject player;
    private GameObject leftHand;
    private GameObject rightHand;
    private Vector3[] lastLocation;
    private bool moving;

    [SerializeField] private SteamVR_Action_Boolean trigger;
    [SerializeField] private SteamVR_Input_Sources handType;
    [SerializeField] private float moveSpeed = 7.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        leftHand = GameObject.Find("LeftHand");
        rightHand = GameObject.Find("RightHand");
        lastLocation = new Vector3[2] { Vector3.zero, Vector3.zero };
        moving = false;
    }

    private void MovePlayer(Vector3 direction, float speed)
    {
        player.transform.Translate(direction * moveSpeed * speed * Time.deltaTime);
    }

    private void UpdateButton()
    {
        if (trigger.GetStateDown(handType))
            moving = true;
        if (trigger.GetStateUp(handType))
        {
            moving = false;
            lastLocation[0] = Vector3.zero;
            lastLocation[1] = Vector3.zero;
        }
    }

    private Vector3 UpdateDirection()
    {
        Transform direction = leftHand.transform;
        Debug.DrawRay(direction.position,direction.forward, Color.green);
        //If the controller is pointing up
        if (Vector3.Angle(direction.forward, Vector3.up) < 10f)
            return new Vector3(-direction.up.x, 0, -direction.up.z).normalized;
        //If the controller is pointing down
        else if (Vector3.Angle(direction.forward, -Vector3.up) < 10f)
            return new Vector3(direction.up.x, 0, direction.up.z).normalized;
        //If the controller is pointing somewhere in the middle
        return new Vector3(direction.forward.x, 0, direction.forward.z).normalized;
    }

    private bool CheckGrounded()
    {
        Collider playerCol = player.GetComponent<BoxCollider>();
        
        if(player.transform.position.y < 3)
        {
            return true;
        }return false;
    }


    private float GetSpeed()
    {
        if (lastLocation[0] == Vector3.zero && lastLocation[1] == Vector3.zero)
        {
            lastLocation[0] = leftHand.transform.localPosition;
            lastLocation[1] = rightHand.transform.localPosition;
            return 0f;
        }
        //function calculate magnitudeof displacement on the z,y axis
        Func<Vector3, Vector3, double> mag = (pos1, pos2) =>
            Math.Sqrt(Math.Pow(Math.Abs(pos1.z) - Math.Abs(pos2.z), 2) + Math.Pow(Math.Abs(pos1.y) - Math.Abs(pos2.y), 2));
        float magL = (float)mag(leftHand.transform.localPosition, lastLocation[0]);
        float magR = (float)mag(rightHand.transform.localPosition, lastLocation[1]);

        double Speed = (magL + magR) / 2f / Time.deltaTime;
        lastLocation[0] = leftHand.transform.localPosition;
        lastLocation[1] = rightHand.transform.localPosition;
        return (float)Speed / 5f;
    }

    void Update()
    {
        Vector3 direction = UpdateDirection();
        UpdateButton();
        if (moving)
            MovePlayer(direction, GetSpeed());
    }
}

