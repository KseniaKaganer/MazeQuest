using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchLabel : MonoBehaviour
{
    public InputActionReference Input;
    public GameObject LabelImg;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("TouchLabel Start!");
    }


    private void Awake()
    {
        Input.action.started += TouchLabelHandle;
    }

    private void OnDestroy()
    {
        Input.action.started -= TouchLabelHandle;
    }

    private void TouchLabelHandle(InputAction.CallbackContext contex)
    {
        Debug.Log("TouchLabelHandle ");
        bool isActive = !LabelImg.activeSelf;
        LabelImg.SetActive(isActive);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
