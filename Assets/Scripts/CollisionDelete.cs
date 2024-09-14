using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDelete : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject thisObject;

    void Start()
    {
        thisObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(thisObject);
    }
}
