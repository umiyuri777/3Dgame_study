using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarRouter : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 0, 100); // 回転速度を設定
    public CanvasGroup gameClearCanvas; // UI Canvasをリンクする

    void Start()
    {
        // Canvasを非表示
        gameClearCanvas.alpha = 0f;
        gameClearCanvas.interactable = false;
        gameClearCanvas.blocksRaycasts = false;
    }

    void Update()
    {
        // 毎フレーム、指定した速度で回転させる
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player")) // プレイヤーと衝突した場合
        {
            ShowGameClearScreen();
        }
    }
    void ShowGameClearScreen()
    {
        // Canvasを表示
        gameClearCanvas.alpha = 1f;
        gameClearCanvas.interactable = true;
        gameClearCanvas.blocksRaycasts = true;
        Time.timeScale = 0f; // ゲームを停止する
    }
}
