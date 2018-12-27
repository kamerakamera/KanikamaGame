using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    Rigidbody rb;
    public int Hp { get; set; }
    public int startHp;
    [SerializeField]
    private GameObject Bullet;
    public Camera mainCamera;
    public Vector3 mousePosition;
    public static float rotateSensitivityPower = 4;
    [SerializeField]
    float avoidInterval,avoidCoolTime;
    float knockBackTime = 0,invincibleCoolTime = 0,avoidIntervalCount,avoidCoolTimeCount;
    RaycastHit hit;
    bool isKnockBack, isAvoid, avoidAble, lockOnShotAble, avoidInput;
    Vector3 moveDirection;
    bool front,back,right,left,up;
    int straight, side;
    public bool isInvincible,isDeath;
    public float MovePower { get; set; }
    public float StartMovePower { get; set; }
    public Image damegeFlash;
    

    // Use this for initialization
    void Start () {
        Hp = startHp;
        rb = GetComponent<Rigidbody>();
        MovePower = 10;
        StartMovePower = MovePower;
        //damegeFlash.enabled = false;
        avoidAble = true;
        isAvoid = false;
        isDeath =false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDeath) {
            Death();
        }
        else {
            if (Input.GetMouseButtonDown(0)) {
                Shot();
            }
            MoveInput();
            AvoidInput();
        }
        
    }

    void FixedUpdate() {
        if (!isDeath) {
            LookAround();
            if(!isAvoid){
                Move();
            }
        }
        
        if (avoidInput && avoidAble && !isAvoid) {
            Avoid();
            isAvoid = true;
            avoidAble = false;
        }
        
        if (isAvoid) {
            IntervalCount(ref avoidIntervalCount, avoidInterval, ref isAvoid, false);
        }
        if(!isAvoid && !avoidAble) {
            IntervalCount(ref avoidCoolTimeCount, avoidCoolTime, ref avoidAble, true);
        }

        //無敵時間
        if (isInvincible) {
            invincibleCoolTime += Time.fixedDeltaTime;
            damegeFlash.color = new Color(damegeFlash.color.r, damegeFlash.color.g, damegeFlash.color.b, 1 - invincibleCoolTime);
            if (invincibleCoolTime >= 1.0f) {
                isInvincible = false;
            }
        }

        //ノックバック処理
        if (isKnockBack) {
            knockBackTime += Time.fixedDeltaTime;
            if (knockBackTime >= 0.8f) {
                isKnockBack = false;
            }
        }
    }

    void LookAround() {
        mousePosition = Input.mousePosition;
        float mousePositionX = Input.GetAxis("Mouse X");
        //縦回転
        //横回転
        transform.Rotate(0, mousePositionX * rotateSensitivityPower, 0, Space.World);
    }

    void MoveInput() {
        if (Input.GetKey("w")) {
            front = true;
        } else front = false;

        if (Input.GetKey("s")) {
            back = true;
        } else back = false;

        if (Input.GetKey("a")) {
            left = true;
        } else left = false;

        if (Input.GetKey("d")) {
            right = true;
        } else right = false;
        if (front) {
            straight = 1;
        }
        if (back) {
            straight = -1;
        }
        if ((front && back) || (!front && !back)) straight = 0;

        if (left) {
            side = -1;
        }
        if (right) {
            side = 1;
        }
        if ((left && right) || (!left && !right)) side = 0;
    }

    void Move() {
        moveDirection = new Vector3(transform.forward.x * straight + transform.right.x * side,rb.velocity.y,transform.forward.z * straight + transform.right.z * side).normalized;
        rb.velocity = new Vector3(moveDirection.x * MovePower, rb.velocity.y, moveDirection.z * MovePower);
    }

    void AvoidInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            avoidInput = true;
        } else {
            avoidInput = false;
        }
    }

    void Avoid() {
        //回避方法は色々考えた方がよさそう
        if (side == 0 && straight == 0) {
            straight = -1;
        }
        moveDirection = new Vector3(transform.forward.x * straight + transform.right.x * side, rb.velocity.y, transform.forward.z * straight + transform.right.z * side).normalized;
        rb.velocity = new Vector3(moveDirection.x * MovePower * 4.0f, rb.velocity.y, moveDirection.z * MovePower * 4.0f);
    }

    void IntervalCount(ref float count, float intervalTime, ref bool isTrigger, bool setBool) {
        count += Time.deltaTime;
        if (count >= intervalTime) {
            isTrigger = setBool;
            count = 0;
        }
    }

    void Shot() {
        Instantiate(Bullet,transform.position,transform.rotation);
    }

    public void Damege() {
        if (!isInvincible) {
            Hp -= 1;
            isKnockBack = true;
            isInvincible = true;
            damegeFlash.enabled = true;
            knockBackTime = 0;
            invincibleCoolTime = 0;
            if (Hp <= 0) {
                isDeath = true;
            }
        }
    }

    public void Damege(int damege) {
        Hp -= damege - 1;
        Damege();
    }

    void Death() {
        //SceneManager.LoadScene("End");
    }

    public bool GetAvoid(){
        return isAvoid;
    }
}
