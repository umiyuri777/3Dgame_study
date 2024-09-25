using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    // 生成するオブジェクトのプレハブをインスペクターから指定
    public GameObject[] henshinPrefabs;

    // 変身する為のオブジェクトを生成する位置
    public float[] henshinposition_X;

    // 一つ手前のhenshinの位置
    public Vector3 before_henshinposition;


    // オブジェクト同士の距離
    private float objectDistance = 30;

    public void create(List<int> objectNumbers)
    {
        // 3つのオブジェクトをランダムに生成
        for (int i = 0; i < 3; i++)
        {
            // Instantiateメソッドでオブジェクトのクローンを生成
            GameObject newObject = Instantiate(henshinPrefabs[objectNumbers[i]],
                                                new Vector3(henshinposition_X[i], before_henshinposition.y, before_henshinposition.z + objectDistance),
                                                Quaternion.identity);
        }
        before_henshinposition.z += 30;
    }
}
