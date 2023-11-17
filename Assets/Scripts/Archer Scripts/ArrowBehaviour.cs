using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
   private void Update()
   {
      Destroy(gameObject, 3);
   }

   private void OnCollisionEnter(Collision collision)
   {
      Destroy(gameObject);
   }
}
