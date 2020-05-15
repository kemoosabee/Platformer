using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private CharacterController _CharacterController;
    // Start is called before the first frame update
    void Start()
    {
         _CharacterController = GetComponent<CharacterController>();

         if(_CharacterController == null)
         {
             Debug.Log("Character Controller is null");
         }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
