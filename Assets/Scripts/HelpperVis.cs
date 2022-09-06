using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpperVis : MonoBehaviour
{

    public GameObject helpperObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        helpperObj.SetActive(true);
    }

    private void OnDisable()
    {
        helpperObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
