using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public GameObject currentHealth;
    private SpriteRenderer greenBar;
    private Health health;

    private void Start()
    {
        greenBar = currentHealth. GetComponent<SpriteRenderer>();
        health = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float healthPercent = (float) health.currentHealth / health.maximumHealth;
        greenBar.transform.localScale = new Vector3(healthPercent, greenBar.transform.localScale.y, greenBar.transform.localScale.z);
    }
}
