using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�q�[���[�̃~�j�Q�[���̔��e�Ǘ��Ɠ_���̐�������Ă���

public class MoveBurstObject : MonoBehaviour
{

    public BaseMiniGame game;

    [Header("���ʂɉ������X�R�A�𑗂�p�̕ϐ�")] public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;

    //���e���ړ����鑬�x
    [SerializeField] float MoveSpeed = 4.0f;
    //���e���ړ�����Ԋu
    [SerializeField] int direction =1;

    //�T�C�Y�ύX�p�̕ϐ�
    [SerializeField] float SizeX =1;
    [SerializeField] float SizeY =1;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject EffectImage;
    //�ړ������n�_��Transform
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    // public�Ő錾���Ainspector�Őݒ�\�ɂ���
    //dart:����
    public Sprite DartSprite;
    public Sprite BurstSprite;
    public Sprite BigBurstSprite;
    public Sprite NoneSprite;
    //���e�𗎂Ƃ����߂Ƀ��W�b�h�{�f�B��G�����������ǉ�
    Rigidbody2D rdbody2D;
    //CenterPosition�ɂ���GameObject�Ɣ�r���ă|�C���g�𔻒肳����
    [SerializeField] GameObject CenterPosition;
    [SerializeField] bool isBurst;
    //BaseGame��IsEnd�𑗂邽�߂ɁABurstMiniGame�ɑ���悤
    public bool isOut;

    public AudioSource audio;       //���g�̉������擾
    public AudioClip SE_Dart;       //�������o���Ƃ���SE
    public AudioClip SE_Burst;      //��肭���������Ƃ���SE
    public AudioClip SE_BigBurst;   //�ō��ɏ�肭�����ł�������SE
    bool isAudio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rdbody2D = GetComponent<Rigidbody2D>();
        EffectImage.SetActive(false);
        //������
        isBurst = false;
        isAudio = false;
    }
    //�N���b�N�����痎����d�g�݂�
    void OnMouseDown()
    {
        rdbody2D.gravityScale = 5.0f;
        var alpha = Bomb.GetComponent<SpriteRenderer>().color.a;
        alpha -= 0.2f * Time.deltaTime;
        MoveSpeed = 0.0f;
    }


    private void Update()
    {
        //�R�[�h��Z�����邽�߂ɕϐ��̒ǉ�
        var posX = transform.position.x;
        var posY = transform.position.y;
        var centerPosX = CenterPosition.transform.position.x;

        //�������ꏊ�ɉ����Ĕ����̌��ʂ�ω�������
        if (transform.position.y < -2.8f)
        {
            //�^�񒆂ɋ߂��ƍō��̏�ԂɂȂ�
            if (Mathf.Abs(posX - centerPosX) > 0.0f && Mathf.Abs(posX - centerPosX) <= 2.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BigBurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_BigBurst);
                    isAudio = true;
                }

                game.GameScore = score2;
                isOut = true;

            }
            //�������ꂽ�Ƃ��낾�Ƃ܂��܂��Ȕ�����
            else if (Mathf.Abs(posX - centerPosX) > 2.0f && Mathf.Abs(posX - centerPosX) <= 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Burst);
                    isAudio = true;
                }

                game.GameScore = score1;
                isOut = true;
            }
            //���ꂷ����Ə�肭�����ł��Ȃ����ʂ�
            else if (Mathf.Abs(posX - centerPosX) > 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = DartSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Dart);
                    isAudio = true;
                }

                game.GameScore = score;
                isOut = true;

            }
        }

    }
    private void FixedUpdate()
    {
        var PosY = transform.position.y;

        //���e���[�܂œ�������t�����Ɉړ�����悤�ɂ���
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, PosY, 0);

        //���e����Ɉړ����Ă���悤�ɂ���
        var bombScale = Bomb.transform.localScale;
        SizeX = Mathf.Sin(SizeX);
        SizeY =Mathf.Sin(SizeY);
        bombScale = new Vector3(SizeX, SizeY, 1f);

    }
}
