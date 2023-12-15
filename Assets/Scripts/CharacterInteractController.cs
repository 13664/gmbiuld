using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    Character character;
    CharacterController2D characterController;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractable = 1.2f;
    [SerializeField] HighlightController highliterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }
    private void Update()
    {
        Check();
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player collided with the obstacle!");
            // You can add any other actions or code you want to perform here
        }
    }


    private void Check()
    {


        Vector2 position = rigidbody2d.position + characterController.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractable);
       
        if(colliders.Length == 0)
        {
            highliterController.Hide();
        }
        
        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                highliterController.Highlight(hit.gameObject);
                return;

            }
            highliterController.Hide();

        }
    }
    private void Interact()
    {
        Vector2 position = rigidbody2d.position + characterController.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractable);
        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);
                break;
            }
        }

    }
}
