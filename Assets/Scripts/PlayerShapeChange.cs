using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeChange : MonoBehaviour
{

    public GameObject spherePrefab;  // SphereのPrefabを設定

    public GameObject capsulePrefab; // CubeのPrefabを設定
    private GameObject player;
    private bool isCube = true;  // Cubeかどうかを判定するフラグ

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;  // 現在のプレイヤーオブジェクトを取得
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.tag);
        // 特定のキー（スペースキー）で形状を変更
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            if (isCube)
            {

                ChangeToSphere();
            }
            else
            {
                ChangeToCube();
            }
        }
        void ChangeToSphere()
        {
            Debug.Log("ChangeToSphere"); // ログを表示する

            // 現在のCubeを削除してSphereを生成
            Vector3 currentPosition = player.transform.position;
            Quaternion currentRotation = player.transform.rotation;
            Destroy(player);// Cubeを削除

            player = Instantiate(spherePrefab, currentPosition, currentRotation);  // Sphereを生成
            
            // プレイヤーに必要なScriptをアタッチ
            player.AddComponent<playercontroler>();
            player.AddComponent<PlayerShapeChange>();

            isCube = false;
        }
        void ChangeToCube()
        {
            Debug.Log("ChangeToCube");

            // Sphereを削除してCubeを再生成
            Vector3 currentPosition = player.transform.position;
            Quaternion currentRotation = player.transform.rotation;
            Destroy(player);

            player = Instantiate(capsulePrefab, currentPosition, currentRotation);  // Cubeを生成

            // プレイヤーに必要なScriptをアタッチ
            player.AddComponent<playercontroler>();
            player.AddComponent<PlayerShapeChange>();

            isCube = true;
        }
    }
}
