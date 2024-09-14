using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeChange : MonoBehaviour
{
    public GameObject spherePrefab;  // SphereのPrefabを設定
    public GameObject capsulePrefab; // capsuleのPrefabを設定
    public GameObject cubePrefab; //CubeのPrefabを設定
    public GameObject cylinderPrefab; // cylinderのPrefabを設定
    
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;  // 現在のプレイヤーオブジェクトを取得
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // 触れたオブジェクトのMeshFiletrとCollider
        MeshFilter otherMeshFilter = collision.gameObject.GetComponent<MeshFilter>();
        Collider othercollider = collision.gameObject.GetComponent<Collider>();
        string other_name = collision.gameObject.name;

        // 現在のオブジェクトのMeshFilterとCollider
        MeshFilter playerMeshFilter = player.GetComponent<MeshFilter>();
        Collider playercollider = player.GetComponent<Collider>();

        if (otherMeshFilter != null && playerMeshFilter != null && other_name != "Plane" && other_name != "Wall") // 床に触れても変更しないようにしておく
        {
            // プレイヤーのメッシュを触れたオブジェクトのメッシュに変更
            // 当たり判定も一緒に
            playerMeshFilter.mesh = otherMeshFilter.mesh;

            // Colliderの変更
            Destroy(playercollider);
            player.AddComponent(othercollider.GetType());
        }
    }
}
