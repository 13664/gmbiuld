using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeCuttable : ToolKit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    private static int cutTreeNumber = 0;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with the obstacle!");
            // You can add any other actions or code you want to perform here
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        cutTreeNumber = 0; // Reset cutTreeNumber when a new scene is loaded
    }

    public override void Hit()
    {
        while(dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;

        }

        Destroy(gameObject);
        // Log the current value of cutTreeNumber before incrementing
        Debug.Log("Before Increment: " + cutTreeNumber);

        cutTreeNumber++;

        // Log the updated value of cutTreeNumber
        Debug.Log("After Increment: " + cutTreeNumber);

        ToolsCharacterController characterController = FindObjectOfType<ToolsCharacterController>();
        if (characterController != null)
        {
            // Call the HandleWin method and pass the cutTreeNumber
            characterController.HandleWin(cutTreeNumber);
        }
    }
}
