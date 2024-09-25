using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFactory : MonoBehaviour
{
    // 生成するオブジェクトのプレハブをインスペクターから指定
    public GameObject[] wallPrefabs;  // 複数のプレハブを配列で保持 

    // プレイヤーのオブジェクトをインスペクターから指定
    private GameObject playerObject;

    // 一つ手前の壁の位置
    private Vector3 before_wallposition = new Vector3(0, 3, 20);
    // 一つ手前の壁のオブジェクト
    private GameObject before_wall;

    public void create(int randomIndex)
    {
        // Instantiateメソッドでオブジェクトのクローンを生成
        before_wall = Instantiate(wallPrefabs[randomIndex], new Vector3(0, 3, before_wallposition.z + 30), Quaternion.identity);
        before_wallposition.z += 30;
    }
}
