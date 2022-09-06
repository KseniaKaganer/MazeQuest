using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Calibration : MonoBehaviour
{
    public InputActionReference InputStickPress;
    public InputActionReference InputStick;
    public InputActionReference InputTrigger;
    public InputActionReference InputGrip;

    public Transform Maze;

    const float editSteps = 0.01f;

    //float xOffset = 0.28f;//1.189224f / 2f;
    //float yOffset = 0.4f;//1.169728f / 2f;

    float xOffset = 0.321f;
    float yOffset = 0.423f;

    float trashold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("XYCalibration Start!");
    }

    private void Awake()
    {
        //InputStickPress.action.started += TransofrMazeHandle;
        //InputStick.action.started += XYChangeHandle;
        //InputTrigger.action.started += DepthNearChangeHandle;
        //InputGrip.action.started += DepthFarChangeHandle;

        //InputGrip.action.started += TransofrMazeHandle;
    }

    private void OnDestroy()
    {
        //InputStickPress.action.started -= TransofrMazeHandle;
        //InputStick.action.started -= XYChangeHandle;
        //InputTrigger.action.started -= DepthNearChangeHandle;
        //InputGrip.action.started -= DepthFarChangeHandle;

        //InputGrip.action.started -= TransofrMazeHandle;
    }

    private void XYChangeHandle(InputAction.CallbackContext contex)
    {
        Vector2 vec = contex.ReadValue<Vector2>();
        //Debug.Log("YChangeHandle " + vec);
        Vector3 pos = Maze.position;
        if (Math.Abs(vec.x) < trashold && vec.y > 0)
        {
            Maze.position = new Vector3(pos.x, pos.y + editSteps, pos.z);
        } else if(Math.Abs(vec.x) < trashold && vec.y < 0)
        {
            Maze.position = new Vector3(pos.x, pos.y - editSteps, pos.z);
        } else if (vec.x > 0 && Math.Abs(vec.y) < trashold)
        {
            Maze.position = new Vector3(pos.x + editSteps, pos.y, pos.z);
        }
        else if (vec.x < 0 && Math.Abs(vec.y) < trashold)
        {
            Maze.position = new Vector3(pos.x - editSteps, pos.y, pos.z);
        }
    }

    private void DepthFarChangeHandle(InputAction.CallbackContext contex)
    {
        Debug.Log("DepthFarChangeHandle! " + Maze.position.z);
        Vector3 pos = Maze.position;
        Maze.position = new Vector3(pos.x, pos.y, pos.z + editSteps);
    }

    private void DepthNearChangeHandle(InputAction.CallbackContext contex)
    {
        Debug.Log("DepthNearChangeHandle! " + Maze.position.z);
        Vector3 pos = Maze.position;
        Maze.position = new Vector3(pos.x, pos.y, pos.z - editSteps);
    }

    private void TransofrMazeHandle(InputAction.CallbackContext contex)
    {
        Vector3 pos = Maze.position;
        Vector3 controllerPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
        Maze.position = new Vector3(controllerPos.x - xOffset, controllerPos.y - yOffset, controllerPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
