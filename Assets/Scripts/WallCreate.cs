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

    // クローンを生成したフラグ
    private bool isCreated = false;

    // 一つ手前の壁の位置
    private Vector3 before_wallposition = new Vector3(-1.5f, 3.4f, 15);
    // 一つ手前の壁のオブジェクト
    private GameObject before_wall;

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

        // プレイヤーと壁の間の距離が10よりも近くなったときに壁を生成
        if ((before_wallposition.z - playerPos.z <= 10f) && isCreated == false)
        {
            // ランダムでWallPrefabを選択
            int randomIndex = Random.Range(0, wallPrefabs.Length);

            // Instantiateメソッドでオブジェクトのクローンを生成
            before_wall = Instantiate(wallPrefabs[randomIndex], new Vector3(-1.5f, 3.4f, before_wallposition.z + 15), Quaternion.identity);
            before_wallposition.z += 15;
            Debug.Log("wall created");
            isCreated = true;
        }
        if (isCreated == true && playerPos.z >= before_wallposition.z + 5)
        {
            isCreated = false;
            Destroy(before_wall);
        }
    }
}
