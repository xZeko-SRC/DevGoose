using System;
using System.Diagnostics;
//using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DevGoose
{
	using UnityEngine;

	[AddComponentMenu("Camera/Simple Smooth Mouse Look ")]
	public class FPSMod : MonoBehaviour
		{
			public float SpeedF
			{
				get
				{
					return Time.unscaledDeltaTime / this.TimeSpeed;
				}
			}

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
						this._FreeCamera = new GameObject("Dev Goose").AddComponent<Camera>();
						this._FreeCamera.tag = "MainCamera";
						this._FreeCamera.enabled = false;
						this._FreeCamera.nearClipPlane = 0.3f;
						this._FreeCamera.farClipPlane = 4000f;	
						this._MouseLook = this._FreeCamera.gameObject.AddComponent<SimpleSmoothMouseLook>();
					//this._FreeCamera.transform.position = _goose.transform.position;
					this._FreeCamera.transform.parent = _goose.transform;
					//this._FreeCamera.transform.position = _goose.transform.parent.position;				
					//_goose.transform.localPosition = this._FreeCamera.transform.position + offset;
					_goose.transform.rotation = this._FreeCamera.transform.rotation;
					freeCamera = this._FreeCamera;
						
				}
					return freeCamera;
				}
			}

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

			private Vector3 offset;
			public void Awake()
			{
				FPSMod.Instance = this;
				this._goose = GameObject.Find("Goose");
            offset = _goose.transform.localPosition += new Vector3(0f, 1.5f, 0.5f);
			}

			//[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public static event Action OnUpdate;

			// Token: 0x0600017A RID: 378 RVA: 0x000097B8 File Offset: 0x000079B8
			public void Update()
			{
				Action onUpdate = FPSMod.OnUpdate;
				if (onUpdate != null)
				{
					onUpdate();
				}
				bool buttonDown = (Input.GetKeyDown(KeyCode.J));
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
						Time.timeScale = 1f;
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
						this._FreeCamera.transform.position = _goose.transform.position + (_goose.gameObject.transform.up * 0.60f) + (_goose.gameObject.transform.forward * -1f);
						//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
						this._FreeCamera.transform.Rotate(0.0f, 300f, 0.0f, Space.World);
						//+ (_goose.gameObject.transform.forward * 1) 
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
			}
		public void LateUpdate()
		{
			//ModInput.LateUpdate();
			//PlayerMove.LateUpdate();
		}

		public static FPSMod Instance;
			public bool IsEnabled;
			public bool IsGUIVisible = true;
			public const float DefaultSpeed = 0.1f;
			public float Speed = 0.1f;
			public float TimeSpeed = 0.008333334f;
			private Camera PrevCamera;
			private Camera _FreeCamera;
			private SimpleSmoothMouseLook _MouseLook;
			public GameObject _goose;
		}
	}
