using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFormChenge : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    private GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = Instantiate(cubePrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 position = currentPlayer.transform.position;
            Quaternion rotation = currentPlayer.transform.rotation;
            Destroy(currentPlayer);

            // ここで切り替える形を決定する
            currentPlayer = Instantiate(cubePrefab, position, rotation);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 position = currentPlayer.transform.position;
            Quaternion rotation = currentPlayer.transform.rotation;
            Destroy(currentPlayer);

            // ここで切り替える形を決定する
            currentPlayer = Instantiate(spherePrefab, position, rotation);
        }
    }

    // void ChangeShape()
    // {
    //     Vector3 position = currentPlayer.transform.position;
    //     Quaternion rotation = currentPlayer.transform.rotation;
    //     Destroy(currentPlayer);

    //     // ここで切り替える形を決定する
    //     currentPlayer = Instantiate(spherePrefab, position, rotation);
    // }
}
