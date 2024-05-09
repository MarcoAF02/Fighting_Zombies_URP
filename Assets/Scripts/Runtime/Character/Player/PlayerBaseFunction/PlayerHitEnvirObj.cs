using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家和环境中的小物体发生物理交互
/// </summary>
public class PlayerHitEnvirObj : MonoBehaviour
{
	#region 基本组件和变量

	[Header("玩家角色控制器")]
	[SerializeField] private PlayerController playerController;

	[Header("玩家推动环境物体的力量")]
	[SerializeField] private float playerHitObjForce;

	private Vector3 pushDir = Vector3.zero;

	#endregion

	#region 物理碰撞函数

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;

		if (body == null || body.isKinematic) return;
		if (hit.moveDirection.y < -0.3) return; // 不把物体推到下面去

		pushDir = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);
		body.velocity = pushDir * playerHitObjForce;
	}

	#endregion

}
