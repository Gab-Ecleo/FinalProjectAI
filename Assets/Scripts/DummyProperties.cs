using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DummyProperties : MonoBehaviour
{
    #region Variables

    [Header("Dummy Stats")]
    public float _health;

    [SerializeField] private float _remainingHealth;
    private MeshRenderer _objectMesh;
    private CapsuleCollider _objectCollider;
    private bool _currentlyRunning;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        //Pull Dummy Components
        _remainingHealth = _health;
        _objectMesh = GetComponent<MeshRenderer>();
        _objectCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (_remainingHealth <= 0)
        {
            _objectMesh.enabled = false;
            _objectCollider.enabled = false;
            
            if (!_currentlyRunning)
                StartCoroutine("Respawn");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ArrowDamage _archerDamage = new ArrowDamage();

        if (collision.gameObject.CompareTag("Team1_Projectile"))
            _remainingHealth -= _archerDamage.damage;
    }

    #endregion

    #region Methods

    IEnumerator Respawn()
    {
        //Ensure that the coroutine only runs once
        _currentlyRunning = true;
        
        yield return new WaitForSeconds(5);

        //Reset Dummy Stats
        _remainingHealth = _health;
        _objectMesh.enabled = true;
        _objectCollider.enabled = true;
        _currentlyRunning = false;

    }

    #endregion
    
}
