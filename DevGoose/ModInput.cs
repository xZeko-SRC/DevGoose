using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DevGoose
{
		public static class ModInput
		{
			// Token: 0x06000186 RID: 390 RVA: 0x0000AAA4 File Offset: 0x00008CA4
			internal static void LateUpdate()
			{
				foreach (KeyValuePair<string, Func<bool>> keyValuePair in ModInput.ButtonMap)
				{
					IDictionary<string, bool> buttonsPrev = ModInput._ButtonsPrev;
					string key = keyValuePair.Key;
					Func<bool> value = keyValuePair.Value;
					buttonsPrev[key] = (value != null && value());
				}
			}

			// Token: 0x06000187 RID: 391 RVA: 0x0000AB14 File Offset: 0x00008D14
			public static bool GetButton(string button)
			{
				Func<bool> func;
				bool flag = ModInput.ButtonMap.TryGetValue(button, out func) && func != null;
				return flag && func();
			}

			// Token: 0x06000188 RID: 392 RVA: 0x0000AB4C File Offset: 0x00008D4C
			public static bool GetButtonDown(string button)
			{
				bool flag2;
				bool flag = !ModInput._ButtonsPrev.TryGetValue(button, out flag2);
				return !flag && !flag2 && ModInput.GetButton(button);
			}

			// Token: 0x06000189 RID: 393 RVA: 0x0000AB82 File Offset: 0x00008D82
			public static float GetAxis(string axis)
			{
				return ModInput.GetAxisRaw(axis);
			}

			// Token: 0x0600018A RID: 394 RVA: 0x0000AB8C File Offset: 0x00008D8C
			public static float GetAxisRaw(string axis)
			{
				Func<float> func;
				bool flag = ModInput.AxisMap.TryGetValue(axis, out func) && func != null;
				float result;
				if (flag)
				{
					result = func();
				}
				else
				{
					result = 0f;
				}
				return result;
			}

			// Token: 0x0600018B RID: 395 RVA: 0x0000ABC8 File Offset: 0x00008DC8
			static ModInput()
			{
				ModInput.AxisMap["Horizontal"] = (() => ModInput.AxisOr(Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f), ModInput.Deadzone(Input.GetAxis("Joy1Axis1"), 0.17f) * 0.3f));
				ModInput.AxisMap["Vertical"] = (() => ModInput.AxisOr(Input.GetKey(KeyCode.S) ? -1f : (Input.GetKey(KeyCode.W) ? 1f : 0f), ModInput.Deadzone(-Input.GetAxis("Joy1Axis2"), 0.17f) * 0.3f));
				ModInput.AxisMap["FPV Camera X"] = (() => ModInput.AxisOr(Input.GetAxis("Mouse X") * 0.5f, ModInput.Deadzone(Input.GetAxis("Joy1Axis4"), 0.17f) * 0.5f));
				ModInput.AxisMap["FPV Camera Y"] = (() => ModInput.AxisOr(Input.GetAxis("Mouse Y") * 0.5f, ModInput.Deadzone(-Input.GetAxis("Joy1Axis5"), 0.17f) * 0.5f));
				ModInput.AxisMap["Mouse X"] = (() => Input.GetAxis("Mouse X"));
				ModInput.AxisMap["Mouse Y"] = (() => Input.GetAxis("Mouse Y"));
			}

			// Token: 0x0600018C RID: 396 RVA: 0x0000ACB4 File Offset: 0x00008EB4
			public static float AxisOr(float a, float b)
			{
				bool flag = Mathf.Abs(a) > 0.1f;
				float result;
				if (flag)
				{
					result = a;
				}
				else
				{
					result = b;
				}
				return result;
			}

			// Token: 0x0600018D RID: 397 RVA: 0x0000ACDC File Offset: 0x00008EDC
			public static float Deadzone(float a, float d)
			{
				bool flag = Mathf.Abs(a) < d;
				float result;
				if (flag)
				{
					result = 0f;
				}
				else
				{
					result = a;
				}
				return result;
			}

			// Token: 0x0600018E RID: 398 RVA: 0x0000AD04 File Offset: 0x00008F04
			private static void _InitButtonMap(string id, params string[] names)
			{
				Func<bool> value = () => Input.GetButton(id);
				for (int i = names.Length - 1; i > -1; i--)
				{
					ModInput.ButtonMap[names[i]] = value;
				}
			}

			// Token: 0x040000CE RID: 206
			public static IDictionary<string, Func<bool>> ButtonMap = new Dictionary<string, Func<bool>>();

			// Token: 0x040000CF RID: 207
			public static IDictionary<string, Func<float>> AxisMap = new Dictionary<string, Func<float>>();

			// Token: 0x040000D0 RID: 208
			private static IDictionary<string, bool> _ButtonsPrev = new Dictionary<string, bool>();
		}
	}
