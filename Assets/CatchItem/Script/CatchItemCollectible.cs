using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatchItemCollectible : MonoBehaviour
{
    public int value = 1; // Nilai dari collectible ini, bisa diatur di Inspector
    private UnityEvent<GameObject> _onCollectEvent = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> _afterCollectEvent = new UnityEvent<GameObject>();

    // Menambahkan listener ke event
    public void AddOnCollectEvent(System.Action<GameObject> action)
    {
        _onCollectEvent.AddListener(action.Invoke);
    }

    // Menghapus listener dari event
    public void RemoveOnCollectEvent(System.Action<GameObject> action)
    {
        _onCollectEvent.RemoveListener(action.Invoke);
    }

    // Memicu event pengambilan koleksi
    public void TriggerCollection(GameObject collector)
    {
        // Invoke semua event yang berhubungan dengan koleksi
        _onCollectEvent.Invoke(collector);
        _afterCollectEvent.Invoke(collector);

        // Menyampaikan nilai collectible ke metode `CollectedBy`
        // CollectedBy(collector);
    }

    // Metode virtual yang bisa di-override oleh kelas turunan jika perlu
    // protected virtual void CollectedBy(GameObject collector)
    // {
    //     Debug.Log(collector.name + " collected an item with value: " + value);
    // }
}
