using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeChange : MonoBehaviour
{
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
        // 触れたオブジェクトのMeshFilterとCollider
        MeshFilter otherMeshFilter = collision.gameObject.GetComponent<MeshFilter>();
        Collider otherCollider = collision.gameObject.GetComponent<Collider>();
        string other_tag = collision.gameObject.tag;

        // 現在のオブジェクトのMeshFilterとCollider
        MeshFilter playerMeshFilter = player.GetComponent<MeshFilter>();
        Collider playerCollider = player.GetComponent<Collider>();

        if (otherMeshFilter != null && playerMeshFilter != null && other_tag != "Plane" && other_tag != "Wall")
        {
            // プレイヤーのメッシュを触れたオブジェクトのメッシュに変更
            playerMeshFilter.mesh = otherMeshFilter.mesh;

            // Colliderの変更
            Destroy(playerCollider);

            // MeshColliderの場合の分岐
            if (otherCollider is MeshCollider otherMeshCollider)
            {
                // MeshColliderのコピー
                MeshCollider newMeshCollider = player.AddComponent<MeshCollider>();
                newMeshCollider.sharedMesh = otherMeshCollider.sharedMesh;

                // 凸型にするかどうか判定
                newMeshCollider.convex = otherMeshCollider.convex;
            }
            else
            {
                // 通常のColliderの場合
                player.AddComponent(otherCollider.GetType());
            }
        }
    }
}
