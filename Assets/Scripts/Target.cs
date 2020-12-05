﻿using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public string snowballTag = "snowball";
    public float recoveryTime = 3.0f;

    public GameObject targetModel;
    public Vector3 hitRotation;
    public float rotationSpeed = 90f;

    private bool hit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hit && other.gameObject.CompareTag(snowballTag))
        {
            hit = true;
            Destroy(other.gameObject);
            StartCoroutine(recoverTarget());
        }
    }

    private IEnumerator recoverTarget()
    {
        yield return new WaitForSeconds(recoveryTime);
        hit = false;
    }

    private void Update()
    {
        Quaternion modelTarget = hit ? Quaternion.Euler(this.hitRotation) : Quaternion.identity;
        targetModel.transform.rotation = Quaternion.RotateTowards(targetModel.transform.rotation, modelTarget, rotationSpeed * Time.deltaTime);
    }
}
