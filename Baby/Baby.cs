using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public GameObject baby;             //�Ԃ����̌��摜
    public BaseMiniGame game;           //�p�����̃N���X

    [Header("���ʂɉ������X�R�A�𑗂�p�̕ϐ�")] public  MiniGameScore score;         
    public MiniGameScore score1;        
    public MiniGameScore score2;        
    

    public Sprite babyImage;        //�Ԃ����̌��摜
    public Sprite fatImage;         //�������摜
    public Sprite NormalImage;      //�����Ȃ��Ă��Ȃ��摜
    public Sprite machoImage;       //���L���L�ȉ摜

    public AudioSource myAudio;     //���g�̉����iStart�Œ�`���Ă���j

    public AudioClip SE_Muscle;     //�}�b�`���ɂȂ�������SE
    public AudioClip SE_Rough;      //�����Ă��܂�������SE

    public bool isOut;              //�������I��������Ƃ�m�点��
    public bool isAudio;            //SE�≹�y���d�Ȃ�Ȃ��悤�ɂ���
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //���g�̉������擾

        baby.GetComponent<SpriteRenderer>().sprite = babyImage; 
        //������
        isOut = false;
        isAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isOut��true�ɂȂ����牽���N�����Ȃ��悤�ɂ��Ă���
        if (isOut) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�v���C���[���ߕt�����A�C�e���ɂ��摜�ƃX�R�A�̕ω���
        //�����āASE��炵�A�Q�[���I����`���Ă���


        if(collision.gameObject.tag == "Normal")
        {
            baby.GetComponent<SpriteRenderer>().sprite = NormalImage;
            Destroy(collision.gameObject);
            game.GameScore = score;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Rough);
                isAudio = true;
            }

            isOut = true;
        }
        else if(collision.gameObject.tag == "Fat")
        {
            baby.GetComponent<SpriteRenderer>().sprite = fatImage;
            Destroy(collision.gameObject);
            game.GameScore = score1;

            isOut = true;
        }
        else if(collision.gameObject.tag == "macho")
        {
            baby.GetComponent<SpriteRenderer>().sprite = machoImage;
            Destroy(collision.gameObject);
            game.GameScore = score2;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Muscle);
                isAudio = true;
            }

            isOut = true;
        }
    }
}
