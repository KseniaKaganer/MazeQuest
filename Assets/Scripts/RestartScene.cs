using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public InputActionReference Input;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Restart Scene Start!");
    }

    //private void Awake()
    //{
    //    Input.action.started += RestartSceneHandle;
    //}

    //private void OnDestroy()
    //{
    //    Input.action.started -= RestartSceneHandle;
    //}

    //private void RestartSceneHandle(InputAction.CallbackContext contex)
    //{
    //    Debug.Log("Restart Scene!");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
