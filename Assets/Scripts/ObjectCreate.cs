using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    // プレイヤーのオブジェクトをインスペクターから指定
    private GameObject playerObject;
    // 生成するオブジェクトのプレハブをインスペクターから指定
    public GameObject[] henshinPrefabs;

    // 一つ手前の壁の位置
    private Vector3 before_henshinposition = new Vector3(-1.5f, 3.4f, 25);
    // 一つ手前の壁のオブジェクト
    private List<GameObject> before_henshinList = new List<GameObject>();
    private bool isCreated = false;

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
        if ((before_henshinposition.z - playerPos.z <= 10f) && isCreated == false)
        {
            // 3つのオブジェクトをランダムに生成
            for (int i = 0; i < 3; i++)
            {
                // ランダムでhenshinPrefabを選択
                int randomIndex = Random.Range(0, henshinPrefabs.Length);

                // Instantiateメソッドでオブジェクトのクローンを生成
                GameObject newObject = Instantiate(henshinPrefabs[randomIndex],
                                                   new Vector3(-1.5f + i * 2f, 3.4f, before_henshinposition.z + 15),
                                                   Quaternion.identity);
                before_henshinList.Add(newObject);
            }
            before_henshinposition.z += 15;
            isCreated = true;
        }

        // プレイヤーが生成されたオブジェクトから十分離れたらオブジェクトを削除
        if (isCreated == true && playerPos.z >= before_henshinposition.z + 5)
        {
            isCreated = false;

            // リストに保存されたオブジェクトを全て削除
            foreach (GameObject obj in before_henshinList)
            {
                Destroy(obj);
            }

            before_henshinList.Clear(); // リストをクリア
        }
    }
}
