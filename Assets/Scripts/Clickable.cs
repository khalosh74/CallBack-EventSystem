using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{

    public class Clickable : MonoBehaviour
    {
        private Camera _mainCamera;
        private Ray _ray;
        private RaycastHit _hit;
        private Health health;

        private float timer = 0f;
        private float growTime = 100f;
        private float maxSize = 2f;
        private bool isMaxSize = false;

        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<Health>();
            _mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _ray = new Ray(
                    _mainCamera.ScreenToWorldPoint(Input.mousePosition),
                    _mainCamera.transform.forward);
            }
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                if (_hit.transform == transform)
                {
                    health.setHealth(0);
                    float temp = 1 * Time.deltaTime;
                    if (isMaxSize == false) StartCoroutine(Grow());
                }
            }
        }
        private IEnumerator Grow()
        {
            Vector3 startScale = transform.localScale;
            Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);
            do
            {
                transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
                timer += Time.deltaTime;
                yield return null;
            }
            while (timer < growTime);

            isMaxSize = true;
        }
    }
}
