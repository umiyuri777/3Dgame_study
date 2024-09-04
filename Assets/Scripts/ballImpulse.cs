using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balliMpulse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hit"); // ログを表示する
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 10f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
