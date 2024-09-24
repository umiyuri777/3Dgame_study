using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{

    // オブジェクトが生成されたときに一度だけ実行される関数
    void Start()
    {

    }



    // 1フレームごとに実行される関数
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * 10f; // 速さを直接入れる
    }
}