using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;
    public Slider XSlider;
    public Slider YSlider;
    public Transform orientation;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    private void Start()
    {
        XSlider.value = PlayerPrefs.GetFloat("XSens", sensX);
        YSlider.value = PlayerPrefs.GetFloat("YSens", sensY);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void OnXChanged()
    {
        sensX = XSlider.value;
        PlayerPrefs.SetFloat("XSens", sensX);
    }

    public void OnYChanged()
    {
        sensY = YSlider.value;
        PlayerPrefs.SetFloat("YSens", sensY);
    }
}
