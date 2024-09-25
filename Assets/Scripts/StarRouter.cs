using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRouter : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 100); // 回転速度を設定

    void Update()
    {
        // 毎フレーム、指定した速度で回転させる
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

}
