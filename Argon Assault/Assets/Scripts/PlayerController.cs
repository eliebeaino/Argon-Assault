using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("Speed in m/s")] [SerializeField] float ControlSpeed = 30f;
    [Tooltip("Distance in m")] [SerializeField] float clampRangeX= 16f;
    [Tooltip("Distance in m")] [SerializeField] float clampRangeY = 9f;

    [Header("Screen-poisition Based")]
    [SerializeField] float positionPitchFactor = -1.6f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Control Throw Based")]
    [SerializeField] float ControlPitchFactor = -10f;
    [SerializeField] float ControlRollFactor = -20f;
    float xThrow, yThrow;

    bool alive = true;

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        float pitch = (transform.localPosition.y * positionPitchFactor) 
                    + (yThrow * ControlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * ControlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * ControlSpeed * Time.deltaTime;
        float yOffset = yThrow * ControlSpeed * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -clampRangeX, clampRangeX);
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -clampRangeY, clampRangeY);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    public bool ChangeAliveState()
    {      
        return alive = false;
    }
}
