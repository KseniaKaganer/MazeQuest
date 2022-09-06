using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zinnia.Action;

public class OVRInputBtnAction : BooleanAction
{
    public OVRInput.Controller controller = OVRInput.Controller.Active;
    public OVRInput.Button button;
    //bool triggerValue;


    protected virtual void Update()
    {
        Receive(OVRInput.Get(button, controller));
    }

// Start is called before the first frame update
//void Start()
//    {

//        var inputDevices = new List<UnityEngine.XR.InputDevice>();

//        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

//        foreach (var device in inputDevices)
//        {
//            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
//        }

//        var leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
//        var desiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
//        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandedControllers);
//        foreach (var device in leftHandedControllers)
//        {
//            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
//        }

//        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
//        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

//        if (leftHandDevices.Count == 1)
//        {
//            UnityEngine.XR.InputDevice device = leftHandDevices[0];
//            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
//        }
//        else if (leftHandDevices.Count > 1)
//        {
//            Debug.Log("Found more than one left hand!");
//        }

//    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void AppQuit()
    {
        Application.Quit();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    //if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
    //    //{
    //    //    Debug.Log("Trigger button is pressed.");
    //    //}
    //}
}
