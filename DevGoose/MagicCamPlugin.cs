using System;
using System.Diagnostics;
//using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevGoose
{
	using UnityEngine;

	[AddComponentMenu("Camera/Simple Smooth Mouse Look ")]
	public class MagicCamPlugin : MonoBehaviour
		{
			public float SpeedF
			{
				get
				{
					return Time.unscaledDeltaTime / this.TimeSpeed;
				}
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x06000175 RID: 373 RVA: 0x00008CDC File Offset: 0x00006EDC
			public Camera FreeCamera
			{
				get
				{
					bool flag = this._FreeCamera != null;
					Camera freeCamera;
					if (flag)
					{
						freeCamera = this._FreeCamera;
					}
					else
					{
						this._FreeCamera = new GameObject("YLMod MAGIC CAMERA™").AddComponent<Camera>();
						this._FreeCamera.tag = "MainCamera";
						this._FreeCamera.enabled = false;
						this._FreeCamera.nearClipPlane = 0.3f;
						this._FreeCamera.farClipPlane = 4000f;
						this._MouseLook = this._FreeCamera.gameObject.AddComponent<SimpleSmoothMouseLook>();
						freeCamera = this._FreeCamera;
					}
					return freeCamera;
				}
			}

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x06000176 RID: 374 RVA: 0x00008D78 File Offset: 0x00006F78
			public SimpleSmoothMouseLook MouseLook
			{
				get
				{
					bool flag = this._MouseLook != null;
					SimpleSmoothMouseLook result;
					if (flag)
					{
						result = this._MouseLook;
					}
					else
					{
						result = (this._MouseLook = this.FreeCamera.GetComponent<SimpleSmoothMouseLook>());
					}
					return result;
				}
			}

			// Token: 0x06000177 RID: 375 RVA: 0x00008DB8 File Offset: 0x00006FB8
			public void Awake()
			{
				MagicCamPlugin.Instance = this;
				this._goose = GameObject.Find("Goose");
		}

			//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static event Action OnUpdate;

			// Token: 0x0600017A RID: 378 RVA: 0x000097B8 File Offset: 0x000079B8
			public void Update()
			{
				Action onUpdate = MagicCamPlugin.OnUpdate;
				if (onUpdate != null)
				{
					onUpdate();
				}
				bool buttonDown = (Input.GetKeyDown(KeyCode.O));
				if (buttonDown)
				{
					this.IsEnabled = !this.IsEnabled;
					bool flag = !this.IsEnabled;
					if (flag)
					{
						Time.timeScale = 1f;
						Cursor.lockState = CursorLockMode.None;
						Cursor.visible = true;
						this.FreeCamera.enabled = false;
						bool flag2 = this.PrevCamera != null;
						if (flag2)
						{
							this.PrevCamera.enabled = true;
						}
					}
					else
					{
						Time.timeScale = 0f;
						QualitySettings.lodBias = 1f;
						QualitySettings.maximumLODLevel = 0;
						this.PrevCamera = Camera.main;
						bool flag3 = this.PrevCamera != null;
						if (flag3)
						{
							this.FreeCamera.transform.position = this.PrevCamera.transform.position;
							this.FreeCamera.transform.eulerAngles = new Vector3(0f, this.PrevCamera.transform.eulerAngles.y, 0f);
							this.MouseLook.targetDirection = this.PrevCamera.transform.rotation.eulerAngles;
							this._FreeCamera.transform.position = this._goose.transform.position;
							this.MouseLook.mouseAbsolute = Vector2.zero;
							this.FreeCamera.fieldOfView = this.PrevCamera.fieldOfView;
							bool flag4 = this.FreeCamera.fieldOfView < 10f;
							if (flag4)
							{
								this.FreeCamera.fieldOfView = 75f;
							}
							this.PrevCamera.enabled = false;
						}
						this.FreeCamera.enabled = true;
					}
					UnityEngine.Debug.Log((this.IsEnabled ? "Enabled" : "Disabled") + " MAGIC CAMERA™ mode.");
				}
				bool flag5 = this._FreeCamera != null;
				if (flag5)
				{
					this.MouseLook.enabled = this.IsEnabled;
				}
				bool flag6 = !this.IsEnabled;
				if (!flag6)
				{
					this.FreeCamera.enabled = true;
					Transform transform = this.FreeCamera.transform;
				//this.Speed = Mathf.Max(0.01f, this.Speed + 0.01f * ModInput.GetAxis("FreeCam Move Speed"));
				if (Input.GetKeyDown(KeyCode.Alpha9))
				{
                    if (this.Speed <= 0.40f)
					{
						this.Speed += 0.01f;
					}
					
				}
				if  (Input.GetKeyDown(KeyCode.Alpha8))
				{
					if (this.Speed >= 0f)
					{
						this.Speed -= 0.01f;
					}
				}
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					this.Speed = 0f;
					Time.timeScale = 1f;
				}
				bool button = Input.GetKeyDown(KeyCode.Alpha0);
					if (button)
					{
						this.Speed = 0.1f;
						Time.timeScale = 0f;
					}
					float num = this.Speed;
					bool button2 = ModInput.GetButton("FreeCam Run");
					if (button2)
					{
						num *= 4f;
					}
					Vector3 vector = Vector3.zero;
					vector += transform.forward * ModInput.GetAxis("Vertical");
					float num2 = transform.rotation.eulerAngles.y;
					num2 = (num2 + 90f) / 180f * 3.1415927f;
					bool flag7 = transform.rotation.eulerAngles.z == 180f;
					if (flag7)
					{
						num2 += 3.1415927f;
					}
					vector += new Vector3(Mathf.Sin(num2), 0f, Mathf.Cos(num2)) * ModInput.GetAxis("Horizontal");
					bool flag8 = vector != Vector3.zero;
					if (flag8)
					{
						vector.Normalize();
						transform.position += vector * num * this.SpeedF;
					}
					transform.position += Vector3.up * ModInput.GetAxis("FreeCam Y Movement") * num * this.SpeedF;
					float timeScale = Time.timeScale;
					Time.timeScale = Mathf.Clamp(Time.timeScale + ModInput.GetAxis("FreeCam Game Speed") * ((Time.timeScale < 0.24999f) ? 0.01f : ((Time.timeScale < 1.99999f) ? 0.05f : ((Time.timeScale < 7.99999f) ? 0.5f : ((Time.timeScale < 15.99999f) ? 1f : 4f)))), 0f, 100f);
					bool button3 = ModInput.GetButton("FreeCam Game Speed Reset");
					if (button3)
					{
						Time.timeScale = 1f;
					}
					bool button4 = ModInput.GetButton("FreeCam Game Speed Freeze");
					if (button4)
					{
						Time.timeScale = 0f;
					}
					int num3 = Mathf.FloorToInt(Time.timeScale * 100f);
					bool flag9 = Time.timeScale >= 0.25f && num3 % 10 == 9;
					if (flag9)
					{
						Time.timeScale = (float)(num3 + 1) / 100f;
					}
					Vector3 position = transform.position;
					Vector3 eulerAngles = transform.eulerAngles;
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
					this._FreeCameraPos = this._FreeCamera.transform.position;
					this.MouseLook.enabled = false;
					}

				}
			}

			public void LateUpdate()
			{
				ModInput.LateUpdate();
			}

			public static MagicCamPlugin Instance;
			public bool IsEnabled;
			public bool IsGUIVisible = true;
			public const float DefaultSpeed = 0.1f;
			public float Speed = 0.1f;
			public float TimeSpeed = 0.008333334f;
			private Camera PrevCamera;
			private Camera _FreeCamera;
			private SimpleSmoothMouseLook _MouseLook;
			public GameObject _goose;
			public Vector3 _FreeCameraPos;
		}
	}
