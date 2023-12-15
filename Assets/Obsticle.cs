using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obsticle : MonoBehaviour
{
    [SerializeField] GameObject obsticle ;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main Character")
        {
            Debug.Log("Obstacle collided with the player!");
            SceneManager.LoadScene("Game Over");
        }
    }
}
