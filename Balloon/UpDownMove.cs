using System.Collections;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    //�㉺�Ƀ|���v�𓮂����ۂɎg��
    Vector3 screenPoint;
    Vector3 offset;

    //�p�����̃N���X
    public BaseMiniGame game;

    [Header("���ʂɉ������X�R�A�𑗂�p�̕ϐ�")] public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;

    //
    [Header("�ړ��ł���ő�l�ƍŒ�l"),SerializeField] float minY;
    [SerializeField] float maxY;

    //�㉺�����񐔂ɂ���đ�����l
    [SerializeField] int Count;

    //�o���[���̉摜��ω������邽�߂ɕK�v
    [SerializeField] GameObject BalloonSpriteRenderer;

    // public�Ő錾���Ainspector�Őݒ�\�ɂ���
    //swell:�c���
    public Sprite SwellSprite;
    public Sprite BigSwellSprite;
    public Sprite BurstSprite;

    public bool isOut;//�Q�[���̏I����e�ɓn��

    //�����p
    public AudioSource audio;   //���g�̉������擾
    public AudioClip SE_Down;   //���܂�c��܂Ȃ�������
    public AudioClip SE_Burst;  //�c��܂���������
    public AudioClip SE_InAir;  //��������c��񂾎�
    //�A�ł��ꂽ�Ƃ��̑Ώ��̂��߂ɂ���bool�l
    public  bool isAudio;
    public  bool isAudio1;
    public  bool isAudio2;

    //��C�p��SE
    float audioTimer;
    public  bool isAirSE;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        //������
        audioTimer = 0;
        isAudio = false;
        isAudio1 = false;
        isAudio2 = false;
        isAirSE = true;

        isOut = false;
    }
    // Start is called before the first frame update
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(0, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        var pos = transform.position;
        // x�������̈ړ��͈͐���
        currentPosition = new Vector3(pos.x, Mathf.Clamp(currentPosition.y, minY, maxY), 0);

        transform.position = currentPosition;
    }
    private void Update()
    {
        if (isOut) return;  //�Q�[���I��

        //���������Ŏ��Ԃ̊Ǘ���C���Ă���
        if(audioTimer>=0.0f)
        {
            audioTimer -= Time.deltaTime;
            isAirSE = true;
        }

        //�����ɂ���ăo���[���̃T�C�Y���ύX
        if (Count > 1300 && Count < 1800)
        {
            BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = SwellSprite;
            game.GameScore = score;
            if (!isAudio)
            {
                isAirSE = false;
                StartCoroutine(DelayCoroutine());
                audio.PlayOneShot(SE_InAir);
                isAudio = true;

            }

        }
        else if (Count >= 1800 && Count < 2300)
        {
            BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BigSwellSprite;
            game.GameScore = score1;
            if (!isAudio1)
            {
                isAirSE = false;
                StartCoroutine(DelayCoroutine());
                audio.PlayOneShot(SE_InAir);
                isAudio1 = true;

            }

        }
        else if (Count >= 2300)
        {
            BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BurstSprite;
            game.GameScore = score2;
            if (!isAudio2)
            {
                isAirSE = false;
                StartCoroutine(DelayCoroutine());
                audio.PlayOneShot(SE_Burst);
                isAudio2 = true;
                StartCoroutine(LastCoroutine());
                isOut = true;
            }

        }
        //�|���v�̏㉺�̌��x�����߁A���x�ɒB�����甽����Ԃ��悤�ɂ��Ă���
        var pos = transform.position;
        if (pos.y >= 0.7f)
        {
            Count++;

            if (audioTimer <= 0.0f&&isAirSE)
            {
                audio.PlayOneShot(SE_Down);
                audioTimer = 1.0f;
            }
        }
        else if (pos.y <= -1.3f)
        {
            Count++;
            if (audioTimer <= 0.0f && isAirSE)
            {
                audio.PlayOneShot(SE_Down);
                audioTimer = 1.0f;
            }

        }
    }

    // �R���[�`���{��
    //������܂ł̊Ԋu������Ă���
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        isAirSE = false;

    }
    //�Q�[���I���O�̍ŏI�m�F
    private IEnumerator LastCoroutine()
    {
        yield return new WaitForSeconds(2.25f);

        isAirSE = false;
        isAudio = false;
        audio.Stop();

    }
}
