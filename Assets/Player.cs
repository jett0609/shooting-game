using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 30;
    CharacterController controller;
    public GameObject Music;
    GameObject BGM = null;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        // 旋轉
        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 移動 (x,z)
        Vector3 move = dir * speed * Time.deltaTime;

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            move.y = -9.8f * 30 * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (transform.position.y <= -10)
            transform.position = new Vector3(0, 0.6f, 0);

        BGM = GameObject.FindGameObjectWithTag("Music");
        if (BGM == null)
        {
            BGM = Instantiate(Music);
        }
    }
}
