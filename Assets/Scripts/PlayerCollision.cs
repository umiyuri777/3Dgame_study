using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ログを表示する
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000000f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
