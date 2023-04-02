using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HistoryHero : MonoBehaviour
{
    [SerializeField] private GameObject _historyPanel;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _history;
    [SerializeField] private Sprite[] _img;
    [SerializeField] public int idHero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetId(int id)
    {
        idHero = id;
    }
    public void OpenClose_Panel()
    {
        _historyPanel.SetActive(!_historyPanel.activeSelf);
    }
    public PrintInformationHistory[] qwe =
    {
        new PrintInformationHistory("Mai Sakurajima","Mai found early fame as a model for television, magazines, and books, due to the fact that her mother ran a photographing agency. While she did enjoy her job as a model in the show business, the pressure of being in the public began to take it's toll on her. After being tricked forced to participate in a swimsuit photoshoot by her mother in her third year of middle school, despite making clear over the years that considered such photoshoots unacceptable, Mai realized she was simply used as a tool to make her mother easy money and took a hiatus from acting as a way to get back at her, and decided to attend highschool. However, because of work commitments made prior to her decision to go on hiatus she wasn't able to attend school until half-way through her first year. By then, social circles had formed, making her the \"odd one out\" causing her to be isolated. As a result, the student body didn't know how to deal with her; While they had no reason to bully her, they also feared associating with her would cause themselves to be isolated as well. Unbeknownst to Mai, these events caused a severe emotional disturbance in her and the effects of Adolescence Syndrome caused her existence to become unnoticed by other people. Something that she soon discovered, and while she first enjoyed a respite from the spot-light she soon realized she was in peril of disappearing altogether."),
        new PrintInformationHistory("Speed Porion 2","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 3","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 4","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 5","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 6","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 7","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 8","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 9","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 10","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 11","Get speed 1 lvl"),
        new PrintInformationHistory("Speed Porion 12","Get speed 1 lvl"),
    };
    void PrintInfo()
    {
        _historyPanel.GetComponent<Image>().sprite = _img[idHero];
        _name.text = qwe[idHero].name;
        _history.text = qwe[idHero].info;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PrintInfo();
    }
}
public class PrintInformationHistory
{
    public string name;
    public string info;

    public PrintInformationHistory(string name, string info)
    {
        this.name = name;
        this.info = info;
    }
}
