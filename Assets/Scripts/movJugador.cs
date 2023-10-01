using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class movJugador : MonoBehaviour
{
    private Vector2 targetPosition;
    private float movX;
    private float movY;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]private float moveTime=0.25f;
    private bool isMoving;
    public Tilemap tilemap;
    private bool miraDerecha;
    private int cont = 0;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        miraDerecha = true;
    }
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("movX",Mathf.Abs(movX));
        movY = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.D)&& !miraDerecha)
        {
            spriteRenderer.flipX = false;

            miraDerecha = true;
        }
        else if(Input.GetKeyDown(KeyCode.A) && miraDerecha)
        {
            spriteRenderer.flipX = true;

            miraDerecha = false;
        }
        if ((movX!=0||movY!=0)&&(!isMoving))
        {
            CalculateTargetPosition();
            if (CanIMove())
            {
                StartCoroutine(Move());
            }
            
        }
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        TileBase tile = tilemap.GetTile(cellPosition);

        // Verifica si la casilla tiene un tile antes de borrarlo
        if (tile != null)
        {
            if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.K))
            {
                tilemap.SetTile(cellPosition, null);
                cont++;
                Debug.Log("SpawnearObjeto");
            }
            
        }
    }
    IEnumerator Move()
    {
        isMoving = true;
        float timeElapsed=0f;
        Vector2 startPosition = transform.position;
        while (timeElapsed < moveTime)
        {
            transform.position = Vector2.Lerp(startPosition,targetPosition,timeElapsed/moveTime);
            timeElapsed +=Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }
    void CalculateTargetPosition()
    {
        if (movX==1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if (movX == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.left;
        }
        else if (movY == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if (movY == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.down;
        }
    }
    private bool CanIMove()
    {
        return !Physics2D.OverlapCircle(targetPosition,0.15f);
    }
}
