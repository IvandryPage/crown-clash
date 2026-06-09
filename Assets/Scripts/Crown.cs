using UnityEngine;

public class Crown : MonoBehaviour
{
    [SerializeField] private Vector3 followOffset = new(0f, 1f, 0f);
    [SerializeField] private float stealCooldown = 0.5f;

    public PlayerController Holder { get; private set; }

    private float cooldownTimer;

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Holder != null)
        {
            transform.position = Holder.transform.position + followOffset;
        }
    }

    public bool CanBeStolen()
    {
        return cooldownTimer <= 0f;
    }

    public void SetHolder(PlayerController newHolder)
    {
        if (newHolder == null)
            return;

        Holder = newHolder;
        cooldownTimer = stealCooldown;
    }
}