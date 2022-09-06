using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("whooooo   ?? " + collision.transform.name);
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(_rotation * Time.deltaTime);
    }
}
