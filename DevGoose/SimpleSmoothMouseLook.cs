using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
	public class SimpleSmoothMouseLook : MonoBehaviour
	{
		private void Start()
		{
			this.targetDirection = base.transform.localRotation.eulerAngles;
			bool flag = this.characterBody;
			if (flag)
			{
				this.targetCharacterDirection = this.characterBody.transform.localRotation.eulerAngles;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B0 File Offset: 0x000002B0
		private void Update()
		{
			bool key = Input.GetKey(this.ReleaseKey);
			if (key)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Quaternion quaternion = Quaternion.Euler(this.targetDirection);
				Quaternion rhs = Quaternion.Euler(this.targetCharacterDirection);
				Vector2 vector = new Vector2(ModInput.GetAxisRaw("FPV Camera X"), ModInput.GetAxisRaw("FPV Camera Y"));
				vector = Vector2.Scale(vector, new Vector2(this.sensitivity.x * this.smoothing.x, this.sensitivity.y * this.smoothing.y));
				this.smoothMouse.x = Mathf.Lerp(this.smoothMouse.x, vector.x, 1f / this.smoothing.x);
				this.smoothMouse.y = Mathf.Lerp(this.smoothMouse.y, vector.y, 1f / this.smoothing.y);
				this.mouseAbsolute += this.smoothMouse;
				bool flag = this.clampInDegrees.x < 360f;
				if (flag)
				{
					this.mouseAbsolute.x = Mathf.Clamp(this.mouseAbsolute.x, -this.clampInDegrees.x * 0.5f, this.clampInDegrees.x * 0.5f);
				}
				Quaternion localRotation = Quaternion.AngleAxis(-this.mouseAbsolute.y, quaternion * Vector3.right);
				base.transform.localRotation = localRotation;
				bool flag2 = this.clampInDegrees.y < 360f;
				if (flag2)
				{
					this.mouseAbsolute.y = Mathf.Clamp(this.mouseAbsolute.y, -this.clampInDegrees.y * 0.5f, this.clampInDegrees.y * 0.5f);
				}
				base.transform.localRotation *= quaternion;
				bool flag3 = this.characterBody;
				if (flag3)
				{
					Quaternion localRotation2 = Quaternion.AngleAxis(this.mouseAbsolute.x, this.characterBody.transform.up);
					this.characterBody.transform.localRotation = localRotation2;
					this.characterBody.transform.localRotation *= rhs;
				}
				else
				{
					Quaternion rhs2 = Quaternion.AngleAxis(this.mouseAbsolute.x, base.transform.InverseTransformDirection(Vector3.up));
					base.transform.localRotation *= rhs2;
				}
			}
		}

		[HideInInspector]
		public Vector2 mouseAbsolute;

		// Token: 0x04000002 RID: 2
		[HideInInspector]
		public Vector2 smoothMouse;

		// Token: 0x04000003 RID: 3
		public Vector2 clampInDegrees = new Vector2(360f, 180f);

		// Token: 0x04000004 RID: 4
		public bool lockCursor;

		// Token: 0x04000005 RID: 5
		public Vector2 sensitivity = new Vector2(2f, 2f);

		// Token: 0x04000006 RID: 6
		public Vector2 smoothing = new Vector2(3f, 3f);

		// Token: 0x04000007 RID: 7
		public Vector2 targetDirection;

		// Token: 0x04000008 RID: 8
		public Vector2 targetCharacterDirection;

		// Token: 0x04000009 RID: 9
		public GameObject characterBody;

		// Token: 0x0400000A RID: 10
		public KeyCode ReleaseKey = KeyCode.LeftAlt;
	}
}

