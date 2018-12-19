#include <iostream>
using namespace std;

void AlignString(string actual, int width, int token)
// token = 0 means center align, 1 means left align, otherwise right align
{
    int length = actual.length();
    // string length
    int wordCount = 1;
    for(int i = 0; i < length; i++)
        if(actual[i] == ' ')
            wordCount++;
    string* words = new string[wordCount];
    for (int l = 0, c = 0; l < length; ++l) {
        if(actual[l] == ' ')
            c++;
        else
            words[c] += actual[l];
    }
    // words = array of all words, wordCount = number of words

    string* lines = new string[wordCount];
    int lineCount = 0;
    // lines = array of all lines, lineCount = number of lines

    int capacity = width;
    int currentLength;

    for (int j = 0; j < wordCount; )
    {
        currentLength = words[j].length();
        if(capacity > currentLength)
        {
            lines[lineCount] += words[j] + " ";
            capacity -= (currentLength + 1);
            j++;
        }
        else
        {
            if (capacity == currentLength)
            {
                lines[lineCount] += words[j];
                j++;
            }
            lineCount++;
            capacity = width;
        }
    }
    lineCount++;
    int free;
    switch (token)
    {
        case 0:
            for (int i = 0; i < lineCount; ++i)
            {
                free = (width - lines[i].length()) / 2;
                for (int j = 0; j < free; ++j) cout << " ";
                cout << lines[i] << endl;
            }
            break;
        case 1:
            for (int i = 0; i < lineCount; ++i)
                cout << lines[i] << endl;
            break;
        default:
            for (int i = 0; i < lineCount; ++i)
            {
                free = width - lines[i].length();
                for (int j = 0; j < free; ++j) cout << " ";
                cout << lines[i] << endl;
            }
            break;
    }
    delete [] words;
    words = NULL;
    delete [] lines;
    lines = NULL;
}

int main()
{
    string myString = "The moon that wanes today was the full moon yesterday";
    int limit = 25;
    cout << "[Center align]" << endl;
    AlignString(myString, limit, 0);
    cout << endl;
    cout << "[Left align]" << endl;
    AlignString(myString, limit, 1);
    cout << endl;
    cout << "[Right align]" << endl;
    AlignString(myString, limit, 2);

    return 0;
}