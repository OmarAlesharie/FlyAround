using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheFlyAround : MonoBehaviour
{
    [SerializeField]
    Transform FlyAround;

    Vector3 Position;


    [SerializeField]
    float UpSpeed = 10f;
    [SerializeField]
    float DownSpeed = 10f;
    [SerializeField]
    float MinHeight = -20f;
    [SerializeField]
    float MaxHeight = 20f;

    [SerializeField]
    float Up_DownRotation = 30f;

    // Start is called before the first frame update
    void Start()
    {
        MinHeight = FlyAround.position.y + MinHeight;
        MaxHeight = FlyAround.position.y + MaxHeight;

        transform.position = FlyAround.position;
        transform.rotation = FlyAround.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Position = FlyAround.position;
        Position.y = transform.position.y;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Position.y += UpSpeed * Time.deltaTime;
            FlyAround.localRotation = Quaternion.Lerp(Quaternion.Euler(0f, 90f, 0f), Quaternion.Euler(-Up_DownRotation, 90f, 0f), .5f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Position.y -= DownSpeed * Time.deltaTime;
            FlyAround.localRotation = Quaternion.Lerp(Quaternion.Euler(0f, 90f, 0f), Quaternion.Euler(Up_DownRotation, 90f, 0f), .5f);
        }
        else
        {
            FlyAround.localRotation = Quaternion.Lerp(FlyAround.localRotation, Quaternion.Euler(0f, 90f, 0f), .5f);
        }

        Position.y = Mathf.Clamp(Position.y, MinHeight, MaxHeight);

        transform.position = Position;
        transform.rotation = FlyAround.rotation;
    }
}
