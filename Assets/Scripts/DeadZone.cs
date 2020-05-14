using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
     private GameObject _respawnPoint;
      void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Hit");
            Player player = other.GetComponent<Player>();
            CharacterController _characterController =
                            other.GetComponent<CharacterController>();
            if(_characterController != null)
            {
                _characterController.enabled = false;
                StartCoroutine(restartCC(_characterController));
            }
            other.transform.position = _respawnPoint.transform.position;
        }
    }
       IEnumerator restartCC(CharacterController _cc)
    {
        yield return new WaitForSeconds(0.5f);
        _cc.enabled = true;
    }
}
