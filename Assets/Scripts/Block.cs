using UnityEngine;

public class Block : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Sprite[] Sprites;
    private int SpriteNumber = 0;
    private string[] BlockPath;
    public string NewBlock;
    public string DestroyedBlock;
    private Money Money;

    private void Start() 
    {
        BlockPath = new string[]{"Coblestone", "Coper", "Gold", "Ruby", "Emerald", "Diamond"};
        NewBlock = BlockPath[0];
        DestroyedBlock = NewBlock;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Sprites = Resources.LoadAll<Sprite>($@"Sprites/{NewBlock}");
        Money = GetComponent<Money>();
    }
    private void OnMouseDown() 
    {
        if (SpriteNumber < 8)
        {
            SpriteNumber ++;
        }
        else
        {
            System.Random randomNumber = new System.Random();
            NewBlock = BlockPath[randomNumber.Next(0,6)];
            Sprites = Resources.LoadAll<Sprite>($@"Sprites/{NewBlock}");
            SpriteNumber = 0;
            Money.GetMoney();
            DestroyedBlock = NewBlock;
        }
        spriteRenderer.sprite = Sprites[SpriteNumber];
    }
}
