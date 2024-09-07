using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 0.01f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -0.01f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }

        //transformを取得
        Transform myTransform = this.transform;

        //ワールド座標を基準にスクリプトをアタッチしたオブジェクトの座標を取得
        Vector3 worldPos = myTransform.position;
        float x = worldPos.x;
        float y = worldPos.y;
        float z = worldPos.z;

        if (y <= -30)
        {
            worldPos.x = 0;
            worldPos.y = 1.5f;
            worldPos.z = 0;

            myTransform.position = worldPos;

        }
    }
}
