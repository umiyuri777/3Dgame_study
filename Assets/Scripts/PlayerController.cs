using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.3f; // プレイヤーの移動速度
    public float jumpForce = 30f; // ジャンプの力
    private bool isGrounded; // プレイヤーが地面にいるかどうかのフラグ
    private Rigidbody rb; // Rigidbodyコンポーネントの参照

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        // 自動で直進し、左右に移動できるようにする
        transform.position += new Vector3(0, 0, 0.02f); // 自動で前進
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }

        // ジャンプ処理
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ジャンプ力を追加
            isGrounded = false; // ジャンプ中は地面にいないと判定
        }

        // Y座標が-20以下になったらプレイヤーをリセット
        if (transform.position.y <= -20)
        {
            transform.position = new Vector3(0, 4.3f, 0);
            rb.velocity = Vector3.zero; // リセット時に速度をリセット
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面に着いたかどうかを判定
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 地面に着地したらフラグを立てる
        }
    }
}
