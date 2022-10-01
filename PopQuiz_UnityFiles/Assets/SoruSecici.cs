using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class SoruSecici : MonoBehaviour
{
    public static List<string> sorulanSoru = new List<string>();
    string dosyaYolu;
    string[] sorular;
    string[] _temp;
    string soru;
    string dogruCevap;
    List<string> yanlisCevap;

    List<int> _tmpIntList;

    //string[] yanlisCevap;
    int index;

    Vector2[] position;

    int posNo;

    float posArtis;
    float posX = -5f;
    float posY = -0.7f;

    public TMP_Text soruText;
    public TMP_Text scoreText;
    public GameObject trueBox;
    public GameObject falseBox;

    // Start is called before the first frame update
    void Awake()
    {
        dosyaYolu = Application.dataPath + "/" + "sorular.csv";
        SoruBul();
        SoruOlustur();
        CevapOlustur();
        print(soru);
        print(dogruCevap);
        foreach (string cvp in yanlisCevap)
        {
            print(cvp);
        }
    }

    // Update is called once per frame
    void SoruBul()
    {
        sorular = File.ReadAllLines(dosyaYolu);
    again:
        index = Random.Range(0, sorular.Length);
        _temp = sorular[index].Split(";");
        soru = _temp[0];
        if (sorulanSoru.Contains(soru))
            goto again;
        else
            sorulanSoru.Add(soru);

        scoreText.text = "SORU: " + sorulanSoru.Count;
        if (sorulanSoru.Count > 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        dogruCevap = _temp[1];
        //yanlisCevap = new string[_temp.Length - 2];
        yanlisCevap = new List<string>();


        for (int i = 2; i <= _temp.Length - 1; i++)
        {
            if (_temp[i] != "")
                yanlisCevap.Add(_temp[i]);
        }
        posNo = yanlisCevap.Count + 1;

        posArtis = 11 / (posNo * 2);
        position = new Vector2[posNo];
        posX += posArtis;
    }


    void BoxPosition()
    {
        for (int i = 0; i < position.Length; i++)
        {
            position[i] = new Vector2(posX, posY);
            posX += posArtis * 2;
        }
    }

    void SoruOlustur()
    {
        soruText.text = soru;
    }

    void CevapOlustur()
    {
        _tmpIntList = new List<int>();

        BoxPosition();

        for (int i = 0; i < yanlisCevap.Count + 1; i++)
        {
        againLabel:
            int RndPosIndex = Random.Range(0, position.Length);
            if (_tmpIntList.Contains(RndPosIndex))
                goto againLabel;
            else
                _tmpIntList.Add(RndPosIndex);

            if (i == 0)
            {

                GameObject box = Instantiate(trueBox, position[RndPosIndex], Quaternion.identity);
                box.GetComponentInChildren<TMP_Text>().text = dogruCevap;
            }
            else
            {
                if (yanlisCevap[i - 1] == "")
                    return;

                GameObject box = Instantiate(falseBox, position[RndPosIndex], Quaternion.identity);
                box.GetComponentInChildren<TMP_Text>().text = yanlisCevap[i - 1];
            }
        }

    }
}
