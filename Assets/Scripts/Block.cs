using System;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField]private Sprite[] _coblestone;
    [SerializeField]private Sprite[] _iron;
    [SerializeField]private Sprite[] _gold;
    [SerializeField]private Sprite[] _diamond;
    [SerializeField]private Sprite[] _emerald;
    [SerializeField]private Sprite[] _ruby;
    private Sprite[] _currentBlock;
    private SpriteRenderer spriteRenderer;
    private int _currentBlockID;
    private int _сlickCount;
    [SerializeField]private AudioSource _digSound;
    [SerializeField]private AudioSource _destroySound;

    public static Action<int> DestroyBlock;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetRandomBlock();
        spriteRenderer.sprite = _currentBlock[0];
    }
    private void OnMouseDown() 
    {
        if (_сlickCount < 8)
        {
            _digSound.Play();
            _сlickCount ++;
            this.GetComponent<Animator>().Play("Block");
            GameObject.Find("BlockParticle").GetComponent<ParticleSystem>().Play();
        }
        else
        {
            _destroySound.Play();
            int _destroyedBlockID = _currentBlockID;
            DestroyBlock?.Invoke(_destroyedBlockID);
            _сlickCount = 0;
            GetRandomBlock();
        }
        spriteRenderer.sprite = _currentBlock[_сlickCount];
    }
    private void GetRandomBlock()
    {
        System.Random random = new System.Random();
        _currentBlockID = random.Next(0,6);
        if(_currentBlockID == 0) {_currentBlock = _coblestone;}
        else if(_currentBlockID == 1) {_currentBlock = _iron;}
        else if(_currentBlockID == 2) {_currentBlock = _gold;}
        else if(_currentBlockID == 3) {_currentBlock = _diamond;}
        else if(_currentBlockID == 4) {_currentBlock = _emerald;}
        else if(_currentBlockID == 5) {_currentBlock = _ruby;}
        
    }
}
