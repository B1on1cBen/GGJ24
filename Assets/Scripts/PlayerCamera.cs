using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public bool trackingPlayer;
    public Vector3 offset;
    public Transform evilDude;
    [HideInInspector] public Vector3 npcOffset;
    public float smoothingSpeed;
    Transform player;

    Vector3 wantedPosition;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        wantedPosition = evilDude.position - Vector3.up + offset;
        //wantedPosition = player.position + offset + npcOffset;
    }

    void FixedUpdate()
    {
        if (trackingPlayer)
            wantedPosition = player.position - Vector3.up + Vector3.right + offset + npcOffset;

        transform.position = Vector3.Lerp(transform.position, wantedPosition, smoothingSpeed * Time.fixedDeltaTime);   
    }

    public void PanToEvilDude()
    {
        wantedPosition = player.position - Vector3.up + offset;
    }
}
