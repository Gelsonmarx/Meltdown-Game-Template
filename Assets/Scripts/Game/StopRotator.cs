using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopRotator : MonoBehaviour
{

    [SerializeField] UnityEvent triggerEvent;
    // Start is called before the first frame update
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            triggerEvent.Invoke();
        }
    }
}
