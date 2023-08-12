using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPlayControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed, vDir, hDir;
    private Rigidbody2D rb;
    static float hDirectionYaxisGyro;
    //[SerializeField] public static GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        hDirectionYaxisGyro = ArduinoInputs.GetYAxis();
        vDir = Input.GetAxisRaw("Vertical");

        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void FixedUpdate() {
        rb.velocity = new Vector2(hDirectionYaxisGyro * moveSpeed * 2, vDir*moveSpeed);
    }
}
