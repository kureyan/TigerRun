using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{

	public float speed = 4f; //�����X�s�[�h
	private Rigidbody2D newrigidbody2D;
	private Animator anim;

	void Start()
	{
		//�e�R���|�[�l���g���L���b�V�����Ă���
		anim = GetComponent<Animator>();
		newrigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		//���L�[: -1�A�E�L�[: 1
		float x = Input.GetAxisRaw("Horizontal");
		//�����E����͂�����
		if (x != 0)
		{
			//���͕����ֈړ�
			newrigidbody2D.velocity = new Vector2(x * speed, newrigidbody2D.velocity.y);
			//localScale.x��-1�ɂ���Ɖ摜�����]����
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//Wait��Dash
			anim.SetBool("Dash", true);
			//�����E�����͂��Ă��Ȃ�������
		}
		else
		{
			//���ړ��̑��x��0�ɂ��ăs�^�b�Ǝ~�܂�悤�ɂ���
			newrigidbody2D.velocity = new Vector2(0, newrigidbody2D.velocity.y);
			//�E�����ɂ���
			Vector2 temp = transform.localScale;
			temp.x = 1;
			transform.localScale = temp;
			//Dash��Wait
			anim.SetBool("Dash", false);
		}
	}
}