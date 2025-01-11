using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Molotov : MonoBehaviour
{
    [SerializeField]private GameObject _molotov;
    [SerializeField] private Transform _camera;
    [SerializeField] private int _molotovCount = 3;
    [SerializeField] private float _delay = 2;
    [SerializeField]private Image _forceRound;
    private float _counter;
    public float _forceCounter = 0.1f;
    private Text _molotovText;

    // Start is called before the first frame update
    void Start()
    {
        _counter = _delay;
        _molotovCount = PlayerPrefs.GetInt("molotovCount");
        _molotovText = GameObject.Find("MolotovesText").GetComponent<Text>();
        _molotovText.text = "Molotoves: " + _molotovCount;
        _forceRound = GameObject.Find("ForceRound").GetComponent<Image>();
        _forceRound.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _counter = Mathf.Clamp(_counter, 0, _delay);
        _forceCounter = Mathf.Clamp(_forceCounter, 0, 1);
        if (Input.GetKey(KeyCode.G) && _molotovCount > 0 && _counter == _delay)
        {
            if(_forceCounter < 1)
            {
                _forceCounter += Time.deltaTime;
                _forceRound.gameObject.SetActive(true);
                _forceRound.fillAmount = _forceCounter;
            }
        }
        if (Input.GetKeyUp(KeyCode.G) && _molotovCount > 0 && _counter == _delay)
        {
            _molotovCount--;
            _molotovText.text = "Molotoves: " + _molotovCount;
            PlayerPrefs.SetInt("molotovCount", _molotovCount);
            _counter = 0;
            var molotov = Instantiate(_molotov, _camera.transform.position + _camera.transform.forward * 1, Quaternion.identity);
            molotov.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * (_forceCounter * 20), ForceMode.Impulse);
            _forceCounter = 0.1f;
            _forceRound.gameObject.SetActive(false);
        }
        if(_counter < 3)
        {
            _counter += Time.deltaTime;
        }
    }
    public void AddMolotov()
    {
        _molotovCount++;
        _molotovText.text = "Molotoves: " + _molotovCount;
        PlayerPrefs.SetInt("molotovCount", _molotovCount);
    }
}
