using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreSystem : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    [SerializeField] private AudioManager audioManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
        }
    }
}
