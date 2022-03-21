namespace test_task.Models;

public class SortViewModel
{
    public SortState NameSort { get; private set; } // значение для сортировки по имени
    public SortState DateAddSort { get; private set; }    // значение для сортировки по дате добавления
    public SortState DateUpdateSort { get; private set; } // значение для сортировки по дате обновления
    public SortState BusinessTypeSort { get; private set; }   // значение для сортировки по компании
    public SortState Current { get; private set; }     // текущее значение сортировки
 
    public SortViewModel(SortState sortOrder)
    {
        NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
        DateAddSort = sortOrder == SortState.DateAddAsc ? SortState.DateAddDesc : SortState.DateAddAsc;
        DateUpdateSort = sortOrder == SortState.DateUpdateAsc ? SortState.DateUpdateDesc : SortState.DateUpdateAsc;
        BusinessTypeSort = sortOrder == SortState.BusinessTypeAsc ? SortState.BusinessTypeDesc : SortState.BusinessTypeAsc;
        Current = sortOrder;
    }
}