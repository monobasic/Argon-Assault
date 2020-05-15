using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] float xSpeed = 50f;
  [SerializeField] float ySpeed = 50f;
  [SerializeField] float xRange = 17.5f;
  [SerializeField] float yRange = 10.5f;

  // Vertical Y factors
  [SerializeField] float positionPitchFactor = -1.5f;
  [SerializeField] float controlPitchFactor = -30f;

  // Horizontal X factors
  [SerializeField] float positionYawFactor = 1.8f;
  [SerializeField] float controlRollFactor = -20f;

  float xThrow, yThrow;



  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    ProcessTranslation();
    ProcessRotation();
  }

  private void ProcessTranslation()
  {
    xThrow = Input.GetAxis("Horizontal");
    float xOffset = xThrow * xSpeed * Time.deltaTime;
    float rawNewXPos = transform.localPosition.x + xOffset;
    float newXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

    yThrow = Input.GetAxis("Vertical");
    float yOffset = yThrow * ySpeed * Time.deltaTime;
    float rawNewYPos = transform.localPosition.y + yOffset;
    float newYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

    transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
  }

  private void ProcessRotation()
  {
    float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
    float yaw = transform.localPosition.x * positionYawFactor;
    float roll = xThrow * controlRollFactor;

    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }
}
