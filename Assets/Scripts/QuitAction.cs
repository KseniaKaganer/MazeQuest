using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitAction : MonoBehaviour
{
    public InputActionReference Input;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("QuitAction !");
    }
    //private void Awake()
    //{
    //    Input.action.started += QuitHandle;
    //}

    //private void OnDestroy()
    //{
    //    Input.action.started -= QuitHandle;
    //}

    //private void QuitHandle(InputAction.CallbackContext contex)
    //{
    //    Debug.Log("Application Quit!");
    //    Application.Quit();
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
