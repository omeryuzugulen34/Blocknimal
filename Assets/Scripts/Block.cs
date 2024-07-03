using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using static UnityEngine.ParticleSystem;

public class Block : MonoBehaviour
{
    public Vector2 firstTouchPos;
    public Vector2 FinalTouchPos;
    public float swipeangle;

    public float MoveTime = 0.5f;
    public float ElapsedTime = 0f;
    public bool isMoving;

    private Vector2 startpos;
    private Vector2 targetpos;

    RaycastHit2D rayhitdown;
    RaycastHit2D rayhitup;
    RaycastHit2D rayhitleft;
    RaycastHit2D rayhitright;

    public GameObject down, up, left, right;

    public GameObject Bdown, Bup, Bleft, Bright;

    public GameObject Gm;

    private Vector3 offset;

    public bool RealMoving;

    public bool face;

    public Color thiscolor;
    public GameObject particlee;
    bool onetime;

    public bool clicked;

    public bool snapping;

    public AudioClip Walk;
    public AudioClip Puff;

    GameObject[] soundObj;
    AudioSource sound;

    void Start()
    {
        soundObj = GameObject.FindGameObjectsWithTag("GameSound");
        Gm = GameObject.Find("GameManager");
        particlee = Gm.GetComponent<GameManager>().particle;
        
    }

   
    private void DestroyObjects()
    {
        if (onetime)
        {
            onetime = false;
            GameObject partcle = Instantiate(particlee);
            partcle.transform.position = this.gameObject.transform.position;
            var main = partcle.GetComponent<ParticleSystem>().main;
            main.startColor = thiscolor;
            partcle.GetComponent<ParticleSystem>().Play();
            Gm.GetComponent<GameManager>().Blocks.Remove(this.gameObject);
            for (int i = 0; i < Gm.GetComponent<GameManager>().IsMovings.Count; i++)
            {
                Gm.GetComponent<GameManager>().IsMovings[i] = false;
            }
            sound = soundObj[0].GetComponent<AudioSource>();
            sound.PlayOneShot(Puff, sound.volume);
            Destroy(gameObject);
            //Destroy(down);
            //Destroy(up);
        }


    }

   

    void Update()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y-1.1f, transform.position.z), Vector2.down * .1f, Color.yellow);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z), -Vector2.down * .2f, Color.green);
        Debug.DrawRay(new Vector3(transform.position.x - 1.1f, transform.position.y, transform.position.z), Vector2.left * .2f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x + 1.1f, transform.position.y, transform.position.z), -Vector2.left * .2f, Color.blue);

        rayhitdown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 1.1f), Vector2.down, .1f);
        rayhitup = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y + 1.1f), -Vector2.down, .2f);
        rayhitleft = Physics2D.Raycast(new Vector3(transform.position.x - 1.1f, transform.position.y), Vector2.left, .2f);
        rayhitright = Physics2D.Raycast(new Vector3(transform.position.x + 1.1f, transform.position.y), -Vector2.left, .2f);

        if (down != null || up != null &&isMoving == false)
        {
            onetime = true;
            Invoke("DestroyObjects", 0.55f);
        }
        if (left != null || right != null&& isMoving == false)
        {
            onetime = true;
            Invoke("DestroyObjects", 0.55f);
        }

        //if (DOTween.IsTweening(gameObject.transform))
        //{
        //    //     RealMoving = true;
        //    this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        //}

       // if (Bdown != null)
       // {
       //     if (!face)
       //     {
       //         this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
       //         this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
       //     }
       //}


        if (rayhitdown && rayhitdown.collider.gameObject != gameObject)
        {
            Bdown = rayhitdown.collider.gameObject;
            RealMoving = false;

        }
        else
        {
            Bdown = null;
            RealMoving = true;
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //  Gm.GetComponent<GameManager>().Move = true;

        }



        if (rayhitup && rayhitup.collider.gameObject != gameObject)
        {
            Bup = rayhitup.collider.gameObject;
        }
        else
        {
            Bup = null;
        }

        if (rayhitleft && rayhitleft.collider.gameObject != gameObject)
        {
            Bleft = rayhitleft.collider.gameObject;
        }
        else
        {
            Bleft = null;
        }

        if (rayhitright &&  rayhitright.collider.gameObject != gameObject)
        {
            Bright = rayhitright.collider.gameObject;
        }
        else
        {
            Bright = null;
        }

        if (rayhitdown && rayhitdown.collider.gameObject.tag == this.gameObject.tag && rayhitdown.collider.gameObject != gameObject && Bdown != null && rayhitdown.collider.gameObject.GetComponent<Block>().Bdown != null)
        {
            down = rayhitdown.collider.gameObject;
        }
        else
        {
            down = null;
        }

        if (rayhitup && rayhitup.collider.gameObject.tag == this.gameObject.tag && rayhitup.collider.gameObject != gameObject && Bdown != null && rayhitup.collider.gameObject.GetComponent<Block>().Bdown != null)
        {
            up = rayhitup.collider.gameObject;
        }
        else
        {
            up = null;
        }

        if (rayhitleft && rayhitleft.collider.gameObject.tag == this.gameObject.tag && rayhitleft.collider.gameObject != gameObject && Bdown != null && rayhitleft.collider.gameObject.GetComponent<Block>().Bdown != null)
        {
            left = rayhitleft.collider.gameObject;
        }
        else
        {
            left = null;
        }

        if (rayhitright && rayhitright.collider.gameObject.tag == this.gameObject.tag && rayhitright.collider.gameObject != gameObject && Bdown != null && rayhitright.collider.gameObject.GetComponent<Block>().Bdown != null)
        {
            right = rayhitright.collider.gameObject;
        }
        else
        {
            right = null;
        }

        if(right != null || left != null || up != null || down != null)
        {
            RealMoving = true;
        }

        
    }

    private void OnMouseDown()
    {
       if(DOTween.IsTweening(gameObject.transform) == false && RealMoving == false)
        {
            offset = transform.position - GridSystem.GetMouseWorldPosition();
            firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            face = true;
        }
        
            
        
        
    }

    private void OnMouseDrag()
    {
        if (DOTween.IsTweening(gameObject.transform) == false && RealMoving == false)
        {
            Vector3 pos = GridSystem.GetMouseWorldPosition() + offset;
            FinalTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            swipeangle = Mathf.Atan2(firstTouchPos.y - FinalTouchPos.y, firstTouchPos.x - FinalTouchPos.x);
            MoveBlock();

        }
        face = false;
    }


    private void OnMouseUp()
    {

        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    void MoveBlock()
    {

        if (swipeangle > 2f && swipeangle <= 4 && swipeangle != 0 && Bright == null && Bdown != null && DOTween.IsTweening(gameObject.transform) == false && RealMoving == false && Gm.GetComponent<GameManager>().Move == false)//Right Swipe
        {
            gameObject.transform.DOMoveX(transform.position.x + 2, MoveTime);
            gameObject.transform.DOScaleY(1.8f, MoveTime / 2).OnComplete(() => gameObject.transform.DOScaleY(2, MoveTime / 2));
            if (Bdown.CompareTag("Ground"))
            {
                sound = soundObj[0].GetComponent<AudioSource>();
                sound.PlayOneShot(Walk, sound.volume);
            }
        }
        else if (swipeangle > -1 && swipeangle <= 1 && swipeangle != 0 && Bleft == null && Bdown != null && DOTween.IsTweening(gameObject.transform) == false && RealMoving == false && Gm.GetComponent<GameManager>().Move == false)//Left Swipe
        {
            gameObject.transform.DOMoveX(transform.position.x - 2, MoveTime);
            gameObject.transform.DOScaleY(1.8f, MoveTime / 2).OnComplete(() => gameObject.transform.DOScaleY(2, MoveTime / 2));
            if (Bdown.CompareTag("Ground"))
            {
                sound = soundObj[0].GetComponent<AudioSource>();
                sound.PlayOneShot(Walk, sound.volume);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("restarted");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Kitty"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Doggy"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Penguin"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Coala"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}