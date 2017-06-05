using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour {
    public Camera camera;
    //红色血条贴图  
    public Texture2D blueblood;
    //黑色血条贴图  
    public Texture2D redblood;
    //默认NPC血值  
    public int health;
    // Use this for initialization
    void Start () {
        //health = 200;
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
            Destroy(gameObject);
	}

    void OnGUI()
    {

        if (health < 0)
            health = 0;
        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //根据NPC头顶的3D坐标换算成它在2D屏幕中的坐标
        Vector2 position = camera.WorldToScreenPoint(worldPosition);
        //得到真实NPC头顶的2D坐标
        position = new Vector2(position.x, Screen.height - position.y);
        int HpZoom = 6;
        int blood_width = blueblood.width * health / 100;
        GUI.DrawTexture(new Rect(position.x, position.y, redblood.width / HpZoom, redblood.height / HpZoom), redblood);
        GUI.DrawTexture(new Rect(position.x, position.y, blood_width / HpZoom, blueblood.height / HpZoom), blueblood);

        //注解3
        //计算NPC名称的宽高
        Vector2 nameSize = GUI.skin.label.CalcSize(new GUIContent(name));
        //设置显示颜色为黄色
        GUI.color = Color.red;
        //绘制NPC名称
        GUI.Label(new Rect(position.x - (nameSize.x / 2), position.y - nameSize.y, nameSize.x, nameSize.y), name);

    }
}
