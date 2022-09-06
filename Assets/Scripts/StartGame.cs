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
        Debug.Log("hiiii start!!!");
        Panel.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hiiiiiiiiiii 111111 " + col.collider.name);
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("hiiiiiiiiiii 222222222 " + col.collider.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
