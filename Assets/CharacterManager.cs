using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    private bool isWalking;

    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {


        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;


        float rotatioSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime* rotatioSpeed);

    }

    public bool IsWalking()
    {
        return isWalking;
    }

}

