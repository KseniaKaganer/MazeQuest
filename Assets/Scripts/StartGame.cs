using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartHandle);
    }

    public void StartHandle()
    {
        Panel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
