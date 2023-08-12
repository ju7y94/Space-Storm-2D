using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 0.000001f;
    float lerpPosition = 0f;
    [SerializeField] Transform backgroundTargetPosition;
    Vector2 initialPosition;
    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(lerpPosition < 0.00014f)
        {
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, backgroundTargetPosition.position, lerpPosition);
            lerpPosition += Time.deltaTime * moveSpeed;
        }
        else if(lerpPosition >= 0.00014f)
        {
            gameObject.transform.position = initialPosition;
            lerpPosition = 0f;
        }
    }
}
