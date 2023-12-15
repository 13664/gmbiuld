using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolKit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with the obstacle!");
            // You can add any other actions or code you want to perform here
        }
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
    }
    
}
