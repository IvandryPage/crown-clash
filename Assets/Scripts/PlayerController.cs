using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    public enum PlayerType
    {
        Player1,
        Player2
    }

    [Header("Settings")]
    [SerializeField] private PlayerType playerType;
    [SerializeField] private float moveSpeed = 5f;

    private UserControls controls;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastDirection = Vector2.down;

    [Header("Scoring")]
    public float CrownTime { get; private set; }

    private Crown crown;

    private void Awake()
    {
        controls = new UserControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player2.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player2.Disable();
    }

    void Update()
    {
        moveInput = GetMovementInput().normalized;

        if (crown != null && crown.Holder == this)
        {
            CrownTime += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void LateUpdate()
    {
        if (moveInput.x != 0)
        {
            Vector3 scale = spriteRenderer.transform.localScale;

            scale.x = Mathf.Abs(scale.x) * (moveInput.x > 0 ? -1 : 1);

            spriteRenderer.transform.localScale = scale;
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (moveInput != Vector2.zero)
        {
            lastDirection = moveInput;
        }

        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetFloat("Speed", moveInput.magnitude);

        animator.SetFloat("LastMoveX", lastDirection.x);
        animator.SetFloat("LastMoveY", lastDirection.y);
    }

    private Vector2 GetMovementInput()
    {
        return playerType switch
        {
            PlayerType.Player1 => controls.Player.Move.ReadValue<Vector2>(),
            PlayerType.Player2 => controls.Player2.Move.ReadValue<Vector2>(),
            _ => Vector2.zero
        };
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Crown>(out Crown foundCrown))
            return;

        // Ambil crown yang ada di map
        if (foundCrown.Holder == null)
        {
            foundCrown.SetHolder(this);
            crown = foundCrown;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController otherPlayer =
            collision.gameObject.GetComponent<PlayerController>();

        if (otherPlayer == null)
            return;

        if (otherPlayer.crown == null)
            return;

        if (!otherPlayer.crown.CanBeStolen())
            return;

        Crown stolenCrown = otherPlayer.crown;

        otherPlayer.crown = null;
        crown = stolenCrown;

        stolenCrown.SetHolder(this);
    }
}