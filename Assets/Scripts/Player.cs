using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{

	public float speed = 4f; //歩くスピード
	private Rigidbody2D newrigidbody2D;
	private Animator anim;

	void Start()
	{
		//各コンポーネントをキャッシュしておく
		anim = GetComponent<Animator>();
		newrigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//左キー: -1、右キー: 1
		float x = Input.GetAxisRaw("Horizontal");
		//左か右を入力したら
		if (x != 0)
		{
			//入力方向へ移動
			newrigidbody2D.velocity = new Vector2(x * speed, newrigidbody2D.velocity.y);
			//localScale.xを-1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//Wait→Dash
			anim.SetBool("Dash", true);
			//左も右も入力していなかったら
		}
		else
		{
			//横移動の速度を0にしてピタッと止まるようにする
			newrigidbody2D.velocity = new Vector2(0, newrigidbody2D.velocity.y);
			//右向きにする
			Vector2 temp = transform.localScale;
			temp.x = 1;
			transform.localScale = temp;
			//Dash→Wait
			anim.SetBool("Dash", false);
		}
	}
}