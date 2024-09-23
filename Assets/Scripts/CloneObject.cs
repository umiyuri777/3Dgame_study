using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{

    // 生成するオブジェクトのプレハブをインスペクターから指定
    public GameObject objectPrefab;

    // クローンを生成する位置を指定
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーを押したときにオブジェクトのクローンを生成
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Instantiateメソッドでオブジェクトのクローンを生成
            Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
