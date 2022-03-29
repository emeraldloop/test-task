using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace test_task.Models;

public class FilterViewModel
{
    public FilterViewModel(int? type, string name)
    {
        SelectedType = type;
        SelectedName = name;
    }
    public int? SelectedType { get; private set; }   // выбранный тип бизнеса
    public string SelectedName { get; private set; }    // введенное имя
}