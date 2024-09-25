using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // プレイヤーのオブジェクト
    private GameObject playerObject;

    public WallFactory wallFactory;
    public ObjectFactory objectFactory;

    // 壁を生成する時間間隔
    public float duration_sec = 3;

    // 経過時間
    private float time_value = 0;


    void Start()
    {
        playerObject = this.gameObject;
    }

    void Update()
    {
        // プレイヤーの位置を取得
        Vector3 playerPos = playerObject.transform.position;

        // 経過時間を加算
        time_value += Time.deltaTime;

        // 指定した時間間隔ごとにオブジェクトを生成
        if (time_value >= duration_sec)
        {
            // ランダムでWallPrefabを選択
            int randomIndex = Random.Range(0, wallFactory.wallPrefabs.Length);
            int number2;
            int number3;

            // 重複しないように2つ目の数字を選ぶ
            do
            {
                number2 = Random.Range(0, wallFactory.wallPrefabs.Length);
                do
                {
                    number3 = Random.Range(0, wallFactory.wallPrefabs.Length);
                } while ((randomIndex == number3) || (number2 == number3));
            } while (randomIndex == number2);

            List <int> objectNumbers = new List<int> { randomIndex, number2, number3 };

            time_value = 0;
            wallFactory.create(randomIndex);
            objectFactory.create(objectNumbers);
        }
    }
}
