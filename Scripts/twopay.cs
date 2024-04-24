using UnityEngine;

public class twopay : MonoBehaviour
{
    public GameObject objectToActivate; // The GameObject to activate based on the targetObject's active state

    void Update()
    {
        objectToActivate.SetActive(true);
    }
}
