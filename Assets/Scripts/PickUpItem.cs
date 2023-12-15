using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float timeToLeave = 10f;
    public Item item;
    public int count = 1;
    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }
    private void Update()
    {
        timeToLeave -= Time.deltaTime;
        if (timeToLeave < 0) 
        { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed*Time.deltaTime
            );

        if (distance < 0.1f)
        {
            //to do * should be moved into specifiede controller rather that being checjked here.
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory container attached the game manager");
            }
            Destroy(gameObject);
        }
    }
}
