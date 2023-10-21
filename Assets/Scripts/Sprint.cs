using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    PlayerMovement basicScript;
    public float SprintSpeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        basicScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            basicScript.moveSpeed += SprintSpeed;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            basicScript.moveSpeed -= SprintSpeed;
    }
}