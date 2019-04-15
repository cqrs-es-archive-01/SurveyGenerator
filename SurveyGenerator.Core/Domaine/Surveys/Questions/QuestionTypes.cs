using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyGenerator.Core.Domaine.Surveys.Questions
{
    public enum QuestionTypes:int
    {
        TextBox=1,
        Comment=2,
        Date=3,
        Time=4,
        DateTime=5,
        DropDownList=6,
        CheckBoxes=7,
        RadioButton=8,
        ImagePicker=9,
        Boolean=10,
        Number=11,
        File=12,
        Rating=13,
    }
}
