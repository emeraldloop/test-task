using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace test_task.Models;

public class FilterViewModel
{
    public FilterViewModel(List<BusinessType> businessTypes, int? type, string name)
    {
        // устанавливаем элемент, который позволит выбрать всех
        businessTypes.Insert(2, new BusinessType { Name = "Все", Id = 2 });
        BusinessTypes = new SelectList(businessTypes, "Id", "Name", type);
        SelectedType = type;
        SelectedName = name;
    }
    public SelectList BusinessTypes { get; private set; } // список типов бизнеса
    public int? SelectedType { get; private set; }   // выбранный тип бизнеса
    public string SelectedName { get; private set; }    // введенное имя
}