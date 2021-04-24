using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextRevealerManager : MonoBehaviour
{
    public List<TextRevealer> textRevealers;
    public UnityAction Finished;

    [HideInInspector]
    public TextRevealer CurrentTextRevealer { get; private set; }
    public bool IsFinished { get; private set; } = false;

    int currentRevealerIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (textRevealers == null)
        {
            // Avoid potential errors
            textRevealers = new List<TextRevealer>();
        }
    }


    void Update()
    {
        if (IsFinished)
        {
            return;
        }

        if (CurrentTextRevealer != null && !CurrentTextRevealer.IsFinished)
        {
            CurrentTextRevealer.Execute();
        }
        else
        {
            currentRevealerIndex++;
            if (currentRevealerIndex >= textRevealers.Count)
            {
                IsFinished = true;
                Finished?.Invoke();
            }
            else
            {
                CurrentTextRevealer = textRevealers[currentRevealerIndex];
                CurrentTextRevealer.RevealText();
            }

        }

    }
}
