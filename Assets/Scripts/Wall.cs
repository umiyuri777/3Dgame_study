using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("壁と何かが衝突");
        if (other.gameObject.tag == "player")
        {
            Debug.Log("壁とプレイヤーが衝突");
            if (other.gameObject.GetComponent<MeshRenderer>().material.color == this.gameObject.GetComponent<MeshRenderer>().material.color)
            {
                Destroy(this.gameObject);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
