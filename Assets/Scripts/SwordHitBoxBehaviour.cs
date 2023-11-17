using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBoxBehaviour : MonoBehaviour
{
   private SphereCollider _collider;
   private bool _isRunning;

   private void Awake()
   {
      _collider = GetComponent<SphereCollider>();
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (!_isRunning)
         StartCoroutine(AtkCd());
      Debug.Log("Disabling Collider");
   }

   IEnumerator AtkCd()
   {
      _isRunning = true;
      _collider.enabled = false;
      
      Debug.Log("Counting Down");

      yield return new WaitForSeconds(2);

      _isRunning = false;
      _collider.enabled = true;
   }
}
