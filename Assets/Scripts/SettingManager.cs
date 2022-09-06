
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingManager : MonoBehaviour
{
    public InputActionReference InputStickPress;
    public InputActionReference InputTrigger;
    //public InputActionReference InputGrip;
    public InputActionReference InputStick;

    public Transform Maze;
    public GameObject SettinPanel;

    const int SettingNum = 10;
    public GameObject[] FrameToggle = new GameObject[SettingNum];
    public int SettingIndex = 0;

    const float trashold = 0.3f;
    const float editSteps = 0.01f;
    const float rotateFactor = 100f;

    const float xOffset = 0.321f;
    const float yOffset = 0.423f;

    bool IsEditMode = false;
    Color selectedColor = new Color32(0, 255, 255, 255);
    Color settingColor = new Color32(255, 0, 173, 255);



    // Start is called before the first frame update
    void Start()
    {
        foreach( var i in FrameToggle)
        {
            i.SetActive(false);
        }
        FrameToggle[SettingIndex].SetActive(true);
    }


    private void Awake()
    {
        InputTrigger.action.started += OpenSettingPanel;
        InputStick.action.started += SettingChangeHandle;
        InputStickPress.action.started += ChangeEditModeHandle;
    }

    private void OnDestroy()
    {
        InputTrigger.action.started -= OpenSettingPanel;
        InputStick.action.started -= SettingChangeHandle;
        InputStickPress.action.started -= ChangeEditModeHandle;
    }

    void upateFrame(int i)
    {
        FrameToggle[SettingIndex].SetActive(false);
        if(SettingIndex == 0 && i < 0)
        {
            SettingIndex = SettingNum-1;
        } else
        {
            SettingIndex = (SettingIndex + i) % SettingNum;
        }
        FrameToggle[SettingIndex].SetActive(true);
        FrameToggle[SettingIndex].GetComponent<Image>().color = settingColor;

    }

    void ToggleSetMaze()
    {
        if (IsEditMode)
        {
            InputTrigger.action.started -= OpenSettingPanel;
            InputTrigger.action.started += TransofrMazeHandle;
        } else
        {
            InputTrigger.action.started += OpenSettingPanel;
            InputTrigger.action.started -= TransofrMazeHandle;
        }
    }

    private void ChangeEditModeHandle(InputAction.CallbackContext contex)
    {
        IsEditMode = !IsEditMode;
        if (IsEditMode)
        {
            FrameToggle[SettingIndex].GetComponent<Image>().color = selectedColor;

            Transform t = FrameToggle[SettingIndex].transform.parent;
            switch (SettingIndex)
            {
                case 5:
                    //Set Maze Pose Mode
                    InputTrigger.action.started -= OpenSettingPanel;
                    InputTrigger.action.started += TransofrMazeHandle;
                    break;
                case 6:
                    //restart
                    t.GetComponentInChildren<RestartGame>().RestartHandle();
                    break;
                case 7:
                    //quit
                    t.GetComponentInChildren<QuitGame>().QuitHandle();
                    break;
                case 8:
                    //start
                    IsEditMode = false;
                    FrameToggle[SettingIndex].GetComponent<Image>().color = settingColor;
                    t.GetComponentInChildren<StartGame>().StartHandle();
                    break;
                case 9:
                    //help
                    break;
            }

        } else
        {
            FrameToggle[SettingIndex].GetComponent<Image>().color = settingColor;
            InputTrigger.action.started += OpenSettingPanel;
            InputTrigger.action.started -= TransofrMazeHandle;
        }
    }

    float GetStepX(Vector2 vec)
    {
        float updateVal = 0;
        if (vec.x > 0 && Math.Abs(vec.y) < trashold)
        {
            updateVal = editSteps;
        }
        else if (vec.x < 0 && Math.Abs(vec.y) < trashold)
        {
            updateVal = -editSteps;
        }
        return updateVal;
    }

    float GetStepY(Vector2 vec)
    {
        float updateVal = 0;
        if (Math.Abs(vec.x) < trashold && vec.y > 0)
        {
            updateVal = editSteps;
        }
        else if (Math.Abs(vec.x) < trashold && vec.y < 0)
        {
            updateVal = -editSteps;
        }
        return updateVal;
    }


    private void SettingChangeHandle(InputAction.CallbackContext contex)
    {
        Vector2 vec = contex.ReadValue<Vector2>();
        if (IsEditMode)
        {
            float updateVal;
            
            Debug.Log(vec.x + "   ,   " + vec.y);
            Vector3 pos = Maze.position;

            switch (SettingIndex)
            {
                case 0:
                    //x
                    updateVal = GetStepX(vec);
                    Maze.position = new Vector3(pos.x + updateVal, pos.y, pos.z);
                    break;
                case 1:
                    //y
                    updateVal = GetStepY(vec);
                    Maze.position = new Vector3(pos.x, pos.y + updateVal, pos.z);
                    break;
                case 2:
                    //z
                    updateVal = GetStepY(vec);
                    Maze.position = new Vector3(pos.x, pos.y, pos.z + updateVal);
                    break;
                case 3:
                    //yaw
                    updateVal = rotateFactor * GetStepX(vec);
                    Maze.transform.Rotate(0.0f, updateVal, 0.0f, Space.Self);
                    break;
                case 4:
                    //pitch
                    updateVal = rotateFactor * GetStepY(vec);
                    Maze.transform.Rotate(updateVal, 0.0f, 0.0f, Space.Self);
                    break;
            }
        }
        else
        {
            if (vec.y > 0)
            {
                upateFrame(-1);
            }
            else if (vec.y < 0)
            {
                upateFrame(1);
            }
        }

    }

    private void TransofrMazeHandle(InputAction.CallbackContext contex)
    {
        Vector3 pos = Maze.position;
        Vector3 controllerPos = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
        Maze.position = new Vector3(controllerPos.x - xOffset, controllerPos.y - yOffset, controllerPos.z);
    }


    private void OpenSettingPanel(InputAction.CallbackContext contex)
    {
        bool nextState = !SettinPanel.activeSelf;
        SettinPanel.SetActive(nextState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
