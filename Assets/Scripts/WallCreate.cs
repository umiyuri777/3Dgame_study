using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreate : MonoBehaviour
{
    // 生成するオブジェクトのプレハブをインスペクターから指定
    public GameObject[] wallPrefabs;  // 複数のプレハブを配列で保持
    public GameObject[] henshinPrefabs;  

    // プレイヤーのオブジェクトをインスペクターから指定
    private GameObject playerObject;

    // クロンを生成したフラグ
    private bool isCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの位置を取得
        Vector3 playerPos = playerObject.transform.position;

        // プレイヤーがZ座標17の位置に来たとき
        if (playerPos.z >= 10f && isCreated == false)
        {
            // ランダムでWallPrefabを選択
            int randomIndex = Random.Range(0, wallPrefabs.Length);

            // Instantiateメソッドでオブジェクトのクローンを生成
            Instantiate(wallPrefabs[randomIndex], new Vector3(5, 4, 15), Quaternion.identity);
            Debug.Log("wall created");
            isCreated = true;
        }
    }
}
