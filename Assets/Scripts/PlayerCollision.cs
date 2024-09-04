using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //ファイルに書き込むために必要
using System; //Convertを使うために必要

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hit"); // ログを表示する
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000000f, ForceMode.VelocityChange);
    }

    public float knockbackForce = 10f; // 吹っ飛ぶ力の強さ

    void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトが壁であることを確認
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("壁とぶつかった");
            // 衝突点の法線ベクトルを取得
            Vector3 knockbackDirection = collision.contacts[0].normal;

            // 反対方向に力を加える
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("力を加えた");
                rb.AddForce(-knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
    public int framecount = 0;
    // Update is called once per frame
    void Update()
    {
        framecount++;

        //transformを取得
        Transform myTransform = this.transform;

        //ワールド座標を基準にスクリプトをアタッチしたオブジェクトの座標を取得
        Vector3 worldPos = myTransform.position;
        float x = worldPos.x;
        float y = worldPos.y;
        float z = worldPos.z;

        if (framecount % 600 == 0)
        {
            //ファイルパスを定義
            string filePath = Application.dataPath + @"\Scripts\ObjectPos.txt";
            Debug.Log(Application.dataPath);

            //ファイルの末尾に値を追加（Convertでfloat型の座標値をString型に変換している）
            File.AppendAllText(filePath, Convert.ToString(x) + "," + Convert.ToString(y) + "," + Convert.ToString(z) + "\n");
        }
        if (y <= -30){
            worldPos.x = 0;
            worldPos.y = 0;
            worldPos.z = 0;

            myTransform.position = worldPos;

        }
    }
}
