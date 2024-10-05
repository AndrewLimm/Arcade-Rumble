using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemCollectibleHitEventDisable : MonoBehaviour
{
    [SerializeField] CatchItemCollectible _collectible;

    void OnEnable()
    {
        _collectible._afterCollectEvent.AddListener(DisableTargetObject);
    }

    void OnDisable()
    {
        _collectible._afterCollectEvent.RemoveListener(DisableTargetObject);
    }

    void DisableTargetObject(GameObject collector)
    {
        gameObject.SetActive(false);
    }
}
