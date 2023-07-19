using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class  CharacterManager : MonoBehaviour
{
    private bool isWalking;

    public float raycastDistance = 10f;
    public LayerMask Enemy; // Layer containing the objects you want to interact with


    public GameObject GunFlasPArticles;

    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {


        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = -1;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;


        //for raycast hit
        float rotatioSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime* rotatioSpeed);

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Create a raycast direction based on the player's forward vector
            Vector3 raycastDirection = transform.forward;

            // Raycast from the player's position in the specified direction
            RaycastHit hit;
            Debug.Log("about to Hit the enemy");
            if (Physics.Raycast(transform.position, raycastDirection, out hit, raycastDistance, Enemy))
            {
                // Check if the raycast hit an object with the Health script attached
                HealthManager healthScript = hit.collider.GetComponent<HealthManager>();
                if (healthScript != null)
                {
                    // Perform damage to the hit object (you can adjust the damage value as needed)
                    healthScript.TakeDamage(10);
                }
            }

            StartCoroutine(WaitCourtineGunParticles());
        }

    }
    IEnumerator WaitCourtineGunParticles()
    {
        GunFlasPArticles.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        GunFlasPArticles.SetActive(false);
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}

