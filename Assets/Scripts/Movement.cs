using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    private Vector2 mousePos;
    private Vector2 Diraction;
    public Camera cam;
    public float moveSpeed = 5f;


    [Header("Dash system")]
    [SerializeField] bool canDash = true;
    [SerializeField] float dashSpeed = 50f;
    [SerializeField] float dashCooldown = 0.1f;
    [SerializeField] float dashTime = 0f;

    void Update()
    {
        GetMovmentInput();
        GetMousePos();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DashAbility();
        }
    }
    void FixedUpdate()
    {
        MovePlayer(Diraction);
        Aim();
        
    }

    void Aim()
    {
        Vector2 LookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void GetMousePos()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void GetMovmentInput()
    {
        Diraction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    void MovePlayer(Vector2 input)
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);
    }

    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }

    }

    IEnumerator Dash()
    {
        canDash = false;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        moveSpeed = 6f;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}

