using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeChange : MonoBehaviour
{
    private GameObject player;


    void Start()
    {
        player = this.gameObject;  // 現在のプレイヤーオブジェクトを取得
    }

    void OnCollisionEnter(Collision collision)
    {
        // 触れたオブジェクトのMeshFilterとCollider
        MeshFilter otherMeshFilter = collision.gameObject.GetComponent<MeshFilter>();
        Collider otherCollider = collision.gameObject.GetComponent<Collider>();
        MeshRenderer otherMeshRenderer = collision.gameObject.GetComponent<MeshRenderer>();
        string other_tag = collision.gameObject.tag;

        // 現在のオブジェクトのMeshFilterとCollider
        MeshFilter playerMeshFilter = player.GetComponent<MeshFilter>();
        Collider playerCollider = player.GetComponent<Collider>();
        MeshRenderer playerMeshRenderer = player.GetComponent<MeshRenderer>();

        if (otherMeshFilter != null && playerMeshFilter != null && other_tag != "Ground" && other_tag != "Wall" && other_tag != "goal")
        {
            // プレイヤーのメッシュを触れたオブジェクトのメッシュに変更
            playerMeshFilter.mesh = otherMeshFilter.mesh;

            // Colliderの変更
            Destroy(playerCollider);
            // Colliderの追加
            player.AddComponent(otherCollider.GetType());

            // プレイヤーのマテリアルを触れたオブジェクトのマテリアルに変更
            if (otherMeshRenderer != null && playerMeshRenderer != null)
            {
                playerMeshRenderer.material = otherMeshRenderer.material;
            }
        }
    }
}
