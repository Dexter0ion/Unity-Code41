using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //玩家持有的枪
    public GameObject weapon;
    //是否开火
    [HideInInspector]
    public bool isFiring = false;
    //枪的脚本组件
    private Gun gunScript;

    //获得角色控制器组件
    private CharacterController controller;

    private Transform _t;

    private float input_x;
    private float input_y;

    private Vector3 _velocity = Vector3.zero;

    public float _speed = 1;


    public int health;

    //gui 血条纹理
    public Texture2D redblood;
    public Texture2D blueblood;
    public Camera camera;

    /*
    private float rotateAngle;
    private float targetAngle = 0;
    private float currentAngle;
    private float yVelocity = 0.0f;
    */
    // Use this for initialization
    void Start()
    {

        //controller = GetComponent<CharacterController>();
        _t = transform;


        /*
        if (weapon == null)
            weapon = gameObject;
        if (weapon != null)
            gunScript.controller = _t.gameObject;
            */
        gunScript = GetComponent<Gun>();

        health = 100;
        //角度？
        // currentAngle = targetAngle = HorizontalAngle(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //角度控制 ->不懂
        /*
        rotateAngle = Input.GetAxis("Rotate") * Time.deltaTime * 50;
        targetAngle += rotateAngle;

        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref yVelocity, 0.3f);
        transform.rotation = Quaternion.Euler(0, currentAngle, 0);
        */
        //平移控制
        /*
        input_x = Input.GetAxis("Horizontal");
        input_y = Input.GetAxis("Vertical");
        int altitude = 0;
        if (Input.GetKey(KeyCode.P))
            altitude = 10;
        if (Input.GetKey(KeyCode.L))
            altitude = -10;

        float input_modifier = (input_x != 0.0f && input_y != 0.0f) ? 0.7071f : 1.0f;
        _velocity = new Vector3(input_x * input_modifier, altitude, input_y * input_modifier);

        _velocity = _t.TransformDirection(_velocity) * _speed;

        controller.Move(_velocity * Time.deltaTime);
        */

        if (health <= 0)
        {
            Destroy(this.gameObject);

        }

        //如果玩家按下开火键
        if (Input.GetKey(KeyCode.J))
        {
            isFiring = true;
            gunScript.Fire();
        }
    }


    /*
    private float HorizontalAngle(Vector3 direction)
    {
        float num = Mathf.Atan2(direction.x, direction.z) * 57.29578f;
        if (num < 0f)
        {
            num += 360f;
        }
        return num;
    }
    */

    void OnGUI()
    {
        /*
        if (health < 0)
            health = 0;
        int HpZoom = 4;
        int blood_width = blueblood.width * health / 100;
        GUI.DrawTexture(new Rect(250, 250, redblood.width / HpZoom, redblood.height / HpZoom), redblood);
        GUI.DrawTexture(new Rect(250, 250, blood_width / HpZoom, blueblood.height / HpZoom), blueblood);
        */



        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实NPC头顶的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        int HpZoom = 4;
        int blood_width = blueblood.width * health / 100;
        GUI.DrawTexture(new Rect(position.x, position.y, redblood.width / HpZoom, redblood.height / HpZoom), redblood);
        GUI.DrawTexture(new Rect(position.x, position.y, blood_width / HpZoom, blueblood.height / HpZoom), blueblood);

    }
}
